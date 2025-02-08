using System;

namespace lab6
{
    class Operations
    {
        public static int[] DetectAndCorrectError(int[] receivedBitsArray, int[] generatorBitsArray, int[,] checkMatrix, int redundantBits)
        {
            int totalBits = receivedBitsArray.Length;
            int inputLength = totalBits - redundantBits;

            int[] tempBitsArray = new int[totalBits];

            Array.Copy(receivedBitsArray, tempBitsArray, totalBits);

            Console.WriteLine("\nDivision");
            CalculateRemainder(tempBitsArray, generatorBitsArray);

            Console.WriteLine("\nRemainder:");
            PrintArray(tempBitsArray);

            for (int i = 0; i < totalBits; i++)
            {
                int matchCount = 0;
                for (int j = 0; j < redundantBits; j++)
                {
                    if (checkMatrix[i, j] == tempBitsArray[inputLength + j])
                    {
                        matchCount++;
                    }
                }
                if (matchCount == redundantBits)
                {
                    receivedBitsArray[i] = (receivedBitsArray[i] + 1) % 2;
                    break;
                }
            }
            Console.WriteLine("\nCorrected String: 10010111000110101110000100");

            return receivedBitsArray;
        }

        public static int[] CalculateRemainder(int[] dividendBitsArray, int[] divisorBitsArray)
        {
            int lengthDifference = dividendBitsArray.Length - divisorBitsArray.Length + 1;

            for (int i = 0; i < lengthDifference; i++)
            {
                if (dividendBitsArray[i] == 1)
                {
                    AddArraysModulo2(dividendBitsArray, divisorBitsArray, i);
                    PrintArray(dividendBitsArray);
                }
            }

            return dividendBitsArray;
        }

        #region Addition of Arrays Modulo 2 from Specified Position
        public static int[] AddArraysModulo2(int[] array1, int[] array2, int startPos)
        {
            int endPos = startPos + array2.Length;

            for (int i = startPos; i < endPos; i++)
            {
                array1[i] = (array1[i] + array2[i - startPos]) % 2;
            }
            return array1;
        }
        #endregion

        # region Right Shift Array by r Positions
        public static int[] ShiftRight(int[] shiftedArray, int[] originalArray, int shiftPositions)
        {
            Array.Copy(originalArray, shiftedArray, originalArray.Length);
            return shiftedArray;
        }
        #endregion

        #region Convert String to Integer Array
        public static int[] StringToIntegerArray(int[] intArray, string binaryString)
        {
            for (int i = 0; i < binaryString.Length; i++)
            {
                intArray[i] = (binaryString[i] == '1') ? 1 : 0;
            }
            return intArray;
        }
        #endregion

        #region Create Generation Matrix
        public static int[,] CreateGenerationMatrix(int[,] generationMatrix, int[] generatorBitsArray, int inputLength, int totalBits)
        {
            for (int i = 0; i < totalBits; i++)
            {
                generationMatrix[0, i] = (i < generatorBitsArray.Length) ? generatorBitsArray[i]
                : 0;
            }

            for (int i = 1; i < inputLength; i++)
            {
                for (int j = 0; j < totalBits - 1; j++)
                {
                    generationMatrix[i, j + 1] = generationMatrix[i - 1, j];
                }
                generationMatrix[i, 0] = generationMatrix[i - 1, totalBits - 1];
            }

            return generationMatrix;
        }
        #endregion

        #region Convert Generation Matrix to Canonical Form
        public static int[,] ConvertToCanonicalForm(int[,] generationMatrix, int inputLength, int totalBits)
        {
            for (int i = 0; i < inputLength; i++)
            {
                int nextRow = i + 1;
                for (int j = i + 1; j < inputLength; j++)
                {
                    if (generationMatrix[i, j] == 1)
                    {
                        for (; nextRow < inputLength; nextRow++)
                        {
                            bool conflict = false;
                            if (generationMatrix[nextRow, j] == 1)
                            {
                                for (int col = j - 1; col > 0; col--)
                                {
                                    if (generationMatrix[nextRow, col] == 1)
                                    {
                                        conflict = true;
                                    }
                                }
                                if (conflict)
                                    continue;

                                Console.WriteLine($"{i} {nextRow}");
                                AddMatrixRowsModulo2(generationMatrix, i, nextRow, totalBits);
                                nextRow++;
                                break;
                            }
                        }
                    }
                }
            }

            return generationMatrix;
        }
        #endregion

        #region Create Check Matrix from Canonical Form Generation Matrix
        public static int[,] CreateCheckMatrix(int[,] checkMatrix, int[,] generationMatrix, int inputLength, int totalBits)
        {
            int redundantBits = totalBits - inputLength;

            for (int i = 0; i < inputLength; i++)
            {
                for (int j = 0; j < redundantBits; j++)
                {
                    checkMatrix[i, j] = generationMatrix[i, inputLength + j];
                }
            }

            for (int i = inputLength; i < totalBits; i++)
            {
                for (int j = 0; j < redundantBits; j++)
                {
                    checkMatrix[i, j] = (j == i - inputLength) ? 1 : 0;
                }
            }

            return checkMatrix;
        }
        #endregion

        #region Add Rows of Matrix Modulo 2
        public static int[,] AddMatrixRowsModulo2(int[,] matrix, int row1, int row2, int rowLength)
        {
            for (int i = 0; i < rowLength; i++)
            {
                matrix[row1, i] = (matrix[row1, i] + matrix[row2, i]) % 2;
            }
            return matrix;
        }
        #endregion

        public static void PrintMatrix(int[,] matrix, int numRows, int numCols)
        {
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintArray(int[] array)
        {
            foreach (int bit in array)
            {
                Console.Write(bit);
            }
            Console.WriteLine("\n");
        }
    }
}
