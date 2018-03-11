using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace GorgeousSnake
{
    //TODO: Don't use shortenings. Statistics instead of Stat
    public class Statistics //TODO: it's static class not abstact regarding the usage
    {
        public static Dictionary<string, string> ScoreThisUser = new Dictionary<string, string>();

        public static void AddScore(string username) //TODO: Public members are named with PascalCase
        {
            string jsonDataWithInfoAboutStatistic = JsonConvert.SerializeObject(Statistics.ScoreThisUser);
            string pathToStatisticFile = Settings.PathToStatisticFile;

            if (!string.IsNullOrEmpty(username))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(pathToStatisticFile, true, System.Text.Encoding.Default))
                    {
                        writer.WriteLine(jsonDataWithInfoAboutStatistic);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static void GetScore()
        {
            using (StreamReader reader = new StreamReader(Settings.PathToStatisticFile, System.Text.Encoding.Default))
            {
                string lineWithInfoStatistic = reader.ReadToEnd();
                string[] Statistics = lineWithInfoStatistic.Split('\n');

                Form2 formSecondWithStatisticTable = new Form2();
                formSecondWithStatisticTable.Show();

                foreach (string statistic in Statistics)
                {
                    if (!string.IsNullOrEmpty(statistic)) //TODO: Ctrl+a then Ctrl+k,f to fix missing/exceeding spaces where needed
                    {
                        var jsonDataDeserialize = JsonConvert.DeserializeObject<Dictionary<string, string>>(statistic);
                        formSecondWithStatisticTable.SetlblStat(jsonDataDeserialize["Name"], jsonDataDeserialize["Score"], jsonDataDeserialize["Level"]);
                    } //TODO: Don't leave empty space. One empty line or no empty lines depending on where.
                }
            }
        }
    }
}
