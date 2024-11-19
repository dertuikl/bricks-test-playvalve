using System;

namespace Game.Gameplay
{
    public interface IScoreManager
    {
        void AddScore(int scoreToAdd);
        void ApplyMultiplier(float multiplier);
        void SaveAndResetScore();
    }
}