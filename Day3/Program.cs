using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading inputs
            string[] inputs = ReadFile("./input.txt", '\n');
            string[] strWire1 = inputs[0].Split(',');
            string[] strWire2 = inputs[1].Split(',');


            Traject wire1 = new Traject();
            Traject wire2 = new Traject();

            //Making both traject
            for (int i = 0; i < strWire1.Length; i++)
            {
                MakeMove(wire1, strWire1[i].ToCharArray()[0], int.Parse(strWire1[i].Remove(0, 1)));
            }

            for (int i = 0; i < strWire2.Length; i++)
            {
                MakeMove(wire2, strWire2[i].ToCharArray()[0], int.Parse(strWire2[i].Remove(0, 1)));
            }


            //Checking intersections
            List<Move> intersections = wire1.GetIntersections(wire2);
            List<Move> listShortestStep = new List<Move>();
            int shortestSteps = 9999999;



            foreach (Move m in intersections)
            {
                if (m.X1 != 0 && m.Y1 != 0)
                {
                    int totalWire1 = 0;
                    foreach (Move m1 in wire1.Moves)
                    {
                        if (m1.X1 == m.X2 && m1.Y1 == m.Y2) break;

                        switch (m1.Direction)
                        {
                            case 'U':
                                totalWire1 += m1.Y2 - m1.Y1;
                                break;
                            case 'D':
                                totalWire1 += m1.Y1 - m1.Y2;
                                break;
                            case 'R':
                                totalWire1 += m1.X2 - m1.X1;
                                break;
                            case 'L':
                                totalWire1 += m1.X1 - m1.X2;
                                break;
                        }
                    }

                    int totalWire2 = 0;
                    foreach (Move m1 in wire2.Moves)
                    {
                        if (m1.X1 == m.trashx && m1.Y1 == m.trashy) break;

                        switch (m1.Direction)
                        {
                            case 'U':
                                totalWire2 += m1.Y2 - m1.Y1;
                                break;
                            case 'D':
                                totalWire2 += m1.Y1 - m1.Y2;
                                break;
                            case 'R':
                                totalWire2 += m1.X2 - m1.X1;
                                break;
                            case 'L':
                                totalWire2 += m1.X1 - m1.X2;
                                break;
                        }
                    }

                    if (totalWire1 + totalWire2 < shortestSteps)
                    {
                        shortestSteps = totalWire1 + totalWire2;
                        listShortestStep.Clear();
                        listShortestStep.Add(m);
                    }
                    else if (totalWire1 + totalWire2 == shortestSteps)
                    {
                        listShortestStep.Add(m);
                    }
                }

            }

            int closest = 99999;
            foreach (Move m in listShortestStep)
            {
                int cur = Math.Abs(0 - m.X1) + Math.Abs(0 - m.Y1);
                if (cur < closest && cur > 0)
                {
                    closest = cur;
                }
            }

            Console.WriteLine("Shortest distance: "+ shortestSteps);
            Console.ReadKey();
            //Answer is 731
            //154610 too high
            //304239
            //157109
            //157109
            //14768 too high
            //14768
            //5627
        }


        public static void MakeMove(Traject traj, char direction, int moveLenght)
        {
            Move theMove = null;

            switch (direction)
            {
                case 'U':
                    theMove = new Move(traj.CurrentX, traj.CurrentY, traj.CurrentX, traj.CurrentY + moveLenght, direction);
                    break;
                case 'D':
                    theMove = new Move(traj.CurrentX, traj.CurrentY, traj.CurrentX, traj.CurrentY - moveLenght, direction);
                    break;
                case 'R':
                    theMove = new Move(traj.CurrentX, traj.CurrentY, traj.CurrentX + moveLenght, traj.CurrentY, direction);
                    break;
                case 'L':
                    theMove = new Move(traj.CurrentX, traj.CurrentY, traj.CurrentX - moveLenght, traj.CurrentY, direction);
                    break;
                default:
                    throw new ArgumentException("Direction is invalid.");
            }

            traj.addMove(theMove);
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
