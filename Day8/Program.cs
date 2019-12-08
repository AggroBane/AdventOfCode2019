using System;
using System.IO;

namespace Day8
{
    class Program
    {
        const int WIDTH = 25;
        const int HEIGHT = 6;

        const int BLACK = 0;
        const int WHITE = 1;
        const int TRANSPARENT = 2;

        static void Main(string[] args)
        {
            string input = ReadFile("./input.txt");
            int nbOfLayer = input.Length / (WIDTH * HEIGHT);

            //Part 1
            int smallestNbZero = int.MaxValue;
            int theNbOfOne = 0;
            int theNbOfTwo = 0;

            //Part 2
            int[,] finalImage = new int[HEIGHT, WIDTH];
            for (int j = 0; j < HEIGHT; j++)
            {
                for (int k = 0; k < WIDTH; k++)
                {
                    //Initializing every value with transparent
                    finalImage[j, k] = TRANSPARENT;
                }
            }


            //Looping through every pixel of every layer
            for (int i = 0; i < nbOfLayer; i++)
            {
                int nbOfZero = 0;
                int nbOfOne = 0;
                int nbOfTwo = 0;
                for (int j = 0; j < HEIGHT; j++)
                {
                    for (int k = 0; k < WIDTH; k++)
                    {
                        int currentPixel = (int)Char.GetNumericValue(input[i * WIDTH * HEIGHT + j * WIDTH + k]);

                        //Part 1
                        switch (currentPixel)
                        {
                            case 0:
                                nbOfZero++;
                                break;
                            case 1:
                                nbOfOne++;
                                break;
                            case 2:
                                nbOfTwo++;
                                break;
                        }

                        //Part 2
                        if (finalImage[j, k] == TRANSPARENT)
                        {
                            finalImage[j, k] = currentPixel;
                        }
                    }
                }

                //Checking for fewest number of zero
                if (nbOfZero < smallestNbZero)
                {
                    smallestNbZero = nbOfZero;
                    theNbOfOne = nbOfOne;
                    theNbOfTwo = nbOfTwo;
                }
            }

            //Printing for part 1
            Console.WriteLine("=========Part 1=========");
            Console.WriteLine("Number of 1 digits multiplied by the number of 2 digits: "+theNbOfOne*theNbOfTwo+"\n");

            Console.WriteLine("=========Part 2=========");
            //Printing for part 2
            for (int j = 0; j < HEIGHT; j++)
            {
                for (int k = 0; k < WIDTH; k++)
                {
                    if (finalImage[j, k] == WHITE) Console.Write(finalImage[j, k]);
                    else Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

        public static string ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);

            string file = reader.ReadToEnd();

            return file;
        }
    }
}
