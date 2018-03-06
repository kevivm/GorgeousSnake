using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace GorgeousSnake
{
    //TODO: Don't use shortenings. Statistics instead of Stat
    public abstract class Stat //TODO: it's static class not abstact regarding the usage
    {
        public static Dictionary<string, string> totalScore = new Dictionary<string, string>();

        public static void addScore(string username) //TODO: Public members are named with PascalCase
        {
            string json = JsonConvert.SerializeObject(Stat.totalScore);
            string writePath = Settings.path;

            if (username != "")
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(json);
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public static void getScore()
        {
            string text;
            using (StreamReader sr = new StreamReader(Settings.path, System.Text.Encoding.Default))
            {
                text = sr.ReadToEnd();
                string[] stats = text.Split('\n');

                Form2 form2 = new Form2();
                form2.Show();
                

                foreach (string s in stats)
                { 
                    if(s != "") //TODO: Ctrl+a then Ctrl+k,f to fix missing/exceeding spaces where needed
                    {
                        var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(s);
                        form2.SetlblStat(values["Name"], values["Score"], values["Level"]);
                    }

                  //TODO: Don't leave empty space. One empty line or no empty lines depending on where.
                    
                }


            }
        }


    }
}
