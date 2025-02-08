// PS D:\Универ\6 семестр\AQA\Software-Testing\lab6\Java.Collections> javac Accessory.java Bouquet.java FileDataReader.java Flower.java FlowerShopApp.java Rose.java Tulip.java
// PS D:\Универ\6 семестр\AQA\Software-Testing\lab6\Java.Collections> java FlowerShopApp

import java.util.List;
import java.io.IOException;

public class FlowerShopApp {
    public static void main(String[] args) {
        Bouquet bouquet = new Bouquet();
        bouquet.addFlower(new Rose(100, 1, 40));
        bouquet.addFlower(new Tulip(70, 2, 30));
        bouquet.addAccessory(new Accessory("Strip", 20));

        System.out.println("Price of bouquet: " + bouquet.getTotalCost());

        bouquet.sortFlowersByFreshness();
        System.out.println("Flowers in a bouquet after sorting by freshness:");
        for (Flower flower : bouquet.getFlowers()) {
            System.out.println(flower);
        }

        System.out.println("Flowers with stem length from 20 to 35 sm:");
        List<Flower> flowersInRange = bouquet.findFlowersByStemLength(20, 35);
        for (Flower flower : flowersInRange) {
            System.out.println(flower);
        }

        System.out.println();
        System.out.println();

        // read from file

        try {
            Bouquet bouquet2 = new Bouquet();
            bouquet2.getFlowers().addAll(FileDataReader.readFlowersFromFile("flowers.txt"));
            bouquet2.getAccessories().addAll(FileDataReader.readAccessoriesFromFile("accessories.txt"));

            System.out.println("Bouquet price: " + bouquet2.getTotalCost());

            bouquet2.sortFlowersByFreshness();
            System.out.println("Flowers in a bouquet after sorting by freshness:");
            for (Flower flower : bouquet2.getFlowers()) {
                System.out.println(flower);
            }

            System.out.println("Flowers with stem length from 20 to 35 sm:");
            List<Flower> flowersInRange2 = bouquet2.findFlowersByStemLength(20, 35);
            for (Flower flower : flowersInRange2) {
                System.out.println(flower);
            }

        } catch (IOException e) {
            System.err.println("Error while reading a file: " + e.getMessage());
        }
    }
}
