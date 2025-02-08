import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:hive/hive.dart';
import 'package:hive_flutter/adapters.dart';

import 'FoodDetailScreen.dart';
import 'models/favorite_model.dart';
import 'models/dish_model.dart';

class FavoritesScreen extends StatelessWidget {
  final String userName;
  final List<DishModel> allDishes;

  const FavoritesScreen({Key? key, required this.userName, required this.allDishes}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    var favoritesBox = Hive.box<FavoriteModel>('favorites');
    var dishesBox = Hive.box<DishModel>('dishes');

    return Scaffold(
      appBar: AppBar(
        title: const Text('Избранное'),
      ),
      body: ValueListenableBuilder(
        valueListenable: favoritesBox.listenable(),
        builder: (context, Box<FavoriteModel> box, _) {
          List<FavoriteModel> userFavorites =
              box.values.where((fav) => fav.userName == userName).toList();
          if (userFavorites.isEmpty) {
            return const Center(child: Text('Нет избранных товаров'));
          } else {
            return ListView.builder(
              itemCount: userFavorites.length,
              itemBuilder: (context, index) {
                FavoriteModel favorite = userFavorites[index];
                DishModel? dish = dishesBox.values
                    .firstWhereOrNull((prod) => prod.id == favorite.dishId);

                if (dish == null) {
                  return const SizedBox.shrink();
                }

                return ListTile(
                  title: Text(dish.name),
                  subtitle: Text(dish.price.toString()),
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => FoodDetailScreen(
                            dish: dish, currentUser: userName, allDishes: allDishes,),
                      ),
                    );
                  },
                  trailing: IconButton(
                    icon: const Icon(Icons.delete),
                    onPressed: () {
                      favorite.delete();
                    },
                  ),
                );
              },
            );
          }
        },
      ),
    );
  }
}
