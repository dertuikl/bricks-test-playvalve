using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class BallLauncher : MonoBehaviour
    {
        [SerializeField]
        private Ball ballPrefab;

        [SerializeField]
        private float spawnTimeDelay = 0.3f;

        private UserInputController inputController;
        private IBallAnchorPointProvider anchorPointProvider;
        private IGameEvents gameEvents;
        private IGameEventsInvoker gameEventsInvoker;
        private Ball firstBall;
        
        [Inject]
        public void Construct(UserInputController inputController,
            IBallAnchorPointProvider anchorPointProvider,
            IGameEvents gameEvents,
            IGameEventsInvoker gameEventsInvoker)
        {
            this.inputController = inputController;
            this.anchorPointProvider = anchorPointProvider;
            this.gameEvents = gameEvents;
            this.gameEventsInvoker = gameEventsInvoker;
        }

        private void Awake()
        {
            inputController.PointerUp += OnPointerUp;
            gameEvents.BrickDestroyed += OnBrickDestroyed;
            
            SpawnFirstBall();
        }
        
        private void SpawnFirstBall()
        {
            firstBall = Instantiate(ballPrefab, anchorPointProvider.BallAnchorPoint.WorldPosition, Quaternion.identity);
            gameEventsInvoker.InvokeBallSpawned();
        }

        private void OnPointerUp(Vector2 direction)
        {
            inputController.PointerUp -= OnPointerUp;
            firstBall.StartMovement(direction);
        }

        private void OnBrickDestroyed(Vector3 brickPosition)
        {
            StartCoroutine(SpawnBallWithDelay(brickPosition));
        }

        private IEnumerator SpawnBallWithDelay(Vector3 position)
        {
            yield return new WaitForSeconds(spawnTimeDelay);
            SpawnBall(position);
        }

        private void SpawnBall(Vector3 position)
        {
            var ball = Instantiate(ballPrefab, position, Quaternion.identity);
            var direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            ball.StartMovement(direction);
            
            gameEventsInvoker.InvokeBallSpawned();
        }

        private void OnDestroy()
        {
            inputController.PointerUp -= OnPointerUp;
            gameEvents.BrickDestroyed -= OnBrickDestroyed;
        }
    }
}