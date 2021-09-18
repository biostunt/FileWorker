using System.IO;
using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace SharpFileWorker
{
    class JsonController
    {
        public static void DeleteFile(String path)
        {
            FileController.DeleteFile(path);
        }
        public static void ReadFile(String path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File with path: {path} not found!");
            }
            string text = File.ReadAllText(path);
            JObject jsonObject = JsonConvert.DeserializeObject<JObject>(text);
            Console.WriteLine(JsonConvert.SerializeObject(jsonObject, Formatting.Indented));
        }
        public static void CreateTemplateJson(String path)
        {
            if (File.Exists(path))
            {
                throw new FileNotFoundException($"File with path: {path} already exists!");
            }
            JObject jsonObject = new JObject();
            jsonObject["id"] = 1;
            jsonObject["name"] = "some default name";
            jsonObject["roles"] = new JArray(new String[] { "ADMIN", "MODERATOR" });
            File.WriteAllText(path, JsonConvert.SerializeObject(jsonObject, Formatting.Indented));
        }
        public static void CreateJsonObject(String path, params String[] entries)
        {
            if (File.Exists(path))
            {
                throw new FileNotFoundException($"File with path: {path} already exists!");
            }
            JObject jsonObject = (JObject) JsonConvert.DeserializeObject(String.Join('\n', entries));
            File.WriteAllText(path, JsonConvert.SerializeObject(jsonObject, Formatting.Indented));
        }
        public static Argument[] GetArguments()
        {
            Argument deleteJson = Argument
                .CreateArgument()
                .SetNames("-dj", "--delete-json")
                .SetDescription("Delete json file")
                .SetArgumentName("JSON_FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => JsonController.DeleteFile(args[0]));
            Argument readJson = Argument
                .CreateArgument()
                .SetNames("-rj", "--read-json")
                .SetDescription("Read json file by provided path")
                .SetArgumentName("JSON_FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => JsonController.ReadFile(args[0]));
            Argument createTemplate = Argument
                .CreateArgument()
                .SetNames("-ctj", "--create-template-json")
                .SetDescription("Create template json by provided path")
                .SetArgumentName("JSON_FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => JsonController.CreateTemplateJson(args[0]));
            Argument create = Argument
                .CreateArgument()
                .SetNames("-cj", "--create-json")
                .SetDescription("Create json by provided path and provided entries")
                .SetArgumentName("JSON_FILE_NAME")
                .SetArgsCount(2)
                .SetAction((args) => JsonController.CreateJsonObject(args[0], args.SubArray(1, args.Length - 1)));
            return new Argument[]
            {
                createTemplate,
                create,
                readJson,
                deleteJson
            };
        }
    }
}
