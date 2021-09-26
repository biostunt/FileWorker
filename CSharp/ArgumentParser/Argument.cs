using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFileWorker
{
    class Argument
    {
        public String[] names;
        public String description = "No description provided";
        public int argsCount;
        public String argumentName = "ARGUMENT";
        public bool argsOptional = false;
        public Action<String[]> action;

        public Argument SetNames(params String[] names)
        {
            this.names = names;
            return this;
        }
        public Argument SetDescription(String description)
        {
            this.description = description;
            return this;
        }
        public Argument SetAction(Action<String[]> action)
        {
            this.action = action;
            return this;
        }
        public Argument SetArgumentName(String name)
        {
            this.argumentName = name;
            return this;
        }
        public Argument SetArgsCount(int argsCount)
        {
            this.argsCount = argsCount;
            return this;
        }

        public Argument IsArgsOptional(bool isOptional)
        {
            this.argsOptional = isOptional;
            return this;
        }

        public bool IsArgumentOf(String name)
        {
            return this.names.Contains(name);
        }

        public static Argument CreateArgument()
        {
            return new Argument();
        }

        public void LaunchAction(String[] args)
        {
            this.action(args);
        }
    }
}
