import 'dart:async';
import 'dish_event.dart';
import 'dish_state.dart';
import 'Dish.dart';

class DishBloc {
  // Контроллер для событий (входящий поток)
  final _eventController = StreamController<DishEvent>();
  Sink<DishEvent> get eventSink => _eventController.sink;

  // Контроллер для состояний (выходящий поток)
  final _stateController = StreamController<DishState>();
  Stream<DishState> get stateStream => _stateController.stream;

  DishBloc() {
    _eventController.stream.listen(_mapEventToState);
  }

  void _mapEventToState(DishEvent event) async {
    if (event is LoadDishesEvent) {
      _stateController.sink.add(DishLoadingState());
      try {
        // Загрузка данных (эмуляция)
        List<Dish> dishes = await loadDishes();
        _stateController.sink.add(DishLoadedState(dishes, dishes[0], 0));
      } catch (e) {
        _stateController.sink.add(DishErrorState(e.toString()));
      }
    }
    // else if (event is ChangeDishEvent) {
    //   try {
    //     // Эмуляция изменения блюда
    //     List<Dish> dishes = await loadDishes();
    //     _stateController.sink.add(DishLoadedState(dishes, dishes[event.dishIndex], event.dishIndex));
    //   } catch (e) {
    //     _stateController.sink.add(DishErrorState(e.toString()));
    //   }
    // }
  }

  Future<List<Dish>> loadDishes() async {
    await Future.delayed(Duration(seconds: 2));
    return [
      Dish(
        name: 'Stuffed Eggs',
        description: 'Indulge in our luxurious Eggs Stuffed with Caviar, featuring perfectly boiled eggs filled with a rich, creamy mixture of yolks and premium caviar. Garnished with fresh herbs and served on a bed of crisp greens, this dish is a delightful blend of textures and flavors, perfect for a sophisticated appetizer or a lavish brunch.',
        price: 12.99,
        weight: 150,
        image: 'assets/Eggs Stuffed with Caviar.jpg',
        updated: "May 30, 2020",
        rate: "4.6",
        timeStamp: "22:47 IST",
        isSpicy: false,
        isPopular: false,
      ),
      Dish(
        name: 'Asian Meatballs',
        description: 'Savor the authentic taste of our Asian Meatballs, skillfully crafted with a blend of ground meats and aromatic spices. Served over a bed of stir-fried Yakisoba noodles, tossed in a savory sauce, this dish is bursting with umami flavors. Topped with sesame seeds and scallions, it’s a deliciously satisfying meal that brings the taste of Asia to your table.',
        price: 14.49,
        weight: 350,
        image: 'assets/Asian Meatballs with Yakisoba Noodles.jpg',
        updated: "May 28, 2020",
        rate: "4.3",
        timeStamp: "21:30 IST",
        isSpicy: true,
        isPopular: false,
      ),
      Dish(
        name: 'Szechuan Pork',
        description: "Experience the bold and spicy flavors of our Szechuan Pork, tender pieces of marinated pork stir-fried to perfection. Served with thick, chewy Udon noodles, and tossed in a fiery Szechuan sauce, this dish is a true culinary adventure. Garnished with fresh cilantro and red chili flakes, it's perfect for those who crave a little heat!",
        price: 15.99,
        weight: 400,
        image: 'assets/Szechuan Pork with Udon Noodles.jpg',
        updated: "May 25, 2020",
        rate: "4.0",
        timeStamp: "20:20 IST",
        isSpicy: true,
        isPopular: true,
      ),
      Dish(
        name: 'Sabzi Polo ba Mahi',
        description: 'Delight in the traditional flavors of Iran with our Sabzi Polo ba Mahi. This dish features fragrant herbed rice, infused with dill, cilantro, and parsley, served alongside beautifully grilled fish. The combination of aromatic rice and perfectly cooked fish creates a harmonious balance of flavors, making it a must-try for any lover of Persian cuisine.',
        price: 18.99,
        weight: 450,
        image: 'assets/Sabzi Polo ba Mahi.jpg',
        updated: "May 24, 2020",
        rate: "4.9",
        timeStamp: "19:45 IST",
        isSpicy: false,
        isPopular: true,
      ),
      // Добавьте больше блюд
    ];
  }

  void dispose() {
    _eventController.close();
    _stateController.close();
  }
}
