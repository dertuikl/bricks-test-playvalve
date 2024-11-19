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
                DestroyBall();
            }
        }

        private void OnGameOver()
        {
            DestroyBall();
        }

        private void DestroyBall()
        {
            if (isDestroying) {
                return;
            }
            
            // TODO: implement pooling
            Destroy(gameObject, 2f);
            
            isDestroying = true;
        }
    }
}