using System;

namespace DoxygenGenerator
{
    public static class CommandLine
    {
        private static bool Setup()
        {
            var variables = new string[]
            {
                Variables.DoxygenPath,
                Variables.InputDirectory,
                Variables.OutputDirectory,
                Variables.Project,
                Variables.Synopsis,
                Variables.Version
            };
            Console.WriteLine($"Validating variables");
            if (VariableUtils.EnvironmentVariablesMissing(variables))
            {
                UnityEngine.Debug.LogError("Build canceled, missed variable");
                Console.WriteLine("Build canceled, missed variable");
                Environment.ExitCode = -1;
                return false;
            }
            Console.WriteLine($"Variables are valid");
            
            GeneratorSettings.doxygenPath = VariableUtils.GetVariable(Variables.DoxygenPath);
            GeneratorSettings.inputDirectory = VariableUtils.GetVariable(Variables.InputDirectory);
            GeneratorSettings.outputDirectory = VariableUtils.GetVariable(Variables.OutputDirectory);
            GeneratorSettings.project = VariableUtils.GetVariable(Variables.Project);
            GeneratorSettings.synopsis = VariableUtils.GetVariable(Variables.Synopsis);
            GeneratorSettings.version = VariableUtils.GetVariable(Variables.Version);
            return true;
        }
        
        public static void GenerateDocument()
        {
            var result = Setup();
            if (result == false)
            {
                Environment.ExitCode = -1;
                Console.Error.WriteLine("Build canceled");
                return;
            }

            Console.WriteLine(
                "Generate document: doxygenPath={{{0}}} inputDirectory={{{1}}} outputDirectory={{{2}}} project={{{3}}} synopsis={{{4}}} version={{{5}}}",
                GeneratorSettings.doxygenPath,
                GeneratorSettings.inputDirectory,
                GeneratorSettings.outputDirectory,
                GeneratorSettings.project,
                GeneratorSettings.synopsis,
                GeneratorSettings.version
            );
            var doxygenThread = Generator.GenerateAsync();
            doxygenThread.Join();
        }

        private static class Variables
        {
            public const string DoxygenPath         = "doxygenGenerator_DOXYGEN_PATH";
            public const string InputDirectory      = "doxygenGenerator_INPUT_DIRECTORY";
            public const string OutputDirectory     = "doxygenGenerator_OUTPUT_DIRECTORY";
            public const string Project             = "doxygenGenerator_PROJECT";
            public const string Synopsis            = "doxygenGenerator_SYNOPSIS";
            public const string Version             = "doxygenGenerator_VERSION";
        }
    }
}