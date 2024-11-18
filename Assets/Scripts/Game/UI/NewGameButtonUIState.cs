using System;
using Game.Core.DataSave;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.UI
{
    public class NewGameButtonUIState : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private string noRecordText;
        
        [SerializeField]
        private string haveRecordText;

        private IUserData userData;
        
        [Inject]
        public void Construct(IUserData userData)
        {
            this.userData = userData;
        }
        
        private void Start()
        {
            text.text = userData.BestScore > 0 ? haveRecordText : noRecordText;
        }
    }
}