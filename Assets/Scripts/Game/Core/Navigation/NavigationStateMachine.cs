using System;
using System.Collections.Generic;
using System.Linq;
using Game.Core.DataSave;
using Game.Core.Screens;
using UnityEngine;
using Zenject;

namespace Game.Core.Navigation
{
    /// <summary>
    /// Navigation state machine.
    /// </summary>
    public class NavigationStateMachine : MonoBehaviour, INavigation
    {
        [SerializeField] 
        private GameObject container;

        [SerializeField] 
        private BaseScreen[] screens;

        private IUserData userData;
        private Dictionary<string, BaseScreen> screensDictionary;
        private BaseScreen currentScreen;

        private string FallbackScreen => ScreenNames.LobbyScreen;

        [Inject]
        public void Construct(IUserData userData)
        {
            this.userData = userData;
        }
        
        private void Start()
        {
            CreateScreensDictionary();
            NavigateTo(FallbackScreen);
        }

        private void CreateScreensDictionary()
        {
            screensDictionary = screens.ToDictionary(
                screen => screen.Name,
                screen => screen);
        } 

        public void NavigateTo(string screenName)
        {
            if (!screensDictionary.ContainsKey(screenName)) {
                Debug.LogError($"Unable to open screen {screenName} as it is not in screen dictionary.");
                return;
            }
            
            if (currentScreen != null) {
                if (currentScreen.Name == screenName) {
                    Debug.Log($"Unable to open screen {screenName} as it is already opened.");
                    return;
                }

                CloseCurrentScreen();
            }
            
            OpenScreen(screenName);
        }

        private void OpenScreen(string newScreenName)
        {
            var newScreenPrefab = screensDictionary[newScreenName];
            var newScreen = Instantiate(newScreenPrefab, container.transform);
            newScreen.OpenScreen();

            currentScreen = newScreen;

            if (userData.LogsEnabled) {
                Debug.Log("Opened new screen: " + newScreenName);
            }
        }
        
        private void CloseCurrentScreen()
        {
            currentScreen.CloseScreen();
            Destroy(currentScreen.gameObject);
            currentScreen = null;
        }
    }
}