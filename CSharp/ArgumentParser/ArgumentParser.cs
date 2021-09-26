using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SharpFileWorker
{
    class ArgumentParser
    {
        public String appName;
        public String description;
        private ArrayList arguments = new ArrayList();


        public ArgumentParser(String appName, String description)
        {
            this.appName = appName;
            this.description = description;
        }

        public ArgumentParser AddArguments(params Argument[] arguments)
        {
            foreach(Argument argument in arguments)
            {
                this.arguments.Add(argument);
            }
            return this;
        }

        public void PrintHelp()
        {
            Console.WriteLine($"\n{this.appName}: ");
            Console.WriteLine(this.description);
            Console.WriteLine("\nUsage: ");
            for(int i = 0; i < this.arguments.Count; i++)
            {
                Argument argument = (Argument) this.arguments[i];
                String additionalArgs = "";
                for(int j = 0; j < argument.argsCount; j++)
                    additionalArgs += $"<{argument.argumentName}{(argument.argsOptional ? "?" : "!")}> ";
                Console.Write($"{i + 1}. ");
                foreach (String name in argument.names)
                    Console.Write($"{name} {additionalArgs} ");
                Console.WriteLine($"\n{argument.description}\n");
            }
        }

        public void Parse(String[] args)
        {
            if(args.Length == 0)
            {
                this.PrintHelp();
                System.Environment.Exit(1);
            }
            foreach(Argument argument in this.arguments)
            {
                if (argument.IsArgumentOf(args[0]))
                {
                    if(args.Length - 1 < argument.argsCount && !argument.argsOptional)
                    {
                        Console.WriteLine("Not enough arguments");
                    }
                    try
                    {
                        argument.LaunchAction(args.SubArray(1, args.Length - 1));
                    } catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    } finally {
                        System.Environment.Exit(1);
                    }
                }
            }
        }

    }
}
