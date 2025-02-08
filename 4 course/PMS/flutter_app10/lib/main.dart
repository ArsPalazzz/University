import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

import 'DishBlocProvider.dart';
import 'DishBloC.dart';
import 'FootListScreen.dart';

void main() {
  runApp(
    DishBlocProvider(
      dishBloc: DishBloc(),
      child: FoodApp(),
    ),
  );
}

class FoodApp extends StatelessWidget {
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




