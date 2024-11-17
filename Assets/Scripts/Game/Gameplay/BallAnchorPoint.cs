using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class BallAnchorPoint : MonoBehaviour
    {
        private Camera mainCamera;
        private IBallAnchorPointProviderSetup providerSetup;

        private Vector3? worldPosition;
        public Vector3 WorldPosition => (worldPosition ??= ScreenToWorldPoint()).Value;

        private Vector3? ScreenToWorldPoint()
        {
            var worldPoint = mainCamera.ScreenToWorldPoint(transform.position);
            return new Vector3(worldPoint.x, worldPoint.y, 0);
        }

        [Inject]
        public void Construct(Camera mainCamera, 
            IBallAnchorPointProviderSetup providerSetup)
        {
            this.mainCamera = mainCamera;
            providerSetup.Setup(this);
        }

        private void OnDestroy()
        {
            providerSetup?.Release();
        }
    }
}