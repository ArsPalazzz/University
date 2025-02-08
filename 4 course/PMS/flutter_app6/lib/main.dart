import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

import 'FoodPageView.dart';

void main() {
  runApp(FoodApp());
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
      home: FoodPageView(),
    );
  }
}




