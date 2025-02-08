using System;
using System.Collections.Generic;
using System.IO;

namespace laba7
{

    class Program
    {
        static void Main(string[] args)
        {

            CollectionType<Array> newCollection = new CollectionType<Array>();  // экземпляр типа Array обобщенного типа

            CollectionType<string> newCollectionOfStrings = new CollectionType<string>(); // экземпляр типа Array обобщенного типа

            CollectionType<Car> newCollectionOfSquares = new CollectionType<Car>();
            Car newSquare = new Car(true, true, "Renault");

            Array myArray = new int[1, 2, 3];
            Array myArray2 = new int[1, 2, 3, 5];

            try
            {
                newCollection.Add(myArray);
                newCollection.Add(myArray2);
                newCollectionOfSquares.Add(newSquare);
                Console.WriteLine();

                newCollection.Viewing();
                newCollectionOfSquares.Viewing();
                Console.WriteLine();

                newCollection.Delete(myArray);
                newCollection.Viewing();
                Console.WriteLine();

                newCollection.WriteTextFile();
                Console.WriteLine("Data is written to a Data.txt");

                Console.WriteLine("The data in Data.txt:");
                newCollection.ReadTextFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("final block is here");
            }


        }
    }



}


