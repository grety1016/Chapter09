using System;
using System.IO; // types for managing the filesystem
using static System.Console;
using static System.IO.Path;
using static System.Environment; 
using static System.IO.File;
using static System.IO.Directory;

namespace WorkWithFiles
{

    
    class Program
    {
        static void WorkWithFiles()
        {
            // define a directory path to output files
            // starting in the user' s folder
            var dir = Combine(GetFolderPath(SpecialFolder.Personal),"Code","Chapter09","OutputFiles");
            CreateDirectory(dir) ;
            // define file paths
            string textFile = Combine(dir, "Dummy.txt") ;
            string backupFile = Combine(dir, "Dummy.bak") ;
            WriteLine($"Working with: {textFile}") ;
            // check if a file exists
            WriteLine($"Does it exist? {File. Exists(textFile) }") ;
            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile) ;
            textWriter.WriteLine("Hello, C#! ") ;
            textWriter.Close() ; // close file and release resources
            WriteLine($"Does it exist? {File. Exists(textFile) }") ;
            // copy the file, and overwrite if it already exists
            File.Copy(sourceFileName: textFile,
            destFileName: backupFile, overwrite: true) ;
            WriteLine(
            $"Does {backupFile} exist? {File.Exists(backupFile) }") ;
            Write("Confirm the files exist, and then press ENTER: ") ;
            ReadLine() ;
            // delete file
            File. Delete(textFile) ;
            WriteLine($"Does it exist? {File.Exists(textFile) }") ;
            // read from the text file backup
            WriteLine($"Reading contents of {backupFile}: ") ;
            StreamReader textReader = File.OpenText(backupFile) ;
            WriteLine(textReader.ReadToEnd() ) ;
            textReader.Close() ;

            // Managing paths
            WriteLine($"Folder Name: {GetDirectoryName(textFile) }") ;
            WriteLine($"File Name: {GetFileName(textFile) }") ;
            WriteLine("File Name without Extension: {0}",
            GetFileNameWithoutExtension(textFile) ) ;
            WriteLine($"File Extension: {GetExtension(textFile) }") ;
            WriteLine($"Random File Name: {GetRandomFileName() }") ;
            WriteLine($"Temporary File Name: {GetTempFileName() }") ;
        }
        static void Main(string[] args)
        {
            WorkWithFiles();
        }
    }
}
