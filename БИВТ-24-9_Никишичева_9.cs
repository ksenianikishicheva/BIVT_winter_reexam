// Variant_9

using System;

namespace Exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Task_1:
            // Input: T = 4, D = 6, N = 22
            // Output: time = 83885792

            // Task_2:
            // Input: speedLimit = 4, motorLimit = 6, turnsPerSec = 22
            // Output: time = 5,899999999999999
            
            // speedLimit = 4, motorLimit = 6, turnsPerSec = 22;

            // Task_3:
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                 -13, 13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */
            // Output:
            /*   23,   0,  -2,  13, -11,  18, 
                 -8,   0, -20,   1, -20,   3, 
                 -2, -20,  -6,  19,  13, -13, 
                 -4, -22,  18, -15,  21,  22, 
                -17,   7, -16,  12,  22,   2, 
                -22, -21,  24, -13,   7, -14 */

            // Task_4:
            // Input:
            /*   17,  17,   2, -10,  -1, -20 */
            // Output:
            /*  -20, -10,  -1 */

            // Task_5:
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */

            /*   17,  17,   2, -10,  -1, -20 */
            // Output 1:
            /*   23,   7, -13, -20, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                 17, -11,  13,  -2,   0, -14 */

            /*  -20, -10,  -1,   2,  17,  17 */
            // Output 2:
            /*   23,   7, -13,  17, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -20, -11,  13,  -2,   0, -14 */

            /*   17,  17,   2,  -1, -10, -20 */

        }
        public double Task_1(double T, double D, double N)
        {
            double reload = 10, TotalTime = 0, knightDistance = T;
            for (int i = 1; i < N; i++)
            {
                TotalTime += knightDistance;
                TotalTime += reload;
                knightDistance += knightDistance + reload;
                reload += D;
            }
            TotalTime += knightDistance;
            Console.WriteLine(TotalTime);
            return TotalTime;
        }

        public double Task_2()
        {
            double speedLimit = 4, motorLimit = 6, turnsPerSec = 22;
            double speed = 0, turns = 0, gear = 1, time = 0;
            while (speed < speedLimit)
            {
                if (turns < motorLimit)
                {
                    turns += turnsPerSec;
                    time += 0.5;
                }
                else
                {
                    if (gear >= 5)
                    {
                        turns = motorLimit;
                        turns = Math.Round(turns);
                        speed += turns / 180;
                        time += 0.1;
                    }
                    else
                    {
                        gear++;
                        turns -= turns * 0.15;
                        time++;
                        motorLimit += 250;
                    }
                }
                turns = Math.Round(turns);
                speed += turns / 180;
                time += 0.1;
            }
            Console.WriteLine(time);
            return time;
        }

        public void Task_3(int[,] M)
        {
            if (M == null)
            {
                Console.WriteLine("Матрица нулевая!");
                return;
            }
            int n = M.GetLength(0);
            if (n == 0)
            {
                Console.WriteLine("В матрице нет значений!");
                return;
            }
            for (int i = 1; i < M.Rank; i++)
            {
                if (M.GetLength(i) != n)
                {
                    Console.WriteLine("Матрица не квадратная!");
                    return;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || i + j == n - 1)
                    {
                        continue;
                    }
                    int reflectedRow = n - 1 - i;
                    int reflectedCol = n - 1 - j;
                    if (i < reflectedRow || (i == reflectedRow && j < reflectedCol))
                    {
                        int temp = M[i, j];
                        M[i, j] = M[reflectedRow, reflectedCol];
                        M[reflectedRow, reflectedCol] = temp;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(M[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void Task_4(ref int[] A)
        {
            if (A == null) 
                return;

            int[] negativeArray = GetNegativeSubArray(A);

            if (negativeArray.Length == 0) 
                return;

            int n = negativeArray.Length;
            int shift = 10 % n;

            int[] shiftedArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                shiftedArray[(i + shift) % n] = negativeArray[i];
            }

            A = shiftedArray;
            Console.WriteLine(string.Join(", ", A));
        }
        public static int[] GetNegativeSubArray(int[] array)
        {
            if (array == null)
            {
                Console.WriteLine("Массив нулевой!");
                return new int[0];
            }

            int negativeCount = 0;
            foreach (int num in array)
            {
                if (num < 0)
                {
                    negativeCount++;
                }
            }

            int[] negativeArray = new int[negativeCount];
            int index = 0;
            foreach (int num in array)
            {
                if (num < 0)
                {
                    negativeArray[index] = num;
                    index++;
                }
            }
            return negativeArray;
        }



        public void Task_5(ref int[,] M, ref int[] A, SortArray Op)
        {

        }
        public delegate void SortArray(int[] array);
        public void SortAscending(int[] array) { }
        public void SortDescending(int[] array) { }
        public void FindUpperPartMaxIndex(int[,] matrix, out int maxRow, out int maxCol)
        {
            maxRow = 0; maxCol = 0;
        }
        public void FindLowerPartMinIndex(int[,] matrix, out int minRow, out int minCol)
        {
            minRow = 0; minCol = 0;
        }
    }
}