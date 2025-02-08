class Accessory {
    private String name;
    private double cost;

    public Accessory(String name, double cost) {
        this.name = name;
        this.cost = cost;
    }

    public double getCost() {
        return cost;
    }

    @Override
    public String toString() {
        return name + " (Price: " + cost + ")";
    }
}
