import 'package:carousel_slider/carousel_slider.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:hive/hive.dart';

import 'models/favorite_model.dart';
import 'models/dish_model.dart';

class FoodDetailScreen extends StatefulWidget {
  final DishModel dish;
  final List<DishModel> allDishes;

  final String? currentUser;

  const FoodDetailScreen({
    Key? key,
    required this.dish,
    required this.allDishes,
    required this.currentUser,
  }) : super(key: key);

  @override
  _FoodDetailScreenState createState() => _FoodDetailScreenState();
}

class _FoodDetailScreenState extends State<FoodDetailScreen> {
  late DishModel currentDish;
  late int currentIndex;
  late String userName;
  late Box<FavoriteModel> favoritesBox;

  @override
  void initState() {
    super.initState();

    favoritesBox = Hive.box<FavoriteModel>('favorites');
    currentDish = widget.dish;
    userName = widget.currentUser ?? '';
    currentIndex = widget.allDishes.indexWhere((dish) => dish.image == widget.dish.image);
  }

  void updateDish(int index) {
    setState(() {
      currentIndex = index;
      currentDish = widget.allDishes[index];
    });
  }

  @override
  Widget build(BuildContext context) {
    bool isFavorite = favoritesBox.values
        .any((fav) => fav.dishId == currentDish.id && fav.userName == userName);

    return Scaffold(
      appBar: AppBar(
        title: Text(currentDish.name),
        leading: IconButton(
          icon: Icon(Icons.arrow_back),
          onPressed: () {
            Navigator.pop(context);
          },
        ),
        actions: [
          IconButton(
            icon: Icon(Icons.notifications),
            onPressed: () {
              print("Notifications icon tapped");
            },
          ),
        ],
      ),
      body: Stack(
        children: [
          Align(
            alignment: Alignment.bottomCenter,
            child: Container(
              color: Colors.orange,
              child: Container(
                padding: EdgeInsets.only(top: 60, bottom: 20, left: 16, right: 16),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceAround,
                  children: [
                    ElevatedButton(
                      onPressed: () {},
                      child: Text('M'),
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.orange,
                        foregroundColor: Colors.white,
                        padding: EdgeInsets.symmetric(horizontal: 32),
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(8.0), // Небольшой радиус углов
                          side: BorderSide(color: Colors.white), // Однородный белый цвет границы
                        ),
                      ),
                    ),
                    ElevatedButton(
                      onPressed: () {},
                      child: Text('L'),
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.orange,
                        foregroundColor: Colors.white,
                        padding: EdgeInsets.symmetric(horizontal: 32),
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(8.0), // Небольшой радиус углов
                          side: BorderSide(color: Colors.white), // Однородный белый цвет границы
                        ),
                      ),
                    ),
                    ElevatedButton(
                      onPressed: () {
                        print(isFavorite);
                        if (!isFavorite) {
                          favoritesBox.add(FavoriteModel(
                              userName: userName,
                              dishId: currentDish.id));
                        }
                      },
                      child: Text('+ Add to Fav'),
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.white,
                        foregroundColor: Colors.orange,
                        padding: EdgeInsets.symmetric(horizontal: 50, vertical: 16),
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
          Container(
            height: MediaQuery.of(context).size.height - 170,
            decoration: BoxDecoration(
              color: Colors.white, // Цвет фона
              borderRadius: BorderRadius.only(
                bottomLeft: Radius.circular(50.0),
                bottomRight: Radius.circular(50.0),
              ),
            ),
            child: ClipRRect(
              borderRadius: BorderRadius.only(
                bottomLeft: Radius.circular(50.0),
                bottomRight: Radius.circular(50.0),
              ),
              child: SingleChildScrollView(
                child: Padding(
                  padding: const EdgeInsets.all(16.0),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      CarouselSlider(
                        options: CarouselOptions(
                          enableInfiniteScroll: true,
                          enlargeCenterPage: true,
                          onPageChanged: (index, reason) {
                            setState(() {
                              currentIndex = index;
                              currentDish = widget.allDishes[index];
                            });
                          },
                          viewportFraction: 0.8,
                          initialPage: widget.allDishes.indexWhere(
                                  (dishFromList) => dishFromList.image == currentDish.image),
                        ),
                        items: widget.allDishes.map((item) {
                          return Builder(
                            builder: (BuildContext context) {
                              return Container(
                                width: MediaQuery.of(context).size.width,
                                margin: EdgeInsets.symmetric(horizontal: 5.0),
                                decoration: BoxDecoration(
                                  borderRadius: BorderRadius.circular(10.0),
                                  image: DecorationImage(
                                    image: AssetImage(item.image),
                                    fit: BoxFit.cover,
                                  ),
                                ),
                                child: Stack(
                                  children: [
                                    // Картинка уже находится здесь
                                    Positioned(
                                      right: 10, // Отступ от правого края
                                      bottom: 5, // Отступ от нижнего края
                                      child: Stack(
                                        alignment: Alignment.center,
                                        children: [
                                          Icon(
                                            Icons.star,
                                            color: Colors.orange, // Цвет звезды
                                            size: 60, // Размер звезды
                                          ),
                                          Text(
                                            '${item.rate}', // Используйте item.rate для отображения оценки
                                            style: TextStyle(
                                              fontSize: 12,
                                              color: Colors.white, // Цвет текста внутри звезды
                                              fontWeight: FontWeight.bold,
                                            ),
                                          ),
                                        ],

                                      ),
                                    ),
                                  ],
                                ),
                              );
                            },
                          );
                        }).toList(),
                      ),
                      SizedBox(height: 16),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Text(
                            '\$${currentDish.price}',
                            style: TextStyle(
                                fontSize: 40,
                                fontWeight: FontWeight.bold,
                                color: Colors.orange),
                          ),
                          Row(
                            children: [
                              IconButton(
                                icon: Icon(Icons.share),
                                onPressed: () {},
                              ),
                              IconButton(
                                icon: FaIcon(FontAwesomeIcons.youtube),
                                onPressed: () {},
                                iconSize: 25.0,
                                color: Colors.red,
                              ),
                            ],
                          )
                        ],
                      ),
                      SizedBox(height: 8),
                      Text(
                        'Updated: ${currentDish.updated}, ${currentDish.timeStamp}',
                        style: TextStyle(color: Colors.grey),
                      ),
                      SizedBox(height: 16),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.center,
                            children: [
                              Text('Size', style: TextStyle(fontSize: 12, color: Colors.grey)),
                              SizedBox(height: 4),
                              Text('Medium', style: TextStyle(fontSize: 18, color: Colors.black)),
                            ],
                          ),
                          VerticalDivider(
                            color: Colors.grey,
                            thickness: 1,
                          ),
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.center,
                            children: [
                              Text('Delivery', style: TextStyle(fontSize: 12, color: Colors.grey)),
                              SizedBox(height: 4),
                              Text('30 min', style: TextStyle(fontSize: 18, color: Colors.black)),
                            ],
                          ),
                          VerticalDivider(
                            color: Colors.grey,
                            thickness: 1,
                          ),
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.center,
                            children: [
                              Text('No', style: TextStyle(fontSize: 12, color: Colors.grey)),
                              SizedBox(height: 4),
                              Text('Gluten', style: TextStyle(fontSize: 18, color: Colors.black)),
                            ],
                          ),
                        ],
                      ),
                      SizedBox(height: 16),
                      Text(
                        currentDish.description,
                        style: TextStyle(fontSize: 16, color: Colors.grey),
                      ),
                      //SizedBox(height: 60), // Добавляем отступ, чтобы освободить место для кнопок
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
