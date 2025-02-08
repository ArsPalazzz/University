import 'package:flutter/material.dart';
import 'package:hive_flutter/adapters.dart';

import 'FoodDetailScreen.dart';
import 'favorites_screen.dart';
import 'package:carousel_slider/carousel_slider.dart';
import 'models/dish_model.dart';
import 'models/user_model.dart';
import 'product_management_screen.dart';
import 'user_selection_screen.dart';

class FoodListScreen extends StatefulWidget {
  @override
  _FoodListScreenState createState() => _FoodListScreenState();
}

class _FoodListScreenState extends State<FoodListScreen> {
  UserModel? _currentUser;
  int _currentFilterIndex = 0;
  late Box<DishModel> dishesBox;

  List<String> filters = ['All', 'Popular', 'Spicy'];

  @override
  void initState() {
    super.initState();
    dishesBox = Hive.box<DishModel>('dishes');
    _initializeDishes();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      _selectUser();
    });
  }

  void _initializeDishes() {
    if (dishesBox.isEmpty) {
      dishesBox.addAll([
        DishModel(
          id: '1',
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
        DishModel(
          id: '2',
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
        DishModel(
          id: '3',
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
        DishModel(
          id: '4',
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
      ]);
    }
  }

  Future<void> _selectUser() async {
    final user = await Navigator.push<UserModel>(
      context,
      MaterialPageRoute(builder: (context) => UserSelectionScreen()),
    );
    if (user != null) {
      setState(() {
        _currentUser = user;
      });
    }
  }


  @override
  Widget build(BuildContext context) {
    final dishes = dishesBox.values.toList();

    return Scaffold(
          floatingActionButton: _currentUser!.role == 'manager'
              ? FloatingActionButton(
                  child: const Icon(Icons.edit),
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                          builder: (context) => ProductManagementScreen()),
                    ).then((_) => setState(() {}));
                  },
                )
              : null,
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
                  onPressed: () {
                    _selectUser();
                  },
                ),
                IconButton(
                  icon: Icon(Icons.favorite_border, color: Colors.orangeAccent),
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) =>
                            FavoritesScreen(userName: _currentUser!.name, allDishes: dishes),
                      ),
                    );
                  },
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
                              '(${dishes.length} Dishes)',
                              style: TextStyle(
                                  fontSize: 16.0,
                                  color: Colors.orange
                              ),
                            ),
                            Row(children: [
                              Icon(
                                  Icons.list, color: Colors.orangeAccent, size: 30,
                              ),
                            ],)

                          ],
                        ),
                      ),
                      SizedBox(height: 20),
                            Column(
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
                                                  overflow: TextOverflow.ellipsis,
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
                                                        Navigator.push(
                                                          context,
                                                          MaterialPageRoute(
                                                            builder: (context) => FoodDetailScreen(dish: dish, allDishes: dishes, currentUser: _currentUser!.name,),
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
                            )
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
