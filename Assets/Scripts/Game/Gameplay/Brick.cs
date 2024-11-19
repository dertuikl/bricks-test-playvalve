using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Gameplay
{
    public class Brick : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Color[] states;

        [SerializeField]
        private int points = 100;
        
        private int health;
        
        private IScoreManager scoreManager;
        private IGameEventsInvoker gameEventsInvoker;

        [Inject]
        public void Construct(IScoreManager scoreManager,
            IGameEventsInvoker gameEventsInvoker)
        {
            this.scoreManager = scoreManager;
            this.gameEventsInvoker = gameEventsInvoker;
        }
        
        private void Start()
        {
            health = states.Length;
            RefreshVisualState();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player")) {
                ProcessHit();
            }
        }

        private void ProcessHit()
        {
            health--;
            scoreManager.AddScore(points);
            RefreshVisualState();

            if (health == 0) {
                DestroyBrick();
            }
        }

        private void RefreshVisualState()
        {
            var index = Math.Clamp(health - 1, 0, states.Length - 1);
            spriteRenderer.color = states[index];
        }

        private void DestroyBrick()
        {
            // TODO: implement pooling
            Destroy(gameObject);
            gameEventsInvoker?.InvokeBrickDestroyed(transform.position);
        }
    }
}