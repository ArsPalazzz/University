import 'package:flutter/cupertino.dart';

import 'AboutPage.dart';
import 'Dish.dart';
import 'FoodDetailScreen.dart';
import 'FootListScreen.dart';
import 'OpenBrowserPage.dart';
import 'constants.dart';

class FoodPageView extends StatefulWidget {
  @override
  _FoodPageViewState createState() => _FoodPageViewState();
}

class _FoodPageViewState extends State<FoodPageView> {
  PageController _pageController = PageController();
  List<Dish> allDishes = dishes;

  @override
  Widget build(BuildContext context) {
    return PageView(
      controller: _pageController,
      children: [
        FoodListScreen(),
        AboutPage(),
        OpenBrowserPage(),
      ],
    );
  }
}