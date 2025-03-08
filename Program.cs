using System.IO;
using Microsoft.Win32;
using POO_CSharp_Exercicio_P22_E1.Entities;


namespace POO_CSharp_Exercicio_P22_E1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
//            Problema exemplo
//            Um site de internet registra um log de acessos dos usuários.Umregistro de log consiste no nome de usuário e o instante em que ousuário acessou o site no padrão ISO 8601, separados por espaço,
//            conforme exemplo. Fazer um programa que leia o log de acessos apartir de um arquivo, e daí informe quantos usuários distintosacessaram o site.

            HashSet<LogRecord> set = new HashSet<LogRecord>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(' ');
                        string name = line[0];
                        DateTime instant = DateTime.Parse(line[1]);
                        set.Add(new LogRecord { Username = name, Instant = instant });
                    }
                    Console.WriteLine("Total users: " + set.Count);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}