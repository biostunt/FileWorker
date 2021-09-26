using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Xml;
using System;
using System.Linq;

namespace SharpFileWorker
{
    class XmlController
    {
        public static void CreateTemplateFile(string path)
        {
            if(File.Exists(path))
            {
                throw new Exception($"file by path {path} already exists");
            }
            JObject root = new JObject();
            JArray container = new JArray();
            JObject jsonObject = new JObject();
            jsonObject["id"] = 1;
            jsonObject["name"] = "some strange name";
            jsonObject["roles"] = new JArray(new string[] { "Admin" });
            container.Add(jsonObject);
            container.Add(jsonObject);
            JObject subRoot = new JObject();
            subRoot["person"] = container;
            root["root"] = subRoot;
            XmlDocument document = JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(root));
            File.WriteAllText(path, document.InnerXml);
        }
        public static void createFile(string path, params String[] data)
        {
            String xmlString = String.Join(' ',data);
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlString);
            File.WriteAllText(path, document.InnerXml);
        }

        public static void ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception($"file by path {path} not found!");
            }
            string xmlString = File.ReadAllText(path);
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlString);
            Console.WriteLine(document.InnerXml);
        }

        public static void DeleteFile(string path)
        {
            FileController.DeleteFile(path);
        }

        public static Argument[] GetArguments()
        {
            Argument createTemplate = Argument
                .CreateArgument()
                .SetNames("-ctx", "--create-template-xml")
                .SetDescription("Create template xml by provided path")
                .SetArgumentName("XML_FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => XmlController.CreateTemplateFile(args[0]));
            Argument createFile = Argument
                .CreateArgument()
                .SetNames("-cx", "--create-xml")
                .SetDescription("Create xml by provided path and provided entity")
                .SetArgumentName("XML_FILE_NAME")
                .SetArgsCount(2)
                .SetAction((args) => XmlController.createFile(args[0], args.SubArray(1, args.Length - 1)));
            Argument readFile = Argument
                .CreateArgument()
                .SetNames("-rx", "--read-xml")
                .SetDescription("Read template xml by provided path")
                .SetArgumentName("XML_FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => XmlController.ReadFile(args[0]));
            Argument deleteFile = Argument
                .CreateArgument()
                .SetNames("-dx", "--delete-xml")
                .SetDescription("Delete template xml by provided path")
                .SetArgumentName("XML_FILE_NAME")
                .SetArgsCount(1)
                .SetAction((args) => XmlController.DeleteFile(args[0]));

            return new Argument[]
            {
                createTemplate,
                createFile,
                readFile,
                deleteFile
            };
        }
    }
}
