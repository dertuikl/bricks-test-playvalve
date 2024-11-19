using System;
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

        private IGameEvents gameEvents;
        private bool isDestroying;

        [Inject]
        private void Construct(IGameEvents gameEvents)
        {
            this.gameEvents = gameEvents;
        }

        private void Start()
        {
            gameEvents.GameOver += OnGameOver;
        }

        public void StartMovement(Vector2 direction)
        {
            rigidbody.velocity = (direction.normalized * speed) / 100f;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponentInChildren<GameEndTrigger>()) {
                DestroyBall(2f);
            }
        }

        private void OnGameOver()
        {
            DestroyBall(10f);
        }

        private void DestroyBall(float delay)
        {
            if (isDestroying) {
                return;
            }
            
            // TODO: implement pooling
            Destroy(gameObject, delay);
            
            isDestroying = true;
        }
    }
}