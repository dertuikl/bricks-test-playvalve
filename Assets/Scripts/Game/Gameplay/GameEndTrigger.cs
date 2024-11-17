using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameEndTrigger : MonoBehaviour
    {
        public event Action PlayerEnteredTrigger;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")) {
                PlayerEnteredTrigger?.Invoke();
            }
        }
    }
}