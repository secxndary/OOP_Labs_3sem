using System;
using System.IO;

namespace OOP_Lab13
{
    public static class VADDirInfo
    {
        public static void GetDirInfo()
        {
            string path = Path.GetFullPath(@"C:\Users\valda\source\repos\semester #3\OOP_Labs");
            string DirInfoLog = "";

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (dirInfo.Exists)
                DirInfoLog = "\n=========================================   VADDirInfo   =================================================\n" +
                             "\nКоличество файлов:        " + dirInfo.GetFiles().Length +
                             "\nВремя создания:           " + dirInfo.LastWriteTime +
                             "\nКол-во поддиректориев:    " + dirInfo.GetDirectories().Length +
                             "\nРодительский директорий:  " + dirInfo.Parent.Name;

            VADLog.WriteInLog(DirInfoLog);
        }
    }
}
