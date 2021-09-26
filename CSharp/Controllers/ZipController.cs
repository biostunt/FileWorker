using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace SharpFileWorker
{
    class ZipController
    {
        public static void CreateFile(string path)
        {
            ZipArchive zip = ZipFile.Open(path, ZipArchiveMode.Create);
            zip.Dispose();
        }

        public static void AddToArchive(string path, params String[] files)
        {
            if (!File.Exists(path))
            {
                throw new Exception($"File with {path} not found");
            }
            ZipArchive zip = ZipFile.Open(path, ZipArchiveMode.Update);
            foreach(String fileName in files)
            {
                if(!File.Exists(fileName))
                {
                    Console.WriteLine($"File with {fileName} not found. Skip...");
                }else
                {
                    zip.CreateEntryFromFile(fileName, Path.GetFileName(fileName));
                }
            }
            zip.Dispose();
        }
        public static void UnzipFile(string path, params String[] args)
        {
            if (!File.Exists(path))
            {
                throw new Exception($"File with {path} not found");
            }
            ZipArchive zip = ZipFile.Open(path, ZipArchiveMode.Read);
            zip.ExtractToDirectory(args[0]);
            zip.Dispose();
        }
        public static void DeleteArchive(string path)
        {
            FileController.DeleteFile(path);
        }

        public static Argument[] GetArguments()
        {
            Argument create = Argument
                .CreateArgument()
                .SetNames("-cz", "--create-zip")
                .SetDescription("Create zip by provided path and provided entries")
                .SetArgumentName("ZIP_FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => ZipController.CreateFile(args[0]));
            Argument add = Argument
                .CreateArgument()
                .SetNames("-az", "--append-zip")
                .SetDescription("Append zip by provided path and provided files")
                .SetArgumentName("ZIP_FILE_NAME")
                .SetArgsCount(2)
                .SetAction((args) => ZipController.AddToArchive(args[0], args.SubArray(1, args.Length - 1)));
            Argument unzip = Argument
                .CreateArgument()
                .SetNames("-uz", "--unzip-zip")
                .SetDescription("Unzip zip by provided path and provided folder")
                .SetArgumentName("ZIP_FILE_NAME")
                .SetArgsCount(2)
                .SetAction((args) => ZipController.UnzipFile(args[0], args.SubArray(1, args.Length - 1)));
            Argument delete = Argument
                .CreateArgument()
                .SetNames("-dz", "--delete-zip")
                .SetDescription("Delete zip by provided path")
                .SetArgumentName("ZIP_FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => ZipController.DeleteArchive(args[0]));
            return new Argument[]
            {
                create,
                add,
                unzip,
                delete
            };
        }

    }
}
