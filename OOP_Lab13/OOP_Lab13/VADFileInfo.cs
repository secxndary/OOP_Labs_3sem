using System;
using System.IO;

namespace OOP_Lab13
{
    public static class VADFileInfo
    {
        public static void GetFileInfo()
        {
            string path = Path.GetFullPath(@"C:\Users\valda\source\repos\semester #3\OOP_Labs\OOP_Lab13\OOP_Lab13\vadlog.txt");
            string classLogInfo = "\n=========================================   VADFileInfo   ================================================\n";
            string fileInfoLog = "";

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
                fileInfoLog = classLogInfo +
                              "\nПолный путь:              " + path +
                              "\nИмя файла:                " + fileInfo.Name +
                              "\nРазмер файла:             " + fileInfo.Length + " KB" +
                              "\nРасширение:               " + fileInfo.Extension +
                              "\nДата изменения:           " + fileInfo.LastWriteTime;

            VADLog.WriteInLog(fileInfoLog);
        }
    }
}
