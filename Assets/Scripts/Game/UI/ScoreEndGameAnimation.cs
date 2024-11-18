using System.Collections;
using Game.Core.Utils;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class ScoreEndGameAnimation : MonoBehaviour
    {
        [SerializeField]
        private TypeWriter headerTypeWriter;
        
        [SerializeField] 
        private TextMeshProUGUI scoreText;
        
        [SerializeField] 
        private float duration = 2f;

        private int lastAnimatedScore = 0;

        private void Start()
        {
            scoreText.SetInvisible();
        }

        public IEnumerator ShowScoreAnimation(int targetScore, bool showHeaderAnimation = false)
        {
            if (lastAnimatedScore == targetScore) {
                yield break;
            }
            
            if (showHeaderAnimation) {
                yield return headerTypeWriter.TypeWriterCoroutine();
            }
            
            scoreText.SetVisible();
            
            var timePassed = 0f;

            while (timePassed < duration) {
                timePassed += Time.deltaTime;

                if (timePassed > duration) {
                    timePassed = duration;
                }

                var calculatedScore = Mathf.Lerp(lastAnimatedScore, targetScore, timePassed / duration);
                scoreText.text = Mathf.RoundToInt(calculatedScore).ToString();

                yield return null;
            }

            scoreText.text = targetScore.ToString();
            lastAnimatedScore = targetScore;
        }
    }
}