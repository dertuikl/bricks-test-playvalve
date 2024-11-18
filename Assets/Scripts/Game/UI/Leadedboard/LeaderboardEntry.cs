using TMPro;
using UnityEngine;

namespace Game.UI.Leadedboard
{
    public class LeaderboardEntry : MonoBehaviour
    {
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
                Debug.Log("Hightlight player entry");
            }
        }
    }
}