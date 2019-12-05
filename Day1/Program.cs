using System;
using System.IO;

namespace Day1Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool partTwo = true;
            string[] lines = ReadFile("./input.txt", '\n');
            float fuelCounter = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                float fuelNeededForModule = CalculateFuelNeeded(float.Parse(lines[i]));

                if(partTwo)
                {
                    float fuelNeededForFuel = CalculateFuelNeeded(fuelNeededForModule);

                    while (fuelNeededForFuel > 0)
                    {
                        fuelCounter += fuelNeededForFuel;
                        fuelNeededForFuel = CalculateFuelNeeded(fuelNeededForFuel);
                    }
                }

                fuelCounter += fuelNeededForModule;
            }


            Console.WriteLine("Quantité de carburante nécessaire: " + fuelCounter);
        }

        public static int CalculateFuelNeeded(float mass)
        {
            return (int)Math.Floor(mass / 3f) - 2;
        }

        public static string[] ReadFile(string path, char separator)
        {
            StreamReader reader = new StreamReader(path);

            string file = reader.ReadToEnd();

            string[] lines = file.Split(separator);

            return lines;
        }
    }
}
