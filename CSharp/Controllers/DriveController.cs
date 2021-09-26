using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharpFileWorker
{
    class DriveController
    {
        public static void GetDriveInformation(String driveName = "NONE")
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if(driveName == "NONE" ||  drive.Name.ToLower().Contains(driveName.ToLower()))
                {
                    Console.WriteLine($"Drive Name: {drive.Name}");
                    Console.WriteLine($"Type: {drive.DriveType}");
                    if (drive.IsReady)
                    {
                        Console.WriteLine($"Total size: {drive.TotalSize}");
                        Console.WriteLine($"Empty space: {drive.TotalFreeSpace}");
                        Console.WriteLine($"Label: {drive.VolumeLabel}");
                    }
                    Console.WriteLine();
                }
            }
        }
        public static Argument[] GetArguments()
        {
            Argument driveArgument = Argument
                .CreateArgument()
                .SetNames("-di", "--drive-info")
                .SetArgumentName("DRIVE_NAME")
                .SetArgsCount(1)
                .IsArgsOptional(true)
                .SetDescription("Get system drive info")
                .SetAction((String[] args) => DriveController.GetDriveInformation(args.Length == 0 ? "NONE" : args[0]));
            return new Argument[]
            {
                driveArgument
            };
        }
    }
}
