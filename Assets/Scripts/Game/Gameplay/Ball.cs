using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private float speed = 500f;
        
        [SerializeField]
        private new Rigidbody2D rigidbody;
        
    
        private UserInputController inputController;
        private IBallAnchorPointProvider anchorPointProvider;
    
        [Inject]
        public void Construct(UserInputController inputController,
            IBallAnchorPointProvider anchorPointProvider)
        {
            this.inputController = inputController;
            this.anchorPointProvider = anchorPointProvider;
        }
        
        private void Awake()
        {
            inputController.PointerUp += StartMovement;
            
            SetupStartPosition();
        }
    
        private void SetupStartPosition()
        {
            if (anchorPointProvider.BallAnchorPoint != null) {
                transform.position = anchorPointProvider.BallAnchorPoint.WorldPosition;
            }
        }
    
        private void StartMovement(Vector2 direction)
        {
            rigidbody.AddForce(direction.normalized * speed);
        }
    
        private void OnDestroy()
        {
            inputController.PointerUp -= StartMovement;
        }
    }
}