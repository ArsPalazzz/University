import 'package:carousel_slider/carousel_slider.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/material.dart';
import 'package:flutter_app13/UserProfileScreen.dart';
import 'package:provider/provider.dart';
import 'package:intl/intl.dart';

import 'AuthService.dart';
import 'Dish.dart';
import 'DishRepository.dart';
import 'FoodDetailScreen.dart';
import 'JSON.dart';
import 'LoginScreen.dart';

class FoodListScreen extends StatefulWidget {
  @override
  _FoodListScreenState createState() => _FoodListScreenState();
}

class _FoodListScreenState extends State<FoodListScreen> {
  late DishRepository dishRepository;
  int _currentFilterIndex = 0;
  int dishCount = 0;

  final nameController = TextEditingController();
  final descriptionController = TextEditingController();
  final priceController = TextEditingController();
  final imageController = TextEditingController();
  final rateController = TextEditingController();
  late String currentDate;
  late String currentTime;
  late String timeStamp;
  final weightController = TextEditingController();
  bool isSpicy = false;
  bool isPopular = false;

  List<String> filters = ['All', 'Popular', 'Spicy'];

  final AuthService _authService = AuthService();

  void _logout() async {
    try {
      await _authService.logout();

        Navigator.pushReplacement(
          context,
          MaterialPageRoute(builder: (context) => const LoginScreen()),
        );

    } catch (e) {
    }
  }

  @override
  void initState() {
    super.initState();
    final DateFormat formatter = DateFormat('yyyy-MM-dd HH:mm:ss');
    currentDate = formatter.format(DateTime.now());

    final DateFormat timeFormatter = DateFormat('HH:mm');
    currentTime = timeFormatter.format(DateTime.now());
    timeStamp = '$currentTime IST';

    dishRepository = Provider.of<DishRepository>(context, listen: false);
  }

  void _addDialog() async {
    return showDialog(
        context: context,
        builder: (context) {
          return AlertDialog(
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(0),
            ),
            title: const Text('Add dish'),
            content: SingleChildScrollView(
              child: Column(
                children: [
                  TextFormField(
                    controller: nameController,
                    decoration: const InputDecoration(labelText: 'Название'),
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  TextFormField(
                    controller: descriptionController,
                    decoration:
                    const InputDecoration(labelText: 'Описание'),
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  TextFormField(
                    controller: priceController,
                    decoration:
                    const InputDecoration(labelText: 'Цена'),
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  TextFormField(
                    controller: imageController,
                    decoration:
                    const InputDecoration(labelText: 'Путь к изображению'),
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  TextFormField(
                    controller: rateController,
                    decoration:
                    const InputDecoration(labelText: 'Рейтинг'),
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  TextFormField(
                    controller: weightController,
                    decoration:
                    const InputDecoration(labelText: 'Вес'),
                  ),
                  Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Row(
                        children: [
                          const Text(
                            "Острый",
                            style: TextStyle(fontSize: 16),
                          ),
                          Checkbox(
                            value: isSpicy,
                            onChanged: (value) {
                              setState(() {
                                isSpicy = value!;
                              });
                            },
                          ),
                        ],
                      ),
                      const SizedBox(
                        height: 20,
                      ),
                      Row(
                        children: [
                          const Text(
                            "Популярный",
                            style: TextStyle(fontSize: 16),
                          ),
                          Checkbox(
                            value: isPopular,
                            onChanged: (value) {
                              setState(() {
                                isPopular = value!;
                              });
                            },
                          ),
                        ],
                      ),
                    ],
                  )
                ],
              ),
            ),
            actions: [
              TextButton(
                  onPressed: () {
                    Navigator.pop(context);
                  },
                  child: const Text('Закрыть')),
              TextButton(
                  onPressed: () async {
                    Dish new_dish = Dish(
                        id: (dishCount + 1).toString(),
                        name: nameController.text.toString(),
                        description: descriptionController.text.toString(),
                        price: double.parse(priceController.text),
                        image: imageController.text.toString(),
                        updated: currentDate,
                        rate: rateController.text.toString(),
                        timeStamp: timeStamp,
                        weight: int.parse(weightController.text),
                      isSpicy: isSpicy,
                      isPopular: isPopular
                    );
                    dishRepository.createDish(new_dish);

                    nameController.clear();
                    descriptionController.clear();
                    priceController.clear();
                    imageController.clear();
                    rateController.clear();
                    weightController.clear();
                    isSpicy = false;
                    isPopular = false;

                    Navigator.pop(context);
                  },
                  child: const Text('Добавить')),
            ],
          );
        });
  }


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      floatingActionButton: FloatingActionButton(
        key: const ValueKey('addButton'),
        backgroundColor: Colors.blue,
        child: const Icon(
          Icons.add,
          color: Colors.white,
        ),
        onPressed: () {
          _addDialog();
        },
      ),
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
                // SizedBox(height: 36),
                // IconButton(
                //   icon: Icon(Icons.local_drink, color: Colors.orangeAccent),
                //   onPressed: () {},
                // ),
                SizedBox(height: 36),
                IconButton(
                  icon: Icon(Icons.settings, color: Colors.orangeAccent),
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => UserProfileScreen(),
                      ),
                    );
                  },
                ),
                SizedBox(height: 36),
                IconButton(
                  icon: Icon(Icons.logout, color: Colors.orangeAccent),
                  onPressed: () {
                    _logout();
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
                            '(${dishCount} Dishes)',
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
    StreamBuilder<QuerySnapshot>(
    stream: FirebaseFirestore.instance.collection('dishes').snapshots(),
    builder: (BuildContext context, AsyncSnapshot<QuerySnapshot> snapshot) {
    if (snapshot.connectionState == ConnectionState.waiting) {
    return Center(child: CircularProgressIndicator());
    }

    if (snapshot.hasError) {
    return Center(child: Text('Error: ${snapshot.error}'));
    }

    if (!snapshot.hasData || snapshot.data!.docs.isEmpty) {
    return Center(child: Text('No dishes available'));
    }

    // Преобразуем данные в список
    final List<Dish> dishes = snapshot.data!.docs.map((doc) {
    return Dish.fromFirestore(doc.id,  doc.data() as Map<String, dynamic>); // Используйте ваш метод десериализации
    }).toList();
                          //final dishes = snapshot.data!;
    WidgetsBinding.instance.addPostFrameCallback((_) {
      if (dishCount != dishes.length) {
        setState(() {
          dishCount = dishes.length;
        });
      }
    });
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
                                              'Updated: \n${dish.updated}, ${dish.timeStamp}',
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
                                                          builder: (context) => FoodDetailScreen(dish: dish, dishes: dishes),
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