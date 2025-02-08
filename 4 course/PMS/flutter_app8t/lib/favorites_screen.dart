import 'package:flutter/material.dart';
import 'package:hive/hive.dart';
import '/favorite.dart';
import '/user.dart';
import 'package:hive_flutter/hive_flutter.dart';


class FavoritesScreen extends StatefulWidget {
  @override
  _FavoritesScreenState createState() => _FavoritesScreenState();
}

class _FavoritesScreenState extends State<FavoritesScreen> {
  late Box<Favorite> _favoriteBox;
  late User currentUser;

  @override
  void initState() {
    super.initState();
    _initializeFavorites();
  }

  void _initializeFavorites() {
    _favoriteBox = Hive.box<Favorite>('favorites'); // Используем уже открытый бокс
    final userBox = Hive.box<User>('users');
    currentUser = userBox.get('currentUser')!;
  }

  void _removeFavorite(String itemId) {
    final favoriteKey = _favoriteBox.keys.firstWhere(
          (key) {
        final favorite = _favoriteBox.get(key);
        return favorite?.itemId == itemId && favorite?.userId == currentUser.name;
      },
      orElse: () => null,
    );
    if (favoriteKey != null) {
      _favoriteBox.delete(favoriteKey);
    }
  }

  @override
  Widget build(BuildContext context) {
    if (currentUser.role == 'Admin') {
      return Scaffold(
        appBar: AppBar(title: Text('Favorites')),
        body: Center(child: Text('Favorites not available for Admins')),
      );
    }

    return Scaffold(
      appBar: AppBar(title: Text('Favorites')),
      body: ValueListenableBuilder(
        valueListenable: _favoriteBox.listenable(),
        builder: (context, Box<Favorite> box, _) {
          if (box.values.isEmpty) {
            return Center(child: Text('No favorites available.'));
          }
          return ListView.builder(
            itemCount: box.values.where((fav) => fav.userId == currentUser.name).length,
            itemBuilder: (context, index) {
              final favorite = box.values.where((fav) => fav.userId == currentUser.name).elementAt(index);
              return ListTile(
                title: Text(favorite.description),
              );
            },
          );
        },
      ),
    );
  }
}
