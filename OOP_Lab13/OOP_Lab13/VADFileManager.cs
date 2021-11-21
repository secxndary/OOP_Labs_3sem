using System;
using System.IO;
using System.Threading;
using System.IO.Compression;
using System.Linq;

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

            fileInfo.CopyTo(renamePath);
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
            string VADInspectFilesPath = @"D:\Lab13\VADInspect\VADFiles";
            string musicPath = @"D:\Music";

            DirectoryInfo VADFiles = new DirectoryInfo(VADFilesPath);                        /// создать VADFIles
            DirectoryInfo VADInspectFiles = new DirectoryInfo(VADInspectFilesPath);          /// создать Inspect\Files

            if (!VADFiles.Exists)                                                            /// если нет папки Files,
                VADFiles.Create();                                                           /// то создаем ее, а хуле
 
            DirectoryInfo musicDirInfo = new DirectoryInfo(musicPath);                       /// путь к Music 
            FileInfo[] filesMusic = musicDirInfo.GetFiles();                                 /// получить все файлы из Music
            foreach (FileInfo file in filesMusic)
                if (file.Extension == ".mp3")
                    file.CopyTo(Path.Combine(VADFilesPath.ToString(), file.Name), true);     /// скопировать все .mp3 в VADFiles

            if (VADInspectFiles.Exists)                                                      /// если есть Inspect\Files,
                VADInspectFiles.Delete(true);                                                /// то он нам нахуй не нужен

            VADFiles.MoveTo(VADInspectFilesPath);                                            /// перемещаем в Inspect\Files
        }

        public static void MakeArchive()
        {
            string VADFilesPath = @"D:\Lab13\VADFiles";
            string VADInspectFilesPath = @"D:\Lab13\VADInspect\VADFiles";
            string VADInspectUnzipPath = @"D:\Lab13\VADInspect\VADUnzip";
            string ZIPPath = @"D:\Lab13\VADInspect\VADFiles.zip";

            if (File.Exists(ZIPPath))                                                       /// здесь по идее если остался 
                File.Delete(ZIPPath);                                                       /// .zip, его надо удалить,
                                                                                            /// но эта хуйня не работает
            DirectoryInfo VADFiles = new DirectoryInfo(VADFilesPath);
            ZipFile.CreateFromDirectory(VADInspectFilesPath, ZIPPath);                      /// архивируем

            DirectoryInfo VADInspectFiles = new DirectoryInfo(VADInspectFilesPath);         /// если остался Inspect\Files,
            if (VADInspectFiles.Exists)                                                     /// то удаляем его
                VADInspectFiles.Delete(true);

            DirectoryInfo VADInspectUnzip = new DirectoryInfo(VADInspectUnzipPath);         /// создаем папку для разархивации,
            if (VADInspectUnzip.Exists)                                                     /// а если на существует,
                VADInspectUnzip.Delete(true);                                               /// то удаляем ее нахуй
            VADInspectUnzip.Create();

            using (ZipArchive archive = ZipFile.OpenRead(ZIPPath))                          /// спизженный код со stackoverflow
            {                                                                               /// для разархивации в папку Unzip
                var result = from currEntry in archive.Entries
                             where !String.IsNullOrEmpty(currEntry.Name)
                             select currEntry;
                foreach (ZipArchiveEntry entry in result)
                    entry.ExtractToFile(Path.Combine(VADInspectUnzipPath, entry.Name));     /// я эту лабу в рот ебал
            }

        }
    }
}
