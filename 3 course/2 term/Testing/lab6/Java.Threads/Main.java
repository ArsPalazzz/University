// javac Car.java Main.java ParkingLot.java

public class Main {
    public static void main(String[] args) {
        ParkingLot parkingLot = new ParkingLot(3); // Создаем парковку с тремя местами
        int numCars = 5; // Количество автомобилей

        for (int i = 1; i <= numCars; i++) {
            long maxWaitTime = (long) (Math.random() * 3000); // Время ожидания от 0 до 3 секунды
            new Car("Car " + i, parkingLot, maxWaitTime).start();
        }
    }
}