using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace
{
    public class TikTokRecommendation
    {

        // 用户行为数据，这里简单模拟了一些数据
        Dictionary<string, List<string>> userBehavior = new Dictionary<string, List<string>>()
            {
                { "User1", new List<string> { "Video1", "Video2", "Video3", "Video4", "Video5" } },
                { "User2", new List<string> { "Video3", "Video4", "Video5", "Video6", "Video7" } },
                { "User3", new List<string> { "Video1", "Video2", "Video5", "Video6", "Video7" } },
                { "User4", new List<string> { "Video1", "Video4", "Video5", "Video7", "Video8" } },
            };

        // 视频数据，这里简单模拟了一些数据
        Dictionary<string, List<string>> videoData = new Dictionary<string, List<string>>()
            {
                { "Video1", new List<string> { "Music", "Dance", "Comedy", "ShortVideo" } },
                { "Video2", new List<string> { "Fashion", "Beauty", "Lifestyle", "Vlog" } },
                { "Video3", new List<string> { "Travel", "Food", "Nature", "Photography" } },
                { "Video4", new List<string> { "Sports", "Fitness", "Outdoor", "Extreme" } },
                { "Video5", new List<string> { "Pets", "Animals", "Wildlife", "Nature" } },
                { "Video6", new List<string> { "Education", "Tutorial", "Learning", "Knowledge" } },
                { "Video7", new List<string> { "News", "Politics", "CurrentEvents", "SocialIssues" } },
                { "Video8", new List<string> { "Gaming", "Esports", "MobileGames", "ConsoleGames" } },
            };

        // 用户画像建立
        Dictionary<string, List<string>> userPortrait = new Dictionary<string, List<string>>();

        // 特征提取
        Dictionary<string, List<double>> videoFeature = new Dictionary<string, List<double>>();


        public string ShowResult()
        {
            // 用户画像
            foreach (var user in userBehavior.Keys)
            {
                userPortrait[user] = new List<string>();
                foreach (var video in userBehavior[user])
                {
                    if (videoData.ContainsKey(video))
                    {
                        userPortrait[user].AddRange(videoData[video]);
                    }
                }
            }

            // 特征
            foreach (var video in videoData.Keys)
            {
                videoFeature[video] = new List<double>();
                foreach (var tag in videoData[video])
                {
                    int count = 0;
                    foreach (var user in userPortrait.Keys)
                    {
                        if (userPortrait[user].Contains(tag))
                        {
                            count++;
                        }
                    }
                    videoFeature[video].Add(count);
                }
            }

            // 相似度计算
            string targetVideo = "Video1";
            Dictionary<string, double> similarity = new Dictionary<string, double>();
            foreach (var video in videoFeature.Keys)
            {
                double dotProduct = 0;
                double normA = 0;
                double normB = 0;
                for (int i = 0; i < videoFeature[video].Count; i++)
                {
                    dotProduct += videoFeature[targetVideo][i] * videoFeature[video][i];
                    normA += Math.Pow(videoFeature[targetVideo][i], 2);
                    normB += Math.Pow(videoFeature[video][i], 2);
                }
                double similarityScore = dotProduct / (Math.Sqrt(normA) * Math.Sqrt(normB));
                similarity[video] = similarityScore;
            }

            // 按相似度排序
            var sortedSimilarity = similarity.OrderByDescending(x => x.Value);

            // 输出推荐结果
            Console.WriteLine("Recommendation for video " + targetVideo + ":");
            foreach (var item in sortedSimilarity)
            {
                if (!userBehavior["User1"].Contains(item.Key)) // 推荐结果中不包含用户已观看过的视频
                {
                    Console.WriteLine(item.Key + " (similarity score: " + item.Value + ")");
                }
            }


            return null;
        }
    }

}
