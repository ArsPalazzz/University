import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class FileDataReader {
    public static List<Flower> readFlowersFromFile(String filePath) throws IOException {
        List<Flower> flowers = new ArrayList<>();
        try (BufferedReader reader = new BufferedReader(new FileReader(filePath))) {
            String line;
            while ((line = reader.readLine()) != null) {
                String[] parts = line.split(",");
                String type = parts[0];
                double price = Double.parseDouble(parts[1]);
                int freshness = Integer.parseInt(parts[2]);
                int stemLength = Integer.parseInt(parts[3]);

                switch (type) {
                    case "Rose":
                        flowers.add(new Rose(price, freshness, stemLength));
                        break;
                    case "Tulip":
                        flowers.add(new Tulip(price, freshness, stemLength));
                        break;
                }
            }
        }
        return flowers;
    }

    public static List<Accessory> readAccessoriesFromFile(String filePath) throws IOException {
        List<Accessory> accessories = new ArrayList<>();
        try (BufferedReader reader = new BufferedReader(new FileReader(filePath))) {
            String line;
            while ((line = reader.readLine()) != null) {
                String[] parts = line.split(",");
                String name = parts[0];
                double price = Double.parseDouble(parts[1]);
                accessories.add(new Accessory(name, price));
            }
        }
        return accessories;
    }
}
