using System;

namespace AddPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            if (!options.Parse(args))
            {
                options.Usage();
                return;
            }

            AddPathSegments(options);
        }

        public static void AddPathSegments(Options options)
        {
            try
            {
                string allPaths = Environment.GetEnvironmentVariable("PATH", options.Target);
                if (allPaths != null)
                    allPaths = options.PathSegment + "; " + allPaths;
                else
                    allPaths = options.PathSegment;
                Environment.SetEnvironmentVariable("PATH", allPaths, options.Target);

                Console.WriteLine("Added path segment: {0}", options.PathSegment);
            }
            catch (Exception ex)
            {
                Console.WriteLine("could not add path segment: {0} -  error {1}", options.PathSegment, ex);
            }
        }
    }
}
