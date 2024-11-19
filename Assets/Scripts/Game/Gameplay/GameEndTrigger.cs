using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameEndTrigger : MonoBehaviour
    {
        public event Action BallEnteredTrigger;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")) {
                BallEnteredTrigger?.Invoke();
            }
        }
    }
}