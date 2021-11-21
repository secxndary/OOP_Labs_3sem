using System;
using System.IO;
using System.Threading;

namespace OOP_Lab13
{
    public static class VADFileManager
    {
        public static void VADInspect()
        {
            string classLogInfo = "\n\n\nVADFileManager:\n";            /// инфа для логгера
            string inspectLog = "";

            DriveInfo[] drives = DriveInfo.GetDrives();                 /// получили инфу о всех дисках
            string inspectPath = drives[1].Name;                        /// путь диска D:\ полученный от DriveInfo.GetDrives()
            DirectoryInfo directory = new DirectoryInfo(@"D:\Lab13");   /// тот же путь, только типа данных DirectoryInfo

            directory.Create();                                         /// создаем субдерикторий D:\Lab13\VADInspect
            directory.CreateSubdirectory(@"VADInspect");  

            string filePath = @"D:\Lab13\VADInspect\vaddirinfo.txt";
            FileInfo fileInfo = new FileInfo(filePath);                 /// fileInfo шобы всё работало
            using (StreamWriter sw = fileInfo.CreateText())             /// создаем файл и сразу пишем поток
            {
                sw.WriteLine("Поздравляем всем ПОИТом Виталия Цаль (Папича)\n" +
                             "с Днём Рождения 19.11.2021! Желаем, чтобы разрабы не\n" +
                             "были даунами, меньше рейджей и, конечно же, как можно\n" +
                             "больше гачи донатов!");
                sw.Close();                                             /// и закрываем нахуй а то мало ли
            }


            string renamePath = @"D:\Lab13\VADInspect\vaddirinfoRENAMED.txt";
            FileInfo renameBuf = new FileInfo(renamePath);              /// буфер чтобы удалить созданный ранее RENAMED
            renameBuf.Delete();

            //Thread.Sleep(3000);                                         /// задержка перед выполнением 3 секунды
            fileInfo.CopyTo(renamePath);
            //Thread.Sleep(3000);                                        
            fileInfo.Delete();


            DirectoryInfo inspectDirInfo = new DirectoryInfo(@"D:\Lab13\VADInspect");
            if (inspectDirInfo.Exists)
                inspectLog = classLogInfo +
                                   "\nVADInspect:" +
                                   "\nФайлы:                    " + inspectDirInfo.GetFiles()[0].Name +
                                   "\nПоддиректории:            " + inspectDirInfo.GetDirectories()[0] +
                                   "\nРодительский директорий:  " + inspectDirInfo.Parent.Name;

            VADLog.WriteInLog(inspectLog);
        }

        public static void VADFiles()
        {
            string VADFilesPath = @"D:\Lab13\VADFiles";
            string VADInspectPath = @"D:\Lab13\VADInspect";
            string VADInspectFilesPath = @"D:\Lab13\VADInspect\VADFiles";
            string musicPath = @"D:\Music";

            DirectoryInfo VADFiles = new DirectoryInfo(VADFilesPath);                        /// создать VADFIles
            DirectoryInfo musicDirInfo = new DirectoryInfo(musicPath);    
            
            FileInfo[] filesMusic = musicDirInfo.GetFiles();                                 /// получить все файлы из Music
            foreach (FileInfo file in filesMusic)
                if (file.Extension == ".mp3")
                    file.CopyTo(Path.Combine(VADFilesPath.ToString(), file.Name), true);     /// скопировать все .mp3 в VADFiles

            DirectoryInfo VADInspect = new DirectoryInfo(VADInspectPath);                    /// создаем DirectoryInfo по путям
            DirectoryInfo VADInspectFiles = new DirectoryInfo(VADInspectFilesPath);          /// Inspect и Inspect\Files
            VADFiles.MoveTo(VADInspectFilesPath);                                            /// перемещаем в Inspect\Files
        }
    }
}
