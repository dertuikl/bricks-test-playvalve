using UnityEngine;

namespace Game.Gameplay
{
    // Workaround to avoid screens factory implementation just for the sake of ball anchor reference.
    // But I still can do it ;)
    public class BallAnchorPointProvider : IBallAnchorPointProvider, IBallAnchorPointProviderSetup
    {
        public BallAnchorPoint BallAnchorPoint { get; private set; }

        public void Setup(BallAnchorPoint ballAnchorPoint)
        {
            BallAnchorPoint = ballAnchorPoint;
        }

        public void Release()
        {
            Debug.Log("Ball Anchor Point Released");
            BallAnchorPoint = null;
        }
    }
}