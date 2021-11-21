using System;
using System.IO;

namespace OOP_Lab13
{
    public static class VADDiskInfo
    {
        public static void GetDiskInfo()
        {
            string classLogInfo = "\n=========================================   VADDiskInfo   ================================================\n";   /// инфа для логгера
            string DiskInfo = "";                           /// сюда будет записываться вся информация из метода GetDrives()

            DriveInfo[] drives = DriveInfo.GetDrives();     /// массив объектов типа DriveInfo с инфой о дисках

            DiskInfo = "\nИмя диска:                " + drives[0].Name +
                       "\nФайловая система:         " + drives[0].DriveFormat +
                       "\nДоступное место:          " + drives[0].AvailableFreeSpace / 1024 / 1024 + " MB" +
                       "\nРазмер диска:             " + drives[0].TotalSize / 1024 / 1024 + " MB" +
                       "\nМетка тома диска:         " + drives[0].VolumeLabel + "\n" +

                       "\nИмя диска:                " + drives[1].Name +
                       "\nФайловая система:         " + drives[1].DriveFormat +
                       "\nДоступное место:          " + drives[1].AvailableFreeSpace / 1024 / 1024 + " MB" +
                       "\nРазмер диска:             " + drives[1].TotalSize / 1024 / 1024 + " MB" +
                       "\nМетка тома диска:         " + drives[1].VolumeLabel;

            string DiskInfoLog = classLogInfo + DiskInfo;

            VADLog.WriteInLog(DiskInfoLog);
        }

    }
}
