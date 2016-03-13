using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AnimeRename;

namespace AnimeRename
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("[-v] to view all files in directory");
                Console.WriteLine("[-l] to view database content");
            }
            else
            {
                switch (args[0])
                {
                    case "-v": viewAllFiles(); break;
                    case "-l": DataModel.listAnime(); break;
                    case "-r": renameFiles(); break;
                    case "-t": renameFilesWithoutExt(); break;
                    //case "-t": DataModel.newFileName("temp");break;
                    default: Console.WriteLine("Invalid Argument"); break;
                }
            }
        }

        private static void viewAllFiles()
        {
            //Console.WriteLine(args[0]);
            string folder = "C:\\Users\\asdadasfff\\Downloads";
            DirectoryInfo dInfo = new DirectoryInfo(@folder);
            FileInfo[] files = dInfo.GetFiles();

            foreach (FileInfo f in files)
            {
                if (f.ToString().EndsWith(".mkv"))
                {
                    Console.WriteLine(f.ToString());
                    //Console.WriteLine();
                }
            }
            //Console.ReadKey();
        }

        private static string[] tokenizer(string filename)
        {
            string[] temp = filename.Split(']','[', '_', '(', '-');
            string[] name = new string[3];
            if (temp[1].ToLower() == "animeout")
            {
                //Console.WriteLine(temp);
                //Console.WriteLine(temp[2] + " episode " + temp[3]);
                name[0] = temp[2];
                name[1] = temp[3];
                //name[2] = temp[temp.Length-1];
            }
            else
            {
                //Console.WriteLine(temp[0] + " episode " + temp[1]);
                name[0] = temp[0];
                name[1] = temp[1];
                //name[2] = temp[temp.Length-1].Substring(temp[temp.Length - 1].LastIndexOf('.'));
            }
            return name;
        }

        private static void renameFilesWithoutExt()
        {
            string folder = "C:\\Users\\asdadasfff\\Downloads";
            DirectoryInfo dInfo = new DirectoryInfo(@folder);

            FileInfo[] files = dInfo.GetFiles();
            string[] temp = null;
            string newName = null;
            foreach (FileInfo f in files)
            {
                if (Path.GetExtension(f.FullName) == "")
                {
                    {
                        //Console.WriteLine(f.FullName);
                        temp = tokenizer(f.ToString());
                        temp[0] = DataModel.newFileName(temp[0]);
                        newName = folder + "\\" + temp[0].Trim() + " - " + temp[1].Trim() + ".mkv";

                        Console.WriteLine("renaming..." + f.FullName + "  " + newName);
                        try
                        {
                            File.Move(f.FullName, newName);
                        }
                        catch (Exception err)
                        {

                        }
                    }
                }
            }
            Console.WriteLine("done!");
        }

        private static void renameFiles()
        {
            string folder = "C:\\Users\\asdadasfff\\Downloads";
            DirectoryInfo dInfo = new DirectoryInfo(@folder);
            FileInfo[] files = dInfo.GetFiles();
            string[] temp = null;
            string newName = null;
            foreach(FileInfo f in files)
            {
                if (f.ToString().EndsWith(".mkv"))
                {
                    temp = tokenizer(f.ToString());
                    temp[0] = DataModel.newFileName(temp[0]);
                    newName = folder + "\\" + temp[0].Trim() + " - " + temp[1].Trim() + ".mkv";
                    Console.WriteLine("renaming...");
                    try
                    {
                        File.Move(f.FullName, newName);
                    }
                    catch (Exception err)
                    {

                    }
                }
            }
            Console.WriteLine("done!");
        }
    }
}
