using UnityEngine;
using Zenject;

namespace Game.Gameplay.Levels
{
    public class LevelGridBounds : MonoBehaviour
    {
        [SerializeField]
        private GameObject borderLeft;

        [SerializeField]
        private GameObject borderRight;

        [SerializeField]
        private GameObject borderUp;

        [SerializeField]
        private GameObject borderDown;

        private Camera mainCamera;

        [Inject]
        public void Construct(Camera mainCamera)
        {
            this.mainCamera = mainCamera;
        }

        private void Awake()
        {
            SetupGridBounds();
        }

        private void SetupGridBounds()
        {
            var screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            var screenOrigin = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));

            borderLeft.transform.position = new Vector3(screenOrigin.x, (screenBounds.y + screenOrigin.y) / 2, 0);
            borderRight.transform.position = new Vector3(screenBounds.x, (screenBounds.y + screenOrigin.y) / 2, 0);
            borderUp.transform.position = new Vector3((screenBounds.x + screenOrigin.x) / 2, screenBounds.y, 0);
            borderDown.transform.position = new Vector3((screenBounds.x + screenOrigin.x) / 2, screenOrigin.y, 0);
        }
    }
}