using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ExeOpen
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("exe_names.txt"))
            {
                string[] filenames = File.ReadAllLines("exe_names.txt");

                var selectedId = 0;
                if (filenames.Length > 1)
                {
                    bool selectionSuccess = false;
                    while (!selectionSuccess)
                    {
                        int count = 0;
                        foreach (string filename in filenames)
                        {
                            Console.WriteLine($"{count + 1} - {filename.Trim().Split('|')[0]}");
                            count++;
                        }

                        var selected = Console.ReadLine();

                        if (int.TryParse(selected, out selectedId))
                        {
                            if (selectedId > 0 && selectedId <= filenames.Length)
                            {
                                selectionSuccess = true;
                            }
                        }

                        if (!selectionSuccess)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Entry! Try another: ");
                            Console.WriteLine();
                        }
                    }
                }

                try
                {
                    string[] filename = filenames[selectedId - 1].Trim().Split('|');
                    string arguments = filename.Length > 2 ? filename[2] : "";

                    Process.Start(filename[1], $"{arguments.Trim()} {string.Join("", args)}");
                }
                catch { }
            }
        }
    }
}
