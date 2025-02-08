import 'package:flutter/material.dart';

import 'Dish.dart';

class DishProvider with ChangeNotifier {
  List<Dish> _dishes = [];
  Dish? _currentDish;

  List<Dish> get dishes => _dishes;
  Dish? get currentDish => _currentDish;

  void setDishes(List<Dish> dishes) {
    _dishes = dishes;
    notifyListeners();
  }

  void setCurrentDish(Dish dish) {
    _currentDish = dish;
    notifyListeners();
  }
}
