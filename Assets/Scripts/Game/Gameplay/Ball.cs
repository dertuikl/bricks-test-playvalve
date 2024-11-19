using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private float speed = 500f;
        
        [SerializeField]
        private new Rigidbody2D rigidbody;
        
        public void StartMovement(Vector2 direction)
        {
            rigidbody.velocity = (direction.normalized * speed) / 100f;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<GameEndTrigger>()) {
                Destroy(gameObject, 2f);
            }
        }
    }
}