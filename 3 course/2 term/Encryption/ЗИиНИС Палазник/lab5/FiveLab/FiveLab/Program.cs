using System;

namespace Lab_5
{
    class Program
    {
        static void IterativeMatrix(int height, int width)
        {
            Random random = new Random();
            int[] finalMessage = new int[16];
            int[] savedMessage = new int[16];

            int[,] messageMatrix = new int[height, width];
            int[] columnParity = new int[width];
            int[] rowParity = new int[height];
            int totalSum = 0;

            for (int i = 0; i < width; i++)
                columnParity[i] = 0;

            for (int i = 0; i < height; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < width; j++)
                {
                    messageMatrix[i, j] = random.Next(0, 2);
                    Console.Write(messageMatrix[i, j] + "  ");
                    rowSum += messageMatrix[i, j];
                    totalSum += messageMatrix[i, j];
                    columnParity[i] = rowSum;
                    columnParity[j] += messageMatrix[i, j];
                }
                int remainder = rowSum % 2;
                Console.WriteLine(" |" + remainder);
            }

            for (int i = 0; i < width; i++)
                Console.Write("---");
            Console.Write("\n");

            for (int i = 0; i < width; i++)
            {
                int columnRemainder = columnParity[i] % 2;
                rowParity[i] = columnRemainder;
                Console.Write(columnRemainder + "  ");
            }
            Console.WriteLine("\n");

            int finalMessageIndex = 0;
            int savedMessageIndex = 0;
            Console.Write("Xn=  ");
            for (int i = 0; i < width; i++)
                columnParity[i] = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(messageMatrix[i, j]);
                    finalMessage[finalMessageIndex++] = messageMatrix[i, j];
                    savedMessage[savedMessageIndex++] = messageMatrix[i, j];
                }
            }

            try
            {
                Console.WriteLine();
                int errorPosition = random.Next(0, finalMessage.Length);
                Console.WriteLine("Error Position: " + errorPosition);
                finalMessage[errorPosition] = finalMessage[errorPosition] == 1 ? 0 : 1;
            }
            catch { }

            Console.Write("Yn=  ");
            foreach (int bit in finalMessage)
            {
                Console.Write(bit);
            }
            Console.WriteLine();
            int iterator = 0;
            for (int i = 0; i < width; i++)
                columnParity[i] = 0;

            for (int i = 0; i < height; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < width; j++)
                {
                    messageMatrix[i, j] = finalMessage[iterator++];
                    Console.Write(messageMatrix[i, j] + "  ");
                    rowSum += messageMatrix[i, j];
                    columnParity[i] = rowSum;
                }
                int remainder = rowSum % 2;
                Console.WriteLine(" |" + remainder);
            }

            for (int i = 0; i < width; i++)
                Console.Write("---");
            Console.Write("\n");
            for (int i = 0; i < width; i++)
            {
                int columnRemainder = columnParity[i] % 2;
                rowParity[i] = columnRemainder;
                Console.Write(columnRemainder + "  ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Comparing Parities:");
            Console.Write("  ");
            foreach (int item in columnParity)
            {
                int remainder = item % 2;
                Console.Write(remainder);
            }

            Console.Write("  ");
            foreach (int item in rowParity)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            Console.WriteLine("Corrected Message without Error:");

            Console.Write("Xn=  ");
            foreach (int bit in savedMessage)
            {
                Console.Write(bit);
            }
        }

        static void IterativeMatrix2(int height, int width)
        {
            Random random = new Random();
            int[] finalMessage = new int[16];
            int[] savedMessage = new int[16];

            int[,] matrix = new int[height, width];
            int[] columnParity = new int[width];
            int totalSum = 0;

            for (int i = 0; i < width; i++)
                columnParity[i] = 0;

            for (int i = 0; i < height; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = random.Next(0, 2);
                    Console.Write(matrix[i, j] + "  ");
                    rowSum += matrix[i, j];
                    totalSum += matrix[i, j];
                    columnParity[j] += matrix[i, j];
                }
                int remainder = rowSum % 2;
                Console.WriteLine(" |" + remainder);
            }

            for (int i = 0; i < width; i++)
                Console.Write("---");
            Console.Write("\n");
            for (int i = 0; i < width; i++)
            {
                int columnRemainder = columnParity[i] % 2;
                Console.Write(columnRemainder + "  ");
            }
            Console.WriteLine("\n");

            int finalMessageIndex = 0;
            int savedMessageIndex = 0;
            Console.Write("Xn=  ");
            for (int i = 0; i < width; i++)
                columnParity[i] = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(matrix[i, j]);
                    finalMessage[finalMessageIndex++] = matrix[i, j];
                    savedMessage[savedMessageIndex++] = matrix[i, j];
                }
            }

            try
            {
                Console.WriteLine();
                int errorPosition = random.Next(0, finalMessage.Length);
                Console.WriteLine("Error Position: " + errorPosition);
                finalMessage[errorPosition] = finalMessage[errorPosition] == 1 ? 0 : 1;
            }
            catch { }

            Console.Write("Yn=  ");
            foreach (int bit in finalMessage)
            {
                Console.Write(bit);
            }
            Console.WriteLine();
            int iterator = 0;
            for (int i = 0; i < width; i++)
                columnParity[i] = 0;

            for (int i = 0; i < height;
i++)
            {
                int rowSum = 0;
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = finalMessage[iterator++];
                    Console.Write(matrix[i, j] + "  ");
                    rowSum += matrix[i, j];
                    columnParity[j] += matrix[i, j];
                }
                int remainder = rowSum % 2;
                Console.WriteLine(" |" + remainder);
            }

            for (int i = 0; i < width; i++)
                Console.Write("---");
            Console.Write("\n");
            for (int i = 0; i < width; i++)
            {
                int columnRemainder = columnParity[i] % 2;
                Console.Write(columnRemainder + "  ");
            }
            Console.WriteLine("\n");

            Console.Write("Xn=  ");
            foreach (int bit in savedMessage)
            {
                Console.Write(bit);
            }
        }

        static void IterativeMatrixWithDepth(int height, int width, int depth)
        {
            Random random = new Random();
            int[] finalMessage = new int[16];
            int[] summedResults = new int[16];

            int[] columnParity = new int[depth];
            int itogers = 0;

            int[,,] array = new int[height, width, depth];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int rowSum = 0;
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = random.Next(0, 2);
                        rowSum += array[i, j, k];
                        summedResults[itogers++] += array[i, j, k];
                        Console.Write(array[i, j, k]);
                        columnParity[k] += array[i, j, k];
                    }
                    int remainder = rowSum % 2;
                    Console.WriteLine(" |" + remainder);
                }
                Console.WriteLine("---");
                for (int d = 0; d < depth; d++)
                {
                    int columnRemainder = columnParity[d] % 2;
                    Console.Write(columnRemainder + "");
                    columnParity[d] = 0;
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Parity of the 4th and 5th Groups:");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write(array[i, j, k]);
                    }
                }
                Console.WriteLine(" ");
            }

            int first = summedResults[0] + summedResults[5] + summedResults[10] + summedResults[15];
            int firstm = first % 2;
            int second = summedResults[1] + summedResults[6] + summedResults[11] + summedResults[12];
            int secondm = second % 2;
            int third = summedResults[2] + summedResults[7] + summedResults[8] + summedResults[13];
            int thirdm = third % 2;
            int fourth = summedResults[3] + summedResults[4] + summedResults[9] + summedResults[14];
            int fourthm = fourth % 2;

            int firstf = summedResults[0] + summedResults[7] + summedResults[10] + summedResults[13];
            int firstmf = firstf % 2;
            int secondf = summedResults[1] + summedResults[4] + summedResults[11] + summedResults[14];
            int secondmf = secondf % 2;
            int thirdf = summedResults[2] + summedResults[5] + summedResults[8] + summedResults[15];
            int thirdmf = thirdf % 2;
            int fourthf = summedResults[3] + summedResults[6] + summedResults[9] + summedResults[12];
            int fourthmf = fourthf % 2;

            Console.WriteLine("Parity of the 5th Group:  " + firstm + secondm + thirdm + fourthm);
            Console.WriteLine("Parity of the 4th Group:  " + firstmf + secondmf + thirdmf + fourthmf);

            int[] sresult = new int[16];
            Console.Write("Xn =  ");
            int inh = 0;
            foreach (var item in summedResults)
            {
                sresult[inh++] = item;
                Console.Write(item);
            }

            try
            {
                Console.WriteLine();
                int errorPosition = random.Next(0, finalMessage.Length);
                Console.WriteLine("Error Position:  " + errorPosition);
                if (summedResults[errorPosition] == 1) summedResults[errorPosition] = 0;
                else summedResults[errorPosition] = 1;
            }
            catch { }

            Console.Write("Yn =  ");
            foreach (var item in summedResults)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            int iterator = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        array[i, j, k] = summedResults[iterator++];
                        Console.Write(array[i, j, k]);
                        columnParity[k] += array[i, j, k];
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Corrected Message:");

            Console.Write("Xn =  ");
            foreach (var item in sresult)
            {
                Console.Write(item);
            }
        }

        static void Main()
        {
            IterativeMatrix(4, 4);
            Console.WriteLine();
            Console.WriteLine("______________________________________________________________________________");
            Console.WriteLine();
            IterativeMatrix2(8, 2);
            Console.WriteLine();
            Console.WriteLine("______________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Size: 4x2x2");
            Console.WriteLine();
            Console.WriteLine();
            IterativeMatrixWithDepth(4, 2, 2);
            Console.WriteLine();
            Console.WriteLine("______________________________________________________________________________");
            Console.WriteLine();
            IterativeMatrixWithDepth(2, 4, 2);
            Console.WriteLine();
            Console.WriteLine("______________________________________________________________________________");
        }
    }
}
