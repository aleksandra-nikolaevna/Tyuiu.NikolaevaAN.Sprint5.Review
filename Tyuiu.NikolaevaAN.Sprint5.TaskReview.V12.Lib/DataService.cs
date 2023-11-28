using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.NikolaevaAN.Sprint5.TaskReview.V12.Lib
{
    public class DataService : ISprint5Task7V12
    {
        public string LoadDataAndSave(string path)
        {
            string pathSaverFile = $@"{Directory.GetCurrentDirectory()}\OutPutDataFileTask7V12.txt";
            FileInfo fileInfo = new FileInfo(pathSaverFile);
            bool fileExists = fileInfo.Exists;
            if (fileExists)
            {
                File.Delete(pathSaverFile);
            }

            string strLine = "";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if ((line[i] >= 'а') && (line[i] <= 'я'))
                        {
                            strLine += line[i].ToString().ToUpper();
                        }
                        else
                        {
                            strLine += line[i];
                        }
                    }
                    File.AppendAllText(pathSaverFile, strLine + Environment.NewLine);
                    strLine = "";
                }
                return pathSaverFile;
            }
        }
    }
}
