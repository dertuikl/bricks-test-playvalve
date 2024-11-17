namespace Game.Gameplay
{
    public interface IBallAnchorPointProviderSetup
    {
        public void Setup(BallAnchorPoint ballAnchorPoint);
        public void Release();
    }
}