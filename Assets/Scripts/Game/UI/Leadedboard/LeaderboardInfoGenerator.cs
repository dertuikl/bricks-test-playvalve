using System.Collections.Generic;
using Game.Core.DataSave;
using Random = System.Random;

namespace Game.UI.Leadedboard
{
    public class LeaderboardInfoGenerator : ILeaderboardInfoGenerator
    {
        private const int MaxLeaderboardCount = 100;
        private const int MaxScoreValue = 1000;
        private const string UserName = "You";
        
        private readonly List<string> firstNameParts = new() { "Kate", "Sara", "Jared", "TJ", "Valerie", "Stas", "Paul", "Ken", "Jade", "Ella", "Morris", "Ben"};
        private readonly List<string> lastNameParts = new() { "Smith", "Kova", "Tanaka", "Patel", "Garcia", "Yuki", "Chen", "Lopez", "Nguyen", "Kim", "Abson", "Tatler" };
        
        private readonly IUserData userData;
        private Random random;
        
        public LeaderboardInfoGenerator(IUserData userData)
        {
            this.userData = userData;
        }
        
        public LeaderboardEntryInfo[] GenerateLeaderboardEntriesInfo()
        {
            random = new Random(userData.LeaderboardSeed.GetHashCode());
            
            var result = new LeaderboardEntryInfo[MaxLeaderboardCount];
            var userEntryInfo = new LeaderboardEntryInfo(UserName, userData.BestScore, true);
            result[0] = userEntryInfo;
            for (var i = 1; i < MaxLeaderboardCount; i++) {
                var score = random.Next(0, MaxScoreValue);
                result[i] = new LeaderboardEntryInfo(GenerateRandomName(), score);
            }
            
            return result;
        }
        
        private string GenerateRandomName()
        {
            var firstName = firstNameParts[random.Next(0, firstNameParts.Count)];
            var lastName = string.Empty;
            if (random.Next(0, 100) > 20) {
                lastName = $" {lastNameParts[random.Next(0, lastNameParts.Count)]}";
            }
            return $"{firstName}{lastName}#{random.Next(100, 999)}";
        }
    }
}