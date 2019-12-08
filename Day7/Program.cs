using System;
using System.Collections.Generic;

namespace Day7
{
    class Program
    {
        const int END_CODE = 99;
        const int ADD_CODE = 1;
        const int MULTIPLY_CODE = 2;
        const int INPUT_CODE = 3;
        const int OUTPUT_CODE = 4;
        const int JUMP_IF_TRUE_CODE = 5;
        const int JUMP_IF_FALSE_CODE = 6;
        const int LESS_THAN_CODE = 7;
        const int EQUALS_CODE = 8;

        static void Main(string[] args)
        {
            string[] program = ReadFile("./input.txt", ',');

            int biggest = int.MinValue;

            for (int one = 0; one < 5; one++)
            {
                for (int two = 0; two < 5; two++)
                {
                    for (int three = 0; three < 5; three++)
                    {
                        for (int four = 0; four < 5; four++)
                        {
                            for (int five = 0; five < 5; five++)
                            {
                                //This is trash but hey it works and I dont have enough time to optimize it
                                if (one == two || one == three || one == four || one == five || two == three || two == four || two == five || three == four || three == five || four == five)
                                {
 
                                }
                                else
                                {
                                    int output = RunComputer(program, five, RunComputer(program, four, RunComputer(program, three, RunComputer(program, two, RunComputer(program, one, 0)))));

                                    if (output > biggest)
                                    {
                                        biggest = output;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Biggest: "+biggest);

            //Order
        }




        public static int RunComputer(string[] program, int input1, int input2)
        {
            //Reading program
            int[] intCodes = new int[program.Length];
            for (int i = 0; i < program.Length; i++)
            {
                intCodes[i] = int.Parse(program[i]);
            }

            //Executing
            int position = 0;
            int output = 0;
            while (intCodes[position] != END_CODE)
            {
                string code = intCodes[position].ToString();
                int opCode;
                int[] param = new int[3] { 0, 0, 0 };
                if (code.Length < 2) opCode = int.Parse(code);
                else
                {
                    opCode = int.Parse(code.Substring(code.Length - 2, 2));
                    for (int i = 0; i < param.Length; i++)
                    {
                        try
                        {
                            param[i] = int.Parse(code.Substring(code.Length - 3 - i, 1));
                        }
                        catch (Exception e) { }
                    }
                }


                int[] values = new int[3] { -1, -1, -1 };
                for (int i = 0; i < values.Length; i++)
                {
                    //Position mode
                    if (param[i] == 0)
                    {
                        values[i] = intCodes[position + 1 + i];
                    }
                    //Immediate mode
                    else
                    {
                        values[i] = position + 1 + i;
                    }
                }


                switch (opCode)
                {
                    case ADD_CODE:
                        intCodes[values[2]] = intCodes[values[0]] + intCodes[values[1]];
                        position += 4;
                        break;
                    case MULTIPLY_CODE:
                        intCodes[values[2]] = intCodes[values[0]] * intCodes[values[1]];
                        position += 4;
                        break;
                    case INPUT_CODE:
                        //I just want it to work xd
                        if(input1 != -69)
                        {
                            intCodes[values[0]] = input1;
                            input1 = -69;
                        }
                        else
                        {
                            intCodes[values[0]] = input2;
                        }
                        position += 2;
                        break;
                    case OUTPUT_CODE:
                        output = intCodes[values[0]];
                        position += 2;
                        break;
                    case JUMP_IF_TRUE_CODE:
                        if (intCodes[values[0]] != 0) position = intCodes[values[1]];
                        else position += 3;
                        break;
                    case JUMP_IF_FALSE_CODE:
                        if (intCodes[values[0]] == 0) position = intCodes[values[1]];
                        else position += 3;
                        break;
                    case LESS_THAN_CODE:
                        if (intCodes[values[0]] < intCodes[values[1]]) intCodes[values[2]] = 1;
                        else intCodes[values[2]] = 0;
                        position += 4;
                        break;
                    case EQUALS_CODE:
                        if (intCodes[values[0]] == intCodes[values[1]]) intCodes[values[2]] = 1;
                        else intCodes[values[2]] = 0;
                        position += 4;
                        break;
                }
            }

            return output;
        }

        public static string[] ReadFile(string path, char separator)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(path);

            string file = reader.ReadToEnd();

            string[] lines = file.Split(separator);

            return lines;
        }
    }
}
