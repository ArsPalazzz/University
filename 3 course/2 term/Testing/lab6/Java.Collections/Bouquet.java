import java.util.ArrayList;
import java.util.List;
import java.util.Comparator;
import java.util.stream.Collectors;
import java.util.stream.Stream;

class Bouquet {
    private List<Flower> flowers = new ArrayList<>();
    private List<Accessory> accessories = new ArrayList<>();

    public List<Flower> getFlowers() {
        return flowers;
    }

    public List<Accessory> getAccessories() {
        return accessories;
    }

    public void addFlower(Flower flower) {
        flowers.add(flower);
    }

    public void addAccessory(Accessory accessory) {
        accessories.add(accessory);
    }

    public double getTotalCost() {
        double total = 0;
        for (Flower flower : flowers) {
            total += flower.getCost();
        }
        for (Accessory accessory : accessories) {
            total += accessory.getCost();
        }
        return total;
    }

    public void sortFlowersByFreshness() {
        flowers.sort(Comparator.comparingInt(Flower::getFreshnessLevel));
    }

    public List<Flower> findFlowersByStemLength(int min, int max) {
        return flowers.stream()
                .filter(flower -> flower.getStemLength() >= min && flower.getStemLength() <= max)
                .collect(Collectors.toList());
    }
}