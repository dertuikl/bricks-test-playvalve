using System;
using UnityEngine;

namespace Game.Gameplay
{
    public class GameEvents : IGameEvents, IGameEventsInvoker
    {
        public event Action<Vector3> BrickDestroyed;
        public event Action BallSpawned;

        public void InvokeBrickDestroyed(Vector3 brickPosition)
        {
            BrickDestroyed?.Invoke(brickPosition);
        }

        public void InvokeBallSpawned()
        {
            BallSpawned?.Invoke();
        }
    }
}