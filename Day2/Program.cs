using System;
using System.IO;

namespace Day2
{
    class Program
    {
        const bool partTwo = false;
        const int END_CODE = 99;
        const int ADD_CODE = 1;
        const int MULTIPLY_CODE = 2;

        const int SEARCHED_OUTPUT = 19690720;

        static void Main(string[] args)
        {
            //LECTURE
            string[] strIntCodes = ReadFile("./input.txt", ',');
            int[] intCodes = new int[strIntCodes.Length];
            int[] originalIntCodes = new int[intCodes.Length];

            for (int i = 0; i < strIntCodes.Length; i++)
            {
                intCodes[i] = int.Parse(strIntCodes[i]);
                originalIntCodes[i] = intCodes[i];
            }


            //PARTIE 1
            if(!partTwo)
            {
                intCodes[1] = 12;
                intCodes[2] = 2;

                RunComputer(intCodes);

                Console.WriteLine("Value at position 0: " + intCodes[0]);
            }
            //PARTIE 2
            else
            {
                int realNoun = 0;
                int realVerb = 0;

                //Parcours de toutes les valeurs possible
                bool found = false;
                for (int noun = 0; noun < 100 && !found; noun++)
                {
                    for (int verb = 0; verb < 100 && !found; verb++)
                    {
                        intCodes[1] = noun;
                        intCodes[2] = verb;

                        RunComputer(intCodes);

                        //Si le nombre a été trouvé
                        if (intCodes[0] == SEARCHED_OUTPUT)
                        {
                            realNoun = noun;
                            realVerb = verb;
                            found = true;
                        }
                        else
                        {
                            //Sinon -> Réinitialisation de la mémoire et on recommence
                            for (int i = 0; i < originalIntCodes.Length; i++)
                            {
                                intCodes[i] = originalIntCodes[i];
                            }
                        }
                    }
                }

                Console.WriteLine("Noun: " + realNoun + "\nVerb: " + realVerb);
                Console.WriteLine("Answer: " + (100 * realNoun + realVerb));
            }
        }

        public static void RunComputer(int[] intCodes)
        {
            int position = 0;
            while (intCodes[position] != END_CODE)
            {
                switch (intCodes[position])
                {
                    case ADD_CODE:
                        intCodes[intCodes[position + 3]] = intCodes[intCodes[position + 1]] + intCodes[intCodes[position + 2]];
                        break;
                    case MULTIPLY_CODE:
                        intCodes[intCodes[position + 3]] = intCodes[intCodes[position + 1]] * intCodes[intCodes[position + 2]];
                        break;
                }
                position += 4;
            }
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
