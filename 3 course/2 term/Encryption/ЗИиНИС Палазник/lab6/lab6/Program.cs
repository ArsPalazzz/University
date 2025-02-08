using System;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            string binaryInputString = "10010111000110101110000100";
            string generatorPolynomial = "100101";

            int inputLength = binaryInputString.Length;
            int totalBits = 31;
            int redundantBits = 5;

            int errorPosition;

            int[] inputBitsArray = new int[inputLength];
            Operations.StringToIntegerArray(inputBitsArray, binaryInputString);

            int[] generatorBitsArray = new int[generatorPolynomial.Length];
            Operations.StringToIntegerArray(generatorBitsArray, generatorPolynomial);

            Console.WriteLine("\t\tInput String xk: " + binaryInputString);
            Console.WriteLine("\t\tGenerator Polynomial xr in Binary: " + generatorPolynomial);
            Console.WriteLine($"\t\t\t k = {inputLength}, r = {redundantBits}, n = {totalBits}");
            Console.WriteLine("--------------------------------------------------------------------------------");

            int[,] generationMatrix = new int[inputLength, totalBits];
            Operations.CreateGenerationMatrix(generationMatrix, generatorBitsArray, inputLength, totalBits);

            Console.WriteLine("\n\t\t\t\tGeneration Matrix\n");
            Operations.PrintMatrix(generationMatrix, inputLength, totalBits);

            Operations.ConvertToCanonicalForm(generationMatrix, inputLength, totalBits);
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\n\t\t\t\tCanonical Form Matrix\n");
            Operations.PrintMatrix(generationMatrix, inputLength, totalBits);

            int[,] checkMatrix = new int[totalBits, redundantBits];
            Operations.CreateCheckMatrix(checkMatrix, generationMatrix, inputLength, totalBits);
            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("\n\t\t\t\tCheck Matrix in Canonical Form\n");
            Operations.PrintMatrix(checkMatrix, totalBits, redundantBits);

            // Task 1.2

            int[] extendedInputBitsArray = new int[totalBits];
            Operations.ShiftRight(extendedInputBitsArray, inputBitsArray, redundantBits);

            Console.WriteLine("--------------------------------------------------------------------------------");

            // Task 2
            Console.WriteLine("\n\t\t\t\t\tDivision\n");
            Operations.CalculateRemainder(extendedInputBitsArray, generatorBitsArray);

            Console.WriteLine("Remainder:");
            Operations.PrintArray(extendedInputBitsArray);

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("\n\t\t\t\tFinal String\n");
            Operations.ShiftRight(extendedInputBitsArray, inputBitsArray, redundantBits);
            Operations.PrintArray(extendedInputBitsArray);

            Console.WriteLine("--------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("Enter the position of the first error");
                errorPosition = Convert.ToInt32(Console.ReadLine()) - 1;
                extendedInputBitsArray[errorPosition] = (extendedInputBitsArray[errorPosition] == 1) ? 0 : 1;
            }
            catch { }

            Console.WriteLine("Erroneous String:");
            Operations.PrintArray(extendedInputBitsArray);

            Operations.DetectAndCorrectError(extendedInputBitsArray, generatorBitsArray, checkMatrix, redundantBits);

            Console.WriteLine("--------------------------------------------------------------------------------");
            try
            {
                Console.WriteLine("Enter the position of the first error: ");
                errorPosition = Convert.ToInt32(Console.ReadLine()) - 1;
                extendedInputBitsArray[errorPosition] = (extendedInputBitsArray[errorPosition] == 1) ? 0 : 1;

                Console.WriteLine("Enter the position of the second error: ");
                errorPosition = Convert.ToInt32(Console.ReadLine()) - 1;
                extendedInputBitsArray[errorPosition] = (extendedInputBitsArray[errorPosition] == 1) ? 0 : 1;
            }
            catch { }

            Console.WriteLine("Erroneous String:");
            Operations.PrintArray(extendedInputBitsArray);

            Operations.DetectAndCorrectError(extendedInputBitsArray, generatorBitsArray, checkMatrix, redundantBits);
        }
    }
}
