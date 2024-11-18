namespace Game.UI.Leadedboard
{
    public readonly struct LeaderboardEntryInfo
    {
        public readonly string Name;
        public readonly int Score;
        public readonly bool IsPlayer;

        public LeaderboardEntryInfo(string name, 
            int score, 
            bool isPlayer = false)
        {
            Name = name;
            Score = score;
            IsPlayer = isPlayer;
        }
    }
}