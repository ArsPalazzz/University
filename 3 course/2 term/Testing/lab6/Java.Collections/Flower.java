abstract class Flower {
    protected String name;
    protected double cost;
    protected int freshnessLevel; // Уровень свежести (чем меньше, тем свежее)
    protected int stemLength;

    public Flower(String name, double cost, int freshnessLevel, int stemLength) {
        this.name = name;
        this.cost = cost;
        this.freshnessLevel = freshnessLevel;
        this.stemLength = stemLength;
    }

    public double getCost() {
        return cost;
    }

    public int getFreshnessLevel() {
        return freshnessLevel;
    }

    public int getStemLength() {
        return stemLength;
    }

    @Override
    public String toString() {
        return name + " (Price: " + cost + ", Degree of freshness: " + freshnessLevel + ", Stem lenght: " + stemLength
                + ")";
    }
}