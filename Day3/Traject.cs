using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    class Traject
    {
        private List<Move> moves;
        private int currentX, currentY, currentStep;

        public int CurrentX { get { return currentX; } }
        public int CurrentY { get { return currentY; } }

        public List<Move> Moves { get { return moves; } }

        public Traject()
        {
            moves = new List<Move>();
            currentX = 0;
            currentY = 0;
        }

        public void addMove(Move moveToAdd)
        {
            if(moves != null)
            {
                moves.Add(moveToAdd);

                currentX = moveToAdd.X2;
                currentY = moveToAdd.Y2;
            }
        }

        public List<Move> GetIntersections(Traject traject)
        {
            List < Move > intersects = new List<Move>();
            
            foreach(Move m1 in this.moves)
            {
                foreach(Move m2 in traject.moves)
                {
                    //Droite/haut
                    if(m1.X1 <= m2.X1 && m1.X2 >= m2.X1 &&
                        m2.Y1 <= m1.Y1 && m2.Y2 >= m1.Y1)
                    {
                        intersects.Add(new Move(m2.X1, m1.Y1, m1.X1, m1.Y1, 'd', m2.X1, m2.Y1));
                    }
                    //Droite/bas
                    else if(m1.X1 <= m2.X1 && m1.X2 >= m2.X1 && m2.Y1 >= m1.Y1 && m2.Y2 <= m1.Y1)
                    {
                        intersects.Add(new Move(m2.X1, m1.Y1, m1.X1, m1.Y1, 'd', m2.X1, m2.Y1));
                    }
                    //Gauche/haut
                    else if(m1.X2 <= m2.X1 && m1.X1 >= m2.X1 && m2.Y1 <= m1.Y1 && m2.Y2 >= m1.Y1)
                    {
                        intersects.Add(new Move(m2.X1, m1.Y1, m1.X1, m1.Y1, 'd', m2.X1, m2.Y1));
                    }
                    //Gauche/bas
                    else if(m1.X2 <= m2.X1 && m1.X1 >= m2.X1 && m2.Y1 >= m1.Y1 && m2.Y2 <= m1.Y1)
                    {
                        intersects.Add(new Move(m2.X1, m1.Y1, m1.X1, m1.Y1, 'd', m2.X1, m2.Y1));
                    }
                }
            }

            return intersects;
        }
    }
}
