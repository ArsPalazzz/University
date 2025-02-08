// dish_state.dart

import 'Dish.dart';

abstract class DishState {}

class DishInitialState extends DishState {}

class DishLoadingState extends DishState {}

class DishLoadedState extends DishState {
  final List<Dish> dishes;
  final Dish currentDish;
  final int currentIndex;

  DishLoadedState(this.dishes, this.currentDish, this.currentIndex);
}

class DishErrorState extends DishState {
  final String message;

  DishErrorState(this.message);
}
