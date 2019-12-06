using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Day6
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] input = ReadFile("./input.txt", '\n');
            List<string> names = new List<string>();
            Dictionary<string, HashSet<string>> directOrbitConnections = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> indirectOrbitConnections = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Replace("\r", "");
                string[] orbitNames = input[i].Split(')');

                if (!names.Contains(orbitNames[0])) names.Add(orbitNames[0]);
                if (!names.Contains(orbitNames[1])) names.Add(orbitNames[1]);

                if (!directOrbitConnections.ContainsKey(orbitNames[0]))
                {
                    directOrbitConnections.Add(orbitNames[0], new HashSet<string>());
                }

                HashSet<string> hash;
                directOrbitConnections.TryGetValue(orbitNames[0], out hash);
                hash.Add(orbitNames[1]);
            }

            int cpt = 0;
            string pointA;
            string pointB;
            //Checking for indirect connection
            foreach (string name in names)
            {
                cpt += CountIndirectOrbitConnections(ref directOrbitConnections, name);

                HashSet<string> hash;
                directOrbitConnections.TryGetValue(name, out hash);

                if(hash != null)
                {
                    foreach (string key in hash)
                    {
                        if (key == "YOU")
                        {
                            pointA = name;
                        }
                        else if (key == "SAN")
                        {
                            pointB = name;
                        }
                    }
                }
            }



            //List<string> test = GetIndirectOrbitConnections(ref directOrbitConnections, "COM");


            Console.WriteLine("Done");
        }


        public static int FindingPath(ref Dictionary<string, HashSet<string>> directOrbitConnections, List<string> names, string pointA, string pointB)
        {
            int steps = 0;

            HashSet<string> hash;
            directOrbitConnections.TryGetValue(pointA, out hash);

                if (hash != null)
                {
                    foreach (string key in hash)
                    {
                    }
                }
                return 0;
        }


        //public static List<string> GetIndirectOrbitConnections(ref Dictionary<string, HashSet<string>> directOrbitConnections, string obj)
        //{
        //    List<string> indirectConnections = new List<string>();

        //    HashSet<string> hash;
        //    directOrbitConnections.TryGetValue(obj, out hash);

        //    if (directOrbitConnections.ContainsKey(obj) && directOrbitConnections.ContainsValue(hash))
        //    {
        //        if (hash != null)
        //        {
        //            foreach (string name in hash)
        //            {
        //                foreach(string connection in GetIndirectOrbitConnections(ref directOrbitConnections, name))
        //                {
        //                    indirectConnections.Add(connection);
        //                }
        //            }
        //        }
        //    }

        //    return indirectConnections;
        //}


        public static int CountIndirectOrbitConnections(ref Dictionary<string, HashSet<string>> directOrbitConnections, string obj)
        {
            int cpt = 0;

            HashSet<string> hash;
            directOrbitConnections.TryGetValue(obj, out hash);

            if (directOrbitConnections.ContainsKey(obj) && directOrbitConnections.ContainsValue(hash))
            {
                if (hash != null)
                {
                    foreach (string name in hash)
                    {
                        cpt++;
                        cpt += CountIndirectOrbitConnections(ref directOrbitConnections, name);
                    }
                }
            }

            return cpt;
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
