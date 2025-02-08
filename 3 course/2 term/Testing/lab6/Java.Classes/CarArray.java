import java.util.ArrayList;
import java.util.List;

public class CarArray {
    private List<Car> cars;

    public CarArray() {
        cars = new ArrayList<>();
    }

    // Добавление автомобиля в массив
    public void addCar(Car car) {
        cars.add(car);
    }

    // Список автомобилей заданной марки
    public List<Car> getCarsByBrand(String brand) {
        List<Car> carsByBrand = new ArrayList<>();
        for (Car car : cars) {
            if (car.getBrand().equalsIgnoreCase(brand)) {
                carsByBrand.add(car);
            }
        }
        return carsByBrand;
    }

    // Список автомобилей заданной модели, которые эксплуатируются больше n лет
    public List<Car> getCarsByModelAndYears(String model, int years) {
        List<Car> carsByModelAndYears = new ArrayList<>();
        int currentYear = 2022;
        for (Car car : cars) {
            if (car.getModel().equalsIgnoreCase(model) && (currentYear - car.getYear()) > years) {
                carsByModelAndYears.add(car);
            }
        }
        return carsByModelAndYears;
    }

    // Список автомобилей заданного года выпуска, цена которых больше указанной
    public List<Car> getCarsByYearAndPrice(int year, double price) {
        List<Car> carsByYearAndPrice = new ArrayList<>();
        for (Car car : cars) {
            if (car.getYear() == year && car.getPrice() > price) {
                carsByYearAndPrice.add(car);
            }
        }
        return carsByYearAndPrice;
    }
}
