using System;

namespace BasicLearning
{
    /*
     * 稀疏数组练习
     * 稀疏数组可用于压缩二维数组(二维数组中的有效数据大约小于总数据量的百分之30可以使用)
     */
    public class SparseArray
    {
        public static void Test1()
        {
            int row = 9;
            int col = 10;
            int[,] array = new int[row, col];
            array[1, 2] = 1;
            array[2, 3] = 2;

            Test(array);
        }

        public static void Test2()
        {
            int row = 9;
            int col = 10;
            int[,] array = new int[row, col];
            
            /*
             *     9*10 = 90
             *     90*0.33 = 29.7 = 29
             */
            
            // int validDataCount = 29;
            int validDataCount = 30;
            int x = 0;
            int y = 0;
            Random random = new Random();
            for (int i = 0; i < validDataCount; i++)
            {
                array[x, y] = random.Next(1, 3); // 左包右不包
                y++;
                if (y >= col)
                {
                    x++;
                    y = 0;
                }
            }

            Test(array);
        }
        
        private static void Test(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i,j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"NormalArray Size = {array.LongLength}\r\n");
            
            int[,] sparseArray = NormalArrayToSparseArray(array);
            for (int i = 0; i < sparseArray.GetLength(0); i++)
            {
                Console.WriteLine($"{sparseArray[i, 0]}\t{sparseArray[i, 1]}\t{sparseArray[i, 2]}");
            }
            Console.WriteLine($"SparseArray Size = {sparseArray.LongLength}\r\n");

            int[,] newArray = SparseArrayToNormalArray(sparseArray);
            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                for (int j = 0; j < newArray.GetLength(1); j++)
                {
                    Console.Write($"{newArray[i,j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"New NormalArray Size = {newArray.LongLength}\r\n");
        }

        private static int[,] NormalArrayToSparseArray(int[,] array)
        {
            int row = array.GetLength(0);
            int col = array.GetLength(1);
            int sum = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int value = array[i, j];
                    if (value != default)
                        sum++;
                }
            }

            int[,] sparseArray = new int[sum + 1, 3];
            sparseArray[0, 0] = row;
            sparseArray[0, 1] = col;
            sparseArray[0, 2] = sum;
            int sparseArrayRowIndex = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int value = array[i, j];
                    if (value != default)
                    {
                        sparseArrayRowIndex++;
                        sparseArray[sparseArrayRowIndex, 0] = i;
                        sparseArray[sparseArrayRowIndex, 1] = j;
                        sparseArray[sparseArrayRowIndex, 2] = value;
                    }
                }
            }

            return sparseArray;
        }

        private static int[,] SparseArrayToNormalArray(int[,] sparseArray)
        {
            int row = sparseArray[0, 0];
            int col = sparseArray[0, 1];
            int[,] array = new int[row, col];

            for (int i = 1; i < sparseArray.GetLength(0); i++)
            {
                int x = sparseArray[i, 0];
                int y = sparseArray[i, 1];
                int value = sparseArray[i, 2];
                array[x, y] = value;
            }

            return array;
        }
    }
}