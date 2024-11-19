using UnityEngine;

namespace Game.Gameplay
{
    public interface IGameEventsInvoker
    {
        void InvokeBrickDestroyed(Vector3 brickPosition);
        void InvokeBallSpawned();
    }
}