using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SharpFileWorker
{
    class FileController
    {
        public static void ReadFile(String path)
        {
            if(!File.Exists(path))
            {
                throw new FileNotFoundException($"File with name {path} not found!");
            }
            String[] lines = File.ReadAllLines(path);
            foreach(String line in lines)
            {
                Console.Write(line);
            }
        }

        public static void CreateFile(String path)
        {
            if (File.Exists(path))
            {
                throw new FileNotFoundException($"File on path: {path} already exists!");
            }
            File.Create(path);
        }

        public static void AppendFile(String path, params String[] data)
        {
            String value = string.Join(' ', data);
            if(File.Exists(path))
            {
                // If file exists append it
                File.AppendAllText(path, value);
            } else
            {
                // Otherwise create it
                CreateFile(path);
                File.AppendAllText(path, value);
            }
        }

        public static void DeleteFile(String path)
        {
            File.Delete(path);
        }

        public static Argument[] GetArguments()
        {
            Argument readFile = Argument
                .CreateArgument()
                .SetNames("-rf", "--read-file")
                .SetDescription("Read file by provided path")
                .SetArgumentName("FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => FileController.ReadFile(args[0]));
            Argument createFile = Argument
                .CreateArgument()
                .SetNames("-cf", "--create-file")
                .SetDescription("Create file by provided path")
                .SetArgumentName("FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => FileController.CreateFile(args[0]));

            Argument appendFile = Argument
                .CreateArgument()
                .SetNames("-af", "--append-file")
                .SetDescription("Append file by provided path and provided text")
                .SetArgumentName("FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => FileController.AppendFile(args[0], args.SubArray(1, args.Length - 1)));

            Argument deleteFile = Argument
                .CreateArgument()
                .SetNames("-df", "--delete-file")
                .SetDescription("Delete file by provided path")
                .SetArgumentName("FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => FileController.DeleteFile(args[0]));

            return new Argument[]
            {
                readFile,
                createFile,
                appendFile,
                deleteFile
            };
        }
    }
}
