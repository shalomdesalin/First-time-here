using System;
namespace ConsoleApp2
{
    class Program
    {
        public static string[,] Plyer1Board = new string[11, 11];
        public static string[,] GameBoard = new string[11, 11];
        public static string pos = " |";
        public static string ship = "$|";
        public static string hit = "H|";
        public static string miss = "M|";
        public static void ResetZero()
       ////////////////מאתחל את לוח הצבת הצוללת בערכים ריקים
        {
            int numH = 65;
            int numL = 97;
            
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Plyer1Board[i, j] = pos;
                }
            }
            ///// שורה עליונה
            for (int i = 1; i < 11; i++)
            {
                string tav = Convert.ToChar(numH) + "|";
                Plyer1Board[0, i] = tav;
                numH++;
            }
            /////שורה תחתונה
            numH = 65;
            for (int i = 1; i < 11; i++)
            {
                string tav = Convert.ToChar(numH) + "|";
                Plyer1Board[10, i] = tav;
                numH++;
            }
            //////עמודה שמאלית
            for (int i = 1; i < 11; i++)
            {
                string tav = Convert.ToChar(numL) + "|";
                Plyer1Board[i, 0] = tav;
                numL++;
            }
            numL = 97;
            //////עמודה ימנית
            for (int i = 1; i < 11; i++)
            {
                string tav = Convert.ToChar(numL)+"";
                Plyer1Board[i, 10] = tav;
                numL++;
            }
            /////נקודת 0,0
            Plyer1Board[0, 0] = "X|";
            /////1נקודת 0,0
            Plyer1Board[10, 0] = "X|";
            /////נקודת 0,10
            Plyer1Board[0,10] = "X";
            /////1נקודת 0,10
            Plyer1Board[10, 10] = "X";
        }
        static void ResetZeroGameBoard()
        ////////////מאתחל את לוח המשחק בערכים ריקים
        {
            int numH = 65;
            int numL = 97;
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    GameBoard[i, j] = pos;
                }
            }
            ///// שורה עליונה
            for (int i = 1; i < 11; i++)
            {
                string tav = Convert.ToChar(numH) + "|";
                GameBoard[0, i] = tav;
                numH++;
            }
            /////שורה תחתונה
            numH = 65;
            for (int i = 1; i < 11; i++)
            {
                string tav = Convert.ToChar(numH) + "|";
                GameBoard[10, i] = tav;
                numH++;
            }
            //////עמודה שמאלית
            for (int i = 1; i < 11; i++)
            {
                string tav = Convert.ToChar(numL) + "|";
                GameBoard[i, 0] = tav;
                numL++;
            }
            numL = 97;
            //////עמודה ימנית
            for (int i = 1; i < 11; i++)
            {
                string tav = Convert.ToChar(numL) + "";
                GameBoard[i, 10] = tav;
                numL++;
            }
            /////נקודת 0,0
            GameBoard[0, 0] = "X|";
            /////1נקודת 0,0
            GameBoard[10, 0] = "X|";
            /////נקודת 0,10
            GameBoard[0, 10] = "X";
            /////1נקודת 0,10
            GameBoard[10, 10] = "X";
        }
        static void StartUP()
        {
            Console.Title = "Battleship_shalom_luzan_hyeal";

            Console.WriteLine("Welcome to Battleship.\n\nPress Enter to continue.");
            Console.ReadLine();
        }
        static void drawBoard()
      ///////////////מדפיס לוח משחק כדי להציב צוללות
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(Plyer1Board[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void drawGameBoard()
       ///////////////מדפיס את לוח המשחק
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(GameBoard[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Instructions()
       //////////////////מציג את ההוראות למשחק
        {
            Console.WriteLine("There are 6 submarines scattered on the board " +
                "\n 2 two - cell size " +
                "\n 2 three - cell size " +
                "\n 1 four - cell size " +
                "\n 1 five - cell size " +
                "\n To claim a submarine you must hit all the cells of that submarine " +
                "\n Select a cell by the letters");
        }    
        static char lowcase()
      ////////////////קולט תו ובודק האם הוא אות קטנה
        {
            char lowcase;
            Console.WriteLine("low case");
            do
            {
                lowcase = Console.ReadLine()[0];
                if (lowcase < 'a' || lowcase > 'i')
                    Console.WriteLine("worng input");
            }
            while (lowcase < 'a' || lowcase > 'i');
            return lowcase;
        }
        static char uprcase()
       ///////////////קולט תו ובודק באם הוא אות גדולה
        {
            char uprcase;
            Console.WriteLine("upr case");
            do
            {
                uprcase = Console.ReadLine()[0];
                if (uprcase < 'A' || uprcase > 'I')
                    Console.WriteLine("worng input");
            }
            while (uprcase < 'A' || uprcase > 'I');
            return uprcase;
        }
        static char dire()
       /////////////בודק לאיזה כיוון המשתמש רוצה לכוון את הצוללת
        {
            char dire;
            Console.WriteLine("Up(U) and down(D) to the right(R) or left(L) where to go next enter character ");
            do
            {
                dire = Console.ReadLine()[0];
                if (dire != 'U' && dire != 'D' && dire != 'R' && dire != 'L')
                    Console.WriteLine("worng input");
            }
            while (dire != 'U' && dire != 'D' && dire != 'R' && dire != 'L');
            return dire;
        }
        static Boolean chack(int x,int y)
        //////////////בודק האם ניתן להציב צוללת לפי מיקום על הלוח
        {
            if (Plyer1Board[x, y] == pos && Plyer1Board[x + 1, y] !=ship
                && Plyer1Board[x - 1, y] != ship && Plyer1Board[x, y + 1] != ship
                && Plyer1Board[x, y - 1] != ship && Plyer1Board[x-1, y - 1] != ship && Plyer1Board[x+1, y+ 1] != ship)
                return true;
            else return false;
        }
        static void Lifeboat1(char l, char u, char d)
        ////////////מציב צוללת 2 תאים על הלוח
        {
            int s = 3;
            int i;
            int cordL = 0;
            int cordU = 0;
            if (d == 'D')
                cordL = +1;
            if (d == 'U')
                cordL = -1;
            if (d == 'R')
                cordU = +1;
            if (d == 'L')
                cordU = -1;
            int x = Convert.ToInt32(l) - 96;
            int y = Convert.ToInt32(u) - 64;
            i = 1;
            do
            {
                if (Plyer1Board[x + cordL*i, y + cordU*i] != pos|| chack(x,y)== false || chack(x + cordL*1, y + cordU*1 ) == false)
                {
                    Console.Clear();
                    drawBoard();
                    Console.WriteLine("Try to place again");
                    Lifeboat1(lowcase(), uprcase(), dire());
                }
                else 
                    do {
                        Plyer1Board[x, y] = Plyer1Board[x, y].Replace(pos, "$|");
                        x = x + cordL;
                        y = y + cordU;
                        i++;
                    } while (i < s &&  Plyer1Board[x , y ] == pos);
            } while (chack(x, y) == true);
        } 
        static void Lifeboat2(char l, char u, char d)
     ////////////מציב צוללת 2 תאים על הלוח
        {
            int s = 3;
            int i;
            int cordL = 0;
            int cordU = 0;
            if (d == 'D')
                cordL = +1;
            if (d == 'U')
                cordL = -1;
            if (d == 'R')
                cordU = +1;
            if (d == 'L')
                cordU = -1; 
            int x = Convert.ToInt32(l) - 96;
            int y = Convert.ToInt32(u) - 64;
            i = 1;
            do
            {
                if (Plyer1Board[x + cordL * i, y + cordU * i] != pos || chack(x, y) == false || chack(x + cordL * 1, y + cordU * 1) == false)
                {
                    Console.Clear();
                    drawBoard();
                    Console.WriteLine("Try to place again");
                    Lifeboat2(lowcase(), uprcase(), dire());
                }
                else
                    do
                    {
                        Plyer1Board[x, y] = Plyer1Board[x, y].Replace(pos, "$|");
                        x = x + cordL;
                        y = y + cordU;
                        i++;
                    } while (i < s && Plyer1Board[x, y] == pos);
            } while (chack(x, y) == true);
        }
        static void CruiseBoat1(char l, char u, char d)
       //////////////מציב צוללת 3 תאים על הלוח
        {
            int s = 4;
            int i;
            int cordL = 0;
            int cordU = 0;
            if (d == 'D')
                cordL = +1;
            if (d == 'U')
                cordL = -1;
            if (d == 'R')
                cordU = +1;
            if (d == 'L')
                cordU = -1; int x = Convert.ToInt32(l) - 96;
            int y = Convert.ToInt32(u) - 64;
            i = 1;
            do
            {
                if (Plyer1Board[x + cordL * i, y + cordU * i] != pos || chack(x, y) == false || chack(x + cordL * 1, y + cordU * 1) == false
                    || chack(x + cordL * 2, y + cordU * 2) == false)
                {
                    Console.Clear();
                    drawBoard();
                    Console.WriteLine("Try to place again");
                    CruiseBoat1(lowcase(), uprcase(), dire());
                }
                else
                    do
                    {
                        Plyer1Board[x, y] = Plyer1Board[x, y].Replace(pos, "$|");
                        x = x + cordL;
                        y = y + cordU;
                        i++;
                    } while (i < s && Plyer1Board[x, y] == pos);
            } while (chack(x, y) == true);
        }
        static void CruiseBoat2(char l, char u, char d)
       /////////////מציב צוללת 3 תאים על הלוח
        {
            int s = 4;
            int i;
            int cordL = 0;
            int cordU = 0;
            if (d == 'D')
                cordL = +1;
            if (d == 'U')
                cordL = -1;
            if (d == 'R')
                cordU = +1;
            if (d == 'L')
                cordU = -1; int x = Convert.ToInt32(l) - 96;
            int y = Convert.ToInt32(u) - 64;
            i = 1;
            do
            {
                if (Plyer1Board[x + cordL * i, y + cordU * i] != pos || chack(x, y) == false || chack(x + cordL * 1, y + cordU * 1) == false
                    || chack(x + cordL * 2, y + cordU * 2) == false)
                {
                    Console.Clear();
                    drawBoard();
                    Console.WriteLine("Try to place again");
                    CruiseBoat2(lowcase(), uprcase(), dire());
                }
                else
                    do
                    {
                        Plyer1Board[x, y] = Plyer1Board[x, y].Replace(pos, "$|");
                        x = x + cordL;
                        y = y + cordU;
                        i++;
                    } while (i < s && Plyer1Board[x, y] == pos);
            } while (chack(x, y) == true);
        }
        static void shipyard(char l, char u, char d)
       ///////////////מציב צוללת 4 תאים על הלוח
        {
            int s = 4;
            int i;
            int cordL = 0;
            int cordU = 0;
            if (d == 'D')
                cordL = +1;
            if (d == 'U')
                cordL = -1;
            if (d == 'R')
                cordU = +1;
            if (d == 'L')
                cordU = -1; int x = Convert.ToInt32(l) - 96;
            int y = Convert.ToInt32(u) - 64;
            i = 0;
            do
            {
                if (Plyer1Board[x + cordL * i, y + cordU * i] != pos || chack(x, y) == false || chack(x + cordL * 1, y + cordU * 1) == false
                    || chack(x + cordL * 2, y + cordU * 2) == false || chack(x + cordL * 3, y + cordU * 3) == false)
                {
                    Console.Clear();
                    drawBoard();
                    Console.WriteLine("Try to place again");
                    shipyard(lowcase(), uprcase(), dire());
                }
                else
                    do
                    {
                        Plyer1Board[x, y] = Plyer1Board[x, y].Replace(pos, "$|");
                        x = x + cordL;
                        y = y + cordU;
                        i++;
                    } while (i < s && Plyer1Board[x , y ] == pos);
            } while (chack(x, y) == true);
        }
        static void AircraftPilot(char l, char u, char d)
      //////////מציב צוללת 5 תאים על הלוח
        {
            int s = 5;
            int i;
            int cordL = 0;
            int cordU = 0;
            if (d == 'D')
                cordL = +1;
            if (d == 'U')
                cordL = -1;
            if (d == 'R')
                cordU = +1;
            if (d == 'L')
                cordU = -1; int x = Convert.ToInt32(l) - 96;
            int y = Convert.ToInt32(u) - 64;
            i = 0;
            do
            {
                if (Plyer1Board[x + cordL * i, y + cordU * i] != pos || chack(x, y) == false || chack(x + cordL * 1, y + cordU * 1) == false
                    || chack(x + cordL * 2, y + cordU * 2) == false || chack(x + cordL * 3, y + cordU * 3) == false || chack(x + cordL * 4, y + cordU * 4) == false)
                {
                    Console.Clear();
                    drawBoard();
                    Console.WriteLine("Try to place again");
                    AircraftPilot(lowcase(), uprcase(), dire());
                }
                else
                    do
                    {
                        Plyer1Board[x, y] = Plyer1Board[x, y].Replace(pos, "$|");
                        x = x + cordL;
                        y = y + cordU;
                        i++;
                    } while (i < s && Plyer1Board[x, y] == pos);
            } while (chack(x, y) == true);
        }
        static void Hit(char x,char y)
       //////מסמן על הלוח האם פגענו או לא פגענו
        {
            int x1 = Convert.ToInt32(x) - 96;
            int y1 = Convert.ToInt32(y) - 64;
            if (Plyer1Board[x1,y1]==ship)
            {
                GameBoard[x1, y1] = GameBoard[x1, y1].Replace(pos,hit);
                Plyer1Board[x1, y1]= Plyer1Board[x1, y1].Replace(ship, hit);
}
            else
            {
                GameBoard[x1, y1] = GameBoard[x1, y1].Replace(pos, miss);
                Plyer1Board[x1, y1] = Plyer1Board[x1, y1].Replace(pos,miss);
            }
        }
        static int Lifeboatcount()
        //////בודק כמה צוללות בעלות 2 תאים נפלו
        {
            int i, j;
            int Lifeboatcount = 0;
            for (j = 1; j < 10; j++)
            {
                for (i = 1; i < 8; i++)
                {
                    if (Plyer1Board[j, i - 1] != ship && Plyer1Board[j, i - 1] != hit && Plyer1Board[j, i] == hit
                        && Plyer1Board[j, i + 1] == hit && Plyer1Board[j, i + 2] != ship && Plyer1Board[j , i + 2] != hit)
                    {
                        Lifeboatcount++;
                        i = i + 2;
                    }
                }
            }
            for (i = 1; i < 10; i++)
            {
                for (j = 1; j < 8; j++)
                {
                    if (Plyer1Board[j - 1, i] != ship && Plyer1Board[j - 1, i] != hit && Plyer1Board[j, i] == hit
                    && Plyer1Board[j + 1, i] == hit && Plyer1Board[j + 2, i] != ship && Plyer1Board[j + 2, i] != hit)
                    {
                        Lifeboatcount++;
                        j = j + 2;
                    }
                }
            }      
            return Lifeboatcount;
        }
        static int CruiseBoatcount()
        /////בודק כמה צוללות בעלות 3 תאים נפלו
        {
            int CruiseBoat = 0;
            int i, j ;
            for(j=1;j<10;j++)
            {
                for (i = 1; i < 7; i++)
                {
                    if (Plyer1Board[j, i - 1] != ship && Plyer1Board[j, i - 1] != hit && Plyer1Board[j, i] == hit && Plyer1Board[j, i + 1] == hit
                        && Plyer1Board[j, i + 2] == hit && Plyer1Board[j, i + 3] != ship && Plyer1Board[j, i + 3] != hit)
                    {
                        CruiseBoat++;
                        i = i + 3;
                    }
                }
            }
            for (i = 1; i < 10; i++)
            {
                for (j = 1; j < 7; j++)
                {
                    if (Plyer1Board[j - 1, i] != ship && Plyer1Board[j - 1, i] != hit && Plyer1Board[j, i] == hit
                    && Plyer1Board[j + 1, i] == hit && Plyer1Board[j + 2, i] == hit && Plyer1Board[j + 3, i] != ship && Plyer1Board[j + 3, i] != hit)
                    {
                        CruiseBoat++;
                        j = j + 3;
                    }
                }
            }
            return CruiseBoat;
        }
        static int shipyardcount()
            /////בודק האם צוללת 4 תאים נפלה
        {
            int shipyard = 0;
            int i, j ;
            for (j = 1; j < 10; j++)
            {
                for (i = 1; i < 6; i++)
                {
                    if (Plyer1Board[j, i - 1] != ship && Plyer1Board[j, i - 1] != hit && Plyer1Board[j, i] == hit && Plyer1Board[j, i + 1] == hit
                        && Plyer1Board[j, i + 2] == hit && Plyer1Board[j, i + 3] == hit && Plyer1Board[j, i + 4] != ship
                        && Plyer1Board[j, i + 4] != hit)
                    {
                        shipyard=1;
                        i = i + 4;
                    }
                }
            }
            for (i = 1; i < 10; i++)
            {
                for (j = 1; j < 6; j++)
                {
                    if (Plyer1Board[j - 1, i] != ship && Plyer1Board[j - 1, i] != hit && Plyer1Board[j, i] == hit
                    && Plyer1Board[j + 1, i] == hit && Plyer1Board[j + 2, i] == hit && Plyer1Board[j + 3, i] == hit 
                    && Plyer1Board[j + 4, i] != ship && Plyer1Board[j + 4, i] != hit)
                    {
                        shipyard = 1;
                        j = j + 4;
                    }
                }
            }
            return shipyard;
        }
        static int AircraftPilotcount()
            ////בודק האם צוללת 5 תאים נפלה
        {
            int AircraftPilot = 0;
            int i, j ;
            for (j = 1; j < 10; j++)
            {
                for (i = 1; i < 5; i++)
                {
                    if (Plyer1Board[j, i - 1] != ship && Plyer1Board[j, i - 1] != hit &&  Plyer1Board[j, i] == hit
                     && Plyer1Board[j, i + 1] == hit && Plyer1Board[j, i + 2] == hit
                     && Plyer1Board[j, i + 3] == hit && Plyer1Board[j, i + 4] == hit && Plyer1Board[j, i + 5] != ship
                     && Plyer1Board[j, i + 5] != hit)
                    {
                        AircraftPilot = 1;
                        i = i + 5;
                    }
                }
            }
            for (i = 1; i < 10; i++)
            {
                for (j = 1; j < 5; j++)
                {
                    if (Plyer1Board[j - 1, i] != ship && Plyer1Board[j - 1, i] != hit && Plyer1Board[j, i] == hit
                              && Plyer1Board[j + 1, i] == hit && Plyer1Board[j + 2, i] == hit
                              && Plyer1Board[j + 3, i] == hit && Plyer1Board[j + 4, i] == hit && Plyer1Board[j + 5, i] != ship 
                              && Plyer1Board[j + 5, i] != hit)
                    {
                        AircraftPilot = 1;
                        j = j + 5;
                    }
                }
            }
         return AircraftPilot;
        }             
   static void Main(string[] args)
   {
            StartUP();
            ResetZero();
            drawBoard();
            Instructions();

            Console.WriteLine("Enter two characters according to the game board to place the first tow cell ship");
            Lifeboat1(lowcase(), uprcase(), dire());
            Console.Clear();
            drawBoard();

            Console.WriteLine("Enter two characters according to the game board to place the second tow cell ship");
            Lifeboat2(lowcase(), uprcase(), dire());
            Console.Clear();
            drawBoard();

            Console.WriteLine("Enter two characters according to the game board to place the first three cell ship");
            CruiseBoat1(lowcase(), uprcase(), dire());
            Console.Clear();
            drawBoard();

            Console.WriteLine("Enter two characters according to the game board to place the second three cell ship");
            CruiseBoat2(lowcase(), uprcase(), dire());
            Console.Clear();
            drawBoard();

            Console.WriteLine("Enter two characters according to the game board to place the Four cell ship");
            shipyard(lowcase(), uprcase(), dire());
            Console.Clear();
            drawBoard();

            Console.WriteLine("Enter two characters according to the game board to place the Five cell ship");
            AircraftPilot(lowcase(), uprcase(), dire());
            Console.Clear();
            drawBoard();

            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            ResetZeroGameBoard();
            for (int i=20;i>0;i--)
            {
                Console.Clear();
                Console.WriteLine("             Everything's ready now. Let's play\n");
                Console.WriteLine("Now try to hit the submarines \n");
                Console.WriteLine("Enter two characters according to the game board to hit a submarine\n");
                drawGameBoard();
                Console.WriteLine("             you have {0} chanecs",i);
                Hit(lowcase(), uprcase());
            }
            Console.Clear();
            drawGameBoard();
          Console.WriteLine("you hit {0} BattleShip With 2 cells", Lifeboatcount());
            Console.WriteLine("you hit {0} BattleShip With 3 cells", CruiseBoatcount());
            Console.WriteLine("you hit {0} BattleShip With 4 cells ", shipyardcount());
            Console.WriteLine("you hit {0} BattleShip With 5 cells ", AircraftPilotcount());
            Console.ReadLine();
        }
    }    
}

