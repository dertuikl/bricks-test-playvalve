using System;
using UnityEngine;

namespace Game.Gameplay
{
    public interface IGameEvents
    {
        /// <summary>
        /// Returns destroyed brick position.
        /// </summary>
        event Action<Vector3> BrickDestroyed;
        
        event Action BallSpawned;
    }
}