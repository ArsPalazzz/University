import java.util.List;

public class Main {
    public static void main(String[] args) {
        // Создаем массив объектов Car
        CarArray carArray = new CarArray();

        // Добавляем несколько автомобилей в массив
        carArray.addCar(new Car(1, "Toyota", "Camry", 2015, "Blue", 15000, "A123BC"));
        carArray.addCar(new Car(2, "Honda", "Accord", 2018, "Black", 18000, "X456YZ"));
        carArray.addCar(new Car(3, "Toyota", "Corolla", 2010, "Red", 10000, "P789QR"));

        // a) Список автомобилей заданной марки
        System.out.println("List of car brand Toyota:");
        List<Car> toyotaCars = carArray.getCarsByBrand("Toyota");
        for (Car car : toyotaCars) {
            System.out.println(car);
        }

        // b) Список автомобилей заданной модели, которые эксплуатируются больше n лет
        System.out.println("\nList of Camry cars that have been in operation for more than 5 years:");
        List<Car> oldCamrys = carArray.getCarsByModelAndYears("Camry", 5);
        for (Car car : oldCamrys) {
            System.out.println(car);
        }

        // c) Список автомобилей заданного года выпуска, цена которых больше указанной
        System.out.println("\nList of cars produces in 2015, the price of which is more than 12000:");
        List<Car> expensive2015Cars = carArray.getCarsByYearAndPrice(2015, 12000);
        for (Car car : expensive2015Cars) {
            System.out.println(car);
        }
    }
}
