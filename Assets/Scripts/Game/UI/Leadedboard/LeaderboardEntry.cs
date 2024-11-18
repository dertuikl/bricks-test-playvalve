using System;
using TMPro;
using UnityEngine;

namespace Game.UI.Leadedboard
{
    public class LeaderboardEntry : MonoBehaviour
    {
        private const string HighlightTriggerKey = "Highlight";
        
        [SerializeField]
        private TextMeshProUGUI positionText;
        
        [SerializeField]
        private TextMeshProUGUI nameText;
        
        [SerializeField]
        private TextMeshProUGUI scoreText;

        public void FillWithInfo(int position, LeaderboardEntryInfo info)
        {
            positionText.text = position.ToString();
            nameText.text = info.Name;
            scoreText.text = info.Score.ToString();
            
            if (info.IsPlayer) {
                GetComponent<Animator>().SetTrigger(HighlightTriggerKey);
            }
        }
    }
}