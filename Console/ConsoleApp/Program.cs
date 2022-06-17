using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    public class RankInfo
    {
        public int PointOfRank { get; set; }
        public int PoistionOfRank { get; set; }
    }

    public class PlayerScore
    {
        public int ScoreValue { get; set; }
        public int AchivePosition { get; set; }
    }

    class Program
    {
        public static List<int> GetRank(List<int> ranked, List<int> player)
        {
            var result = new List<int>();

            var distinctRankList = ranked.Distinct().OrderByDescending(rn => rn);

            int position = 1;
            List<RankInfo> rankInfoList = new List<RankInfo>();
            foreach (var rankDist in distinctRankList)
            {
                RankInfo rankItem = new RankInfo();
                rankItem.PointOfRank = rankDist;
                rankItem.PoistionOfRank = position;
                rankInfoList.Add(rankItem);
                position++;
            }

            List<PlayerScore> playerScroeList = new List<PlayerScore>();
            foreach (var item in player)
            {
                PlayerScore playerScore = new PlayerScore();
                playerScore.ScoreValue = item;
                playerScroeList.Add(playerScore);
            }

            int positionRankMark = 0;
            foreach (var scoreItem in playerScroeList)
            {
                positionRankMark = 0;
                for (int indexCounter = 0; indexCounter < rankInfoList.Count; indexCounter++)
                {
                    positionRankMark = rankInfoList[indexCounter].PoistionOfRank;
                    if (scoreItem.ScoreValue >= rankInfoList[indexCounter].PointOfRank)
                    {
                        scoreItem.AchivePosition = rankInfoList[indexCounter].PoistionOfRank;
                        break;
                    }
                }

                if (scoreItem.AchivePosition == 0)
                {
                    scoreItem.AchivePosition = positionRankMark + 1;
                }
            }

            foreach (var item in playerScroeList)
            {
                result.Add(item.AchivePosition);
            }

            return result;
        }
        static void Main(string[] args)
        {
            //TODO: Change this input file path before start
            //var filePath = "E:\\InterviewSourceCode\\Console\\ConsoleApp\\Input.txt";
            var filePath = "D:\\Projects\\Interview\\SourceCode\\Console\\ConsoleApp\\Input.txt";


            var lines = System.IO.File.ReadLines(filePath).ToList();

            int rankedCount = Convert.ToInt32(lines[0].Trim());

            List<int> ranked = lines[1].TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            int playerCount = Convert.ToInt32(lines[2].Trim());

            List<int> player = lines[3].TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            List<int> result = GetRank(ranked, player);

            Console.WriteLine(String.Join("\n", result));

        }
    }
}
