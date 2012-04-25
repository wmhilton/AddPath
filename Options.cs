using System;

namespace AddPath
{
    public class Options
    {
        public EnvironmentVariableTarget Target { get; set; }
        public string PathSegment { get; set; }

        public bool Parse(string[] args)
        {
            Target = EnvironmentVariableTarget.Machine;

            foreach (string arg in args)
            {
                if (arg.StartsWith("-"))
                {
                    switch (arg)
                    {
                        case "-p":
                            Target = EnvironmentVariableTarget.Process;
                            break;

                        case "-m":
                            Target = EnvironmentVariableTarget.Machine;
                            break;

                        default:
                            Console.WriteLine("Unknown option: {0}", arg);
                            return false;
                    }
                }
                else
                {
                    if (PathSegment == null)
                    {
                        PathSegment = arg;
                    }
                    else
                    {
                        Console.WriteLine("Unknown parameter: {0}", arg);
                        return false;
                    }
                }

            }

            if(PathSegment == null)
            {
                return false;
            }
            return true;
        }

        internal void Usage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("    AddPath  [options] [path]");
            Console.WriteLine();
            Console.WriteLine("    [options] can be zero or more of:");
            Console.WriteLine("        -p    only change path in process");
            Console.WriteLine("        -m    change path on machine is default");
            Console.WriteLine();
            Console.WriteLine("    [path] directory you want to add");
        }
    }
}
