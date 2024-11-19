using System.Collections;
using Game.Gameplay;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class ScoreDisplayerAnimated : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText;

        [SerializeField]
        private float scoreIncrementDuration = 0.3f;
        
        private IScoreManager scoreManager;
        private int currentShownScore;

        [Inject]
        public void Construct(IScoreManager scoreManager)
        {
            this.scoreManager = scoreManager;
        }
        
        private void Start()
        {
            StartCoroutine(ScoreAnimationCoroutine());
        }

        private IEnumerator ScoreAnimationCoroutine()
        {
            while (true) {
                if (scoreManager.CurrentScore == currentShownScore) {
                    yield return null;
                }

                var timePassed = 0f;

                while (timePassed < scoreIncrementDuration) {
                    timePassed += Time.deltaTime;

                    if (timePassed > scoreIncrementDuration) {
                        timePassed = scoreIncrementDuration;
                    }

                    var calculatedScore = Mathf.Lerp(currentShownScore, scoreManager.CurrentScore,
                        timePassed / scoreIncrementDuration);
                    SetScoreText(Mathf.RoundToInt(calculatedScore));

                    yield return null;
                }


                currentShownScore = scoreManager.CurrentScore;
                SetScoreText(scoreManager.CurrentScore);
            }
        }

        private void SetScoreText(int score)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}