using System;
using System.Linq;

namespace DoxygenGenerator
{
    public static class VariableUtils
    {
        internal static string GetVariable(string name)
        {
            var commandLineVariable = Environment.GetCommandLineArgs().FirstOrDefault(x => x.StartsWith($"{name}="));
            if (commandLineVariable != null)
                return commandLineVariable.Substring(name.Length + 1, commandLineVariable.Length - (name.Length + 1)).Replace("'", "").Replace("\"", "");

            try
            {
                return Environment.GetEnvironmentVariable(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        
        internal static bool EnvironmentVariablesMissing(string[] requiredVariables)
        {
            var missing = false;
            foreach (var requiredVariable in requiredVariables)
            {
                var value = GetVariable(requiredVariable);
                if (value == null)
                {
                    UnityEngine.Debug.LogError("BUILD ERROR: Required Environment Variable is not set: " + requiredVariable);
                    Console.Error.Write("BUILD ERROR: Required Environment Variable is not set: ");
                    Console.Error.WriteLine(requiredVariable);
                    missing = true;
                }
            }

            return missing;
        }
    }
}