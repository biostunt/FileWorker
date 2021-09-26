using System;
using System.Net;

namespace SharpFileWorker
{
    class Program
    {
        static ArgumentParser CreateParser()
        {
            ArgumentParser parser = new ArgumentParser("Sharp File Worker", "Program for soul, not for file");
            parser.AddArguments(DriveController.GetArguments());
            parser.AddArguments(FileController.GetArguments());
            parser.AddArguments(JsonController.GetArguments());
            parser.AddArguments(XmlController.GetArguments());
            parser.AddArguments(ZipController.GetArguments());
            return parser;
        }


        static void Main(string[] args)
        {
            ArgumentParser parser = CreateParser();
            parser.Parse(args);
        }
    }
}
