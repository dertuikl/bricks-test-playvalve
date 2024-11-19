using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Core.DataSave;
using Game.Core.Screens;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Core.Navigation
{
    /// <summary>
    /// Navigation state machine.
    /// </summary>
    public class NavigationStateMachine : MonoBehaviour, INavigation
    {
        [FormerlySerializedAs("container")]
        [SerializeField] 
        private GameObject screenContainer;

        [SerializeField] 
        private BaseScreen[] screens;

        private IDebugState debugState;
        private Dictionary<string, BaseScreen> screensDictionary;
        private BaseScreen currentScreen;

        private string FallbackScreen => ScreenNames.LobbyScreen;

        [Inject]
        public void Construct(IDebugState debugState)
        {
            this.debugState = debugState;
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

        public async void NavigateTo(string screenName)
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

                await CloseCurrentScreen();
            }
            
            await OpenScreen(screenName);
        }

        private async Task OpenScreen(string newScreenName)
        {
            var newScreenPrefab = screensDictionary[newScreenName];
            var newScreen = Instantiate(newScreenPrefab, screenContainer.transform);
            await newScreen.OpenScreen();

            currentScreen = newScreen;

            if (debugState.LogsEnabled) {
                Debug.Log("Opened new screen: " + newScreenName);
            }
        }
        
        private async Task CloseCurrentScreen()
        {
            await currentScreen.CloseScreen();
            Destroy(currentScreen.gameObject);
            currentScreen = null;
        }
    }
}