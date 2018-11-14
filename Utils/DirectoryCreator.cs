using System;
using System.IO;

namespace RandomGraphGenerator.Utils
{
    public class DirectoryCreator
    {
        public bool SafelyCreate(string outputDir)
        {
            if (Directory.Exists(outputDir))
            {
                Console.Write($"Directory {outputDir} already exists. Do you want to override it? [y/n] ");
                var response = Console.ReadLine();
                if (response == "y" || response == "Y")
                {
                    Console.WriteLine($"Removing {outputDir} directory.");
                    try
                    {
                        Directory.Delete(outputDir, recursive : true);
                        return SafelyCreate(outputDir);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error occured while removing {outputDir} directory.");
                        Console.WriteLine(ex.StackTrace);

                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(outputDir);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occured while creating directory {outputDir}");
                    Console.WriteLine(ex.StackTrace);

                    return false;
                }
            }
        }
    }
}