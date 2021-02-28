﻿using System;
using System.IO;

namespace CodegenCS.DbSchema.Extractor
{
    class Program
    {
        // Helpers to get the location of the current CS file
        public static string GetScriptPath([System.Runtime.CompilerServices.CallerFilePath] string path = null) => path;
        public static string GetScriptFolder([System.Runtime.CompilerServices.CallerFilePath] string path = null) => Path.GetDirectoryName(path);

        static void Main(string[] args)
        {
            #region Command-Line Arguments
            var argsParser = new Helpers.CommandLineArgsParser(args);
            if (argsParser["?"] != null || argsParser["help"] != null)
            {
                ShowUsage();
                Environment.Exit(0);
            }
            #endregion

            //string outputJsonSchema = Path.GetFullPath(Path.Combine(GetScriptFolder(), @".\AdventureWorksSchema.json"));
            var generator = new SimplePOCOGenerator();
            generator.InputJsonSchema = argsParser["input"];
            generator.TargetFolder = argsParser["targetFolder"];
            generator.Namespace = argsParser["namespace"];


            generator.Generate();
        }

        static void ShowUsage()
        {
            Console.WriteLine(string.Format("Usage: {0} [/input=jsonschema] [/targetfolder=folder] [/namespace=namespace]", System.AppDomain.CurrentDomain.FriendlyName));
        }

    }
}
