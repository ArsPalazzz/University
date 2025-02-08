import 'package:carousel_slider/carousel_slider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'Dish.dart';
import 'DishProvider.dart';
import 'FoodDetailScreen.dart';
import 'JSON.dart';

class FoodListScreen extends StatefulWidget {
  @override
  _FoodListScreenState createState() => _FoodListScreenState();
}

class _FoodListScreenState extends State<FoodListScreen> {
  late Future<List<Dish>> futureDishes;
  int _currentFilterIndex = 0;

  List<String> filters = ['All', 'Popular', 'Spicy'];

  @override
  void initState() {
    super.initState();
    futureDishes = loadDishes();
  }

  @override
  Widget build(BuildContext context) {
    final dishProvider = Provider.of<DishProvider>(context);

    return Scaffold(
      body: Row(
        children: [
          Container(
            width: 70,
            height: 700,
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.only(topRight: Radius.circular(20), bottomRight: Radius.circular(20), topLeft: Radius.zero, bottomLeft: Radius.zero),
            ),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                IconButton(
                  icon: Icon(Icons.grid_view, color: Colors.orangeAccent),
                  onPressed: () {},
                ),
                SizedBox(height: 36),
                IconButton(
                  icon: Icon(Icons.search, color: Colors.orangeAccent),
                  onPressed: () {},
                ),
                SizedBox(height: 36),
                IconButton(
                  icon: Icon(Icons.restaurant, color: Colors.orangeAccent),
                  onPressed: () {},
                ),
                SizedBox(height: 36),
                IconButton(
                  icon: Icon(Icons.fastfood, color: Colors.orangeAccent),
                  onPressed: () {},
                ),
                SizedBox(height: 36),
                IconButton(
                  icon: Icon(Icons.donut_large, color: Colors.orangeAccent),
                  onPressed: () {},
                ),
                SizedBox(height: 36),
                IconButton(
                  icon: Icon(Icons.cookie, color: Colors.orangeAccent),
                  onPressed: () {},
                ),
                SizedBox(height: 36),
                IconButton(
                  icon: Icon(Icons.local_drink, color: Colors.orangeAccent),
                  onPressed: () {},
                ),
                SizedBox(height: 36),
                IconButton(
                  icon: Icon(Icons.settings, color: Colors.orangeAccent),
                  onPressed: () {},
                ),
              ],
            ),
          ),
          Expanded(
            child:  Padding(
              padding: const EdgeInsets.only(top: 70.0),
              child: SingleChildScrollView(
              child: Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Padding(
                      padding: const EdgeInsets.only(bottom: 5.0),
                      child: Text(
                        'Good morning',
                        style: TextStyle(
                          fontSize: 16,
                          color: Colors.grey,
                        ),
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.only(bottom: 25.0),
                      child: Text(
                        'Sanoj Dilshan 👋',
                        style: TextStyle(
                          fontSize: 24,
                          fontWeight: FontWeight.bold,
                          color: Colors.black87,
                        ),
                      ),
                    ),
                    CarouselSlider(
                      options: CarouselOptions(
                        height: 50,
                        viewportFraction: 0.4,
                        initialPage: 0,
                        enableInfiniteScroll: false,
                        onPageChanged: (index, reason) {
                          setState(() {
                            _currentFilterIndex = index;
                          });
                        },
                      ),
                      items: filters.map((filter) {
                        return Builder(
                          builder: (BuildContext context) {
                            return Container(
                              width: MediaQuery.of(context).size.width,
                              margin: EdgeInsets.symmetric(horizontal: 5.0),
                              decoration: BoxDecoration(
                                color: _currentFilterIndex == filters.indexOf(filter)
                                    ? Colors.orangeAccent
                                    : Colors.grey[200],
                                borderRadius: BorderRadius.circular(20),
                              ),
                              child: Center(
                                child: Text(
                                  filter,
                                  style: TextStyle(
                                    fontSize: 16.0,
                                    color: _currentFilterIndex == filters.indexOf(filter)
                                        ? Colors.white
                                        : Colors.black54,
                                  ),
                                ),
                              ),
                            );
                          },
                        );
                      }).toList(),
                    ),
                    SizedBox(height: 20),
                    Container(
                      width: double.infinity,
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Text(
                            '(4 Dishes)',
                            style: TextStyle(
                              fontSize: 16.0,
                              color: Colors.orange
                            ),
                          ),
                          Icon(
                            Icons.list
                          ),
                        ],
                      ),
                    ),
                    SizedBox(height: 20),
                    FutureBuilder<List<Dish>>(
                      future: futureDishes,
                      builder: (context, snapshot) {
                        if (snapshot.connectionState == ConnectionState.waiting) {
                          return Center(child: CircularProgressIndicator());
                        } else if (snapshot.hasError) {
                          return Center(child: Text('Error: ${snapshot.error}'));
                        } else {
                          final dishes = snapshot.data!;
                          dishProvider.setDishes(dishes);
                          return Column(
                            children: dishes.map((dish) {
                              return Builder(
                                builder: (BuildContext context) {
                                  return Container(
                                    width: MediaQuery.of(context).size.width,
                                    margin: EdgeInsets.symmetric(horizontal: 10.0, vertical: 7.5),
                                    decoration: BoxDecoration(
                                      color: Colors.white,
                                      borderRadius: BorderRadius.circular(20),
                                      boxShadow: [
                                        BoxShadow(
                                          color: Colors.grey.withOpacity(0.3),
                                          spreadRadius: 2,
                                          blurRadius: 5,
                                          offset: Offset(0, 3),
                                        ),
                                      ],
                                    ),
                                    child: Row(
                                      crossAxisAlignment: CrossAxisAlignment.start,
                                      children: [
                                        ClipRRect(
                                          borderRadius: BorderRadius.only(
                                            topLeft: Radius.circular(20),
                                            topRight: Radius.circular(20),
                                          ),
                                          child: Container(
                                            width: 90,
                                            height: 130,
                                            decoration: BoxDecoration(
                                              borderRadius: BorderRadius.only(
                                                topLeft: Radius.circular(20),
                                                topRight: Radius.circular(20),
                                                bottomLeft: Radius.circular(20),
                                                bottomRight: Radius.circular(20),
                                              ),
                                              image: DecorationImage(
                                                image: AssetImage(dish.image),
                                                fit: BoxFit.cover,
                                              ),
                                            ),
                                          ),
                                        ),
                                        SizedBox(width: 10),
                                        Column(
                                          crossAxisAlignment: CrossAxisAlignment.start,
                                          children: [
                                            Container(
                                              constraints: BoxConstraints(maxWidth: MediaQuery.of(context).size.width * 0.5),
                                              child: Text(
                                                '${dish.name} ${dish.isSpicy ? '🌶️' : ''} ${dish.isPopular ? '⭐' : ''}',
                                                style: TextStyle(
                                                  fontSize: 16,
                                                  fontWeight: FontWeight.bold,
                                                ),
                                              ),
                                            ),
                                            SizedBox(height: 8),
                                            Text(
                                              'Updated: ${dish.updated}, ${dish.timeStamp}',
                                              style: TextStyle(
                                                fontSize: 10,
                                                color: Colors.grey[500],
                                              ),
                                            ),
                                            SizedBox(height: 8),
                                            Text(
                                              '${dish.rate} ★',
                                              style: TextStyle(
                                                fontSize: 10,
                                                color: Colors.grey[600],
                                              ),
                                            ),
                                            SizedBox(height: 8),
                                            Container(
                                              width: 180,
                                              child:  Row(
                                                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                                                children: [
                                                  Column(
                                                      crossAxisAlignment: CrossAxisAlignment.start,
                                                      children: [
                                                        Text(
                                                          '\$${dish.price}',
                                                          style: TextStyle(
                                                            fontSize: 16,
                                                            color: Colors.orangeAccent,
                                                            fontWeight: FontWeight.bold,
                                                          ),
                                                        ),
                                                        Text(
                                                          '${dish.weight}gr',
                                                          style: TextStyle(
                                                            fontSize: 10,
                                                            color: Colors.grey,
                                                          ),
                                                        ),
                                                      ]
                                                  ),
                                                  IconButton(
                                                    icon: Icon(Icons.keyboard_arrow_right),
                                                    onPressed: () {
                                                      final dishProvider = Provider.of<DishProvider>(context, listen: false);
                                                      dishProvider.setCurrentDish(dish);

                                                      Navigator.push(
                                                        context,
                                                        MaterialPageRoute(
                                                          builder: (context) => FoodDetailScreen(),
                                                        ),
                                                      );
                                                    },
                                                  ),
                                                ],
                                              ),
                                            )

                                          ],
                                        ),
                                      ],
                                    ),
                                  );
                                },
                              );
                            }).toList(),
                          );
                        }
                      },
                    ),
                  ],
                ),
              ),
            ),
            ),
          ),
        ],
      ),
    );
  }
}