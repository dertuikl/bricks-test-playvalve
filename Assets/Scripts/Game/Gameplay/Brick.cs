using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class Brick : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Color[] states;

        public int Health { get; private set; }

        public int Points = 100;
        
        private IScoreManager scoreManager;

        [Inject]
        public void Construct(IScoreManager scoreManager)
        {
            this.scoreManager = scoreManager;
        }
        
        private void Start()
        {
            Health = states.Length;
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
            Health--;
            scoreManager.AddScore(Points);
            RefreshVisualState();

            if (Health <= 0) {
                DestroyBrick();
            }
        }

        private void RefreshVisualState()
        {
            var index = Math.Clamp(Health - 1, 0, states.Length - 1);
            spriteRenderer.color = states[index];
        }

        private void DestroyBrick()
        {
            // TODO: implement pooling
            Destroy(gameObject);
        }
    }
}