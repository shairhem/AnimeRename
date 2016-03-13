using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnimeRename
{
    class DataModel
    {
        public static void listAnime()
        {
            StreamReader reader;
            string line = null;
            if (File.Exists("anime.nam"))
            {
                reader = new StreamReader("anime.nam");
                while ((line=reader.ReadLine())!=null)
                {
                    Console.WriteLine(line);
                }
                reader.Close();
            }
        }
        public static string newFileName(string filename)
        {
            string newName = filename;
            StreamReader reader;
            string line = null;
            string[] temp = null;
            if (File.Exists("anime.nam"))
            {
                reader = new StreamReader("anime.nam");
                while ((line = reader.ReadLine()) != null)
                {
                    temp = line.Split(':');
                    if (temp[0].ToLower() == filename.ToLower())
                        newName = temp[1];
                }
                reader.Close();
            }
            //Console.WriteLine(filename + " " + newName);
            return newName;
        }
    }
}
