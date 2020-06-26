using System;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string worm = Console.ReadLine();
            int squareSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[squareSize, squareSize];

            int playerRow = 0;
            int playerCol = 0;

            for (int rows = 0; rows < squareSize; rows++)
            {
                string inputLine = Console.ReadLine();
                for (int cols = 0; cols < squareSize; cols++)
                {
                    matrix[rows, cols] = inputLine[cols];
                    if (matrix[rows, cols] == 'P')
                    {
                        playerRow = rows;
                        playerCol = cols;
                    }

                }
            }
            string command = Console.ReadLine();

            while (command != "end")
            {
                matrix[playerRow, playerCol] = '-';
                switch (command)
                {
                    case "up":
                        if (isValid(matrix, playerRow - 1, playerCol))
                        {
                            MoveUp(ref worm, matrix, ref playerRow, ref playerCol);
                        }
                        else
                        {
                            worm = Remove(worm, matrix, playerRow, playerCol);
                        }
                        break;

                    case "down":
                        if (isValid(matrix, playerRow + 1, playerCol))
                        {
                            MoveDown(ref worm, matrix, ref playerRow, ref playerCol);
                        }
                        else
                        {
                            worm = Remove(worm, matrix, playerRow, playerCol);
                        }
                        break;

                    case "left":
                        if (isValid(matrix, playerRow, playerCol - 1))
                        {
                            MoveLeft(ref worm, matrix, ref playerRow, ref playerCol);
                        }
                        else
                        {
                            worm = Remove(worm, matrix, playerRow, playerCol);
                        }
                        break;

                    case "right":
                        if (isValid(matrix, playerRow, playerCol + 1))
                        {
                            MoveRight(ref worm, matrix, ref playerRow, ref playerCol);
                        }
                        else
                        {
                            worm = Remove(worm, matrix, playerRow, playerCol);
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(worm);

            for (int rows = 0; rows < squareSize; rows++)
            {
                for (int cols = 0; cols < squareSize; cols++)
                {
                    Console.Write(matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }

        private static string Remove(string worm, char[,] matrix, int playerRow, int playerCol)
        {
            if (worm.Length > 0)
            {
                int startIndex = worm.Length - 1;
                worm = worm.Remove(startIndex);
            }
            matrix[playerRow, playerCol] = 'P';
            return worm;
        }

        private static void MoveUp(ref string worm, char[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerRow > 0)
            {
                playerRow--;
                if (matrix[playerRow, playerCol] != '-')
                {
                    worm += matrix[playerRow, playerCol];
                    matrix[playerRow, playerCol] = 'P';
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }

        }

        private static void MoveDown(ref string worm, char[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerRow < matrix.Length - 1)
            {
                playerRow++;
                if (matrix[playerRow, playerCol] != '-')
                {
                    worm += matrix[playerRow, playerCol];
                    matrix[playerRow, playerCol] = 'P';
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }

        }

        private static void MoveLeft(ref string worm, char[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerCol > 0)
            {
                playerCol--;
                if (matrix[playerRow, playerCol] != '-')
                {
                    worm += matrix[playerRow, playerCol];
                    matrix[playerRow, playerCol] = 'P';
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }

        }

        private static void MoveRight(ref string worm, char[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerCol < matrix.Length - 1)
            {
                playerCol++;
                if (matrix[playerRow, playerCol] != '-')
                {
                    worm += matrix[playerRow, playerCol];
                    matrix[playerRow, playerCol] = 'P';
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }
          
        }
            private static bool isValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

    }
}