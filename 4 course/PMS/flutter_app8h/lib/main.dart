import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:hive_flutter/hive_flutter.dart';

import 'FoodListScreen.dart';
import 'models/favorite_model.dart';
import 'models/dish_model.dart';
import 'models/user_model.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();

  await Hive.initFlutter();

  Hive.registerAdapter(UserModelAdapter());
  Hive.registerAdapter(DishModelAdapter());
  Hive.registerAdapter(FavoriteModelAdapter());

  await Hive.openBox<DishModel>('dishes');
  await Hive.openBox<FavoriteModel>('favorites');

  runApp(FoodApp());
}

class FoodApp extends StatelessWidget {
  const FoodApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        textTheme: GoogleFonts.poppinsTextTheme(),
        primaryColor: Colors.orange,
      ),
      home: FoodListScreen(),
    );
  }
}
