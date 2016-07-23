using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOutOperationApp
{
    using System.IO;
    using System.Threading;
    class WorkWithFileData
    {
        string FileName { get; set; }
        string CurrentLocation { get; set; }

        public WorkWithFileData(string filePath)
        {
            FileInfo _fileInfo = new FileInfo(filePath);
            FileName = _fileInfo.Name;
            CurrentLocation = _fileInfo.DirectoryName;

        }

       async public void WriteToFile()
        {
            byte[] someString = Encoding.ASCII.GetBytes("Hellow InputOutputLibrary \n");

            using (FileStream flStream = 
                 File.Open(CurrentLocation+FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                flStream.Seek(0, SeekOrigin.End);
                await flStream.WriteAsync(someString, 0, someString.Length);
            }

            Console.WriteLine("WriteToFile compleated!");
        }


        async public void ReadFromFile()
        {
            byte[] someString = null;
            using (FileStream _fileStream = File.Open(CurrentLocation + FileName, FileMode.Open))
            {
                someString = new byte[_fileStream.Length];
                await _fileStream.ReadAsync(someString, 0, (int)_fileStream.Length);
            }
            Console.WriteLine("ReadFromFile compleated!");
            Console.WriteLine(Encoding.ASCII.GetString(someString));
        }

        public void SomeMemoryStream()
        {
            Console.WriteLine(new string('*', 50));

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] someStreang = Encoding.ASCII.GetBytes("Simple MemoryStream");
                ms.Write(someStreang, 0, someStreang.Length);

                Console.WriteLine("MemoryStream finish");               
            }
        }

        public void PrintFileInfo()
        {
            Console.WriteLine("name: {0}, path: {1}",FileName,CurrentLocation);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            WorkWithFileData _workWithFileData = new WorkWithFileData(@"E:\TextFile1.txt");

            _workWithFileData.PrintFileInfo();

            Console.WriteLine("BeginAsyncOperation");

            _workWithFileData.WriteToFile();

            Thread.Sleep(1000);
            Console.WriteLine(new string('-', 50));

            _workWithFileData.ReadFromFile();

            Thread th = new Thread(_workWithFileData.SomeMemoryStream);
            th.Start();

            Console.ReadKey();
        }
    }
}
