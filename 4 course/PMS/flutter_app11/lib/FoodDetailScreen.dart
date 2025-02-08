import 'package:carousel_slider/carousel_slider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_app11/Dish.dart';
import 'package:flutter_app11/FootListScreen.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import 'DishRepository.dart';

class FoodDetailScreen extends StatefulWidget {
  final Dish dish;
  final List<Dish> dishes;

  FoodDetailScreen({required this.dish, required this.dishes});

  @override
  _FoodDetailScreenState createState() => _FoodDetailScreenState();
}

class _FoodDetailScreenState extends State<FoodDetailScreen> {
  late Dish currentDish;
  late DishRepository dishRepository;
  int currentIndex = 0;

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

  @override
  void initState() {
    super.initState();
    currentDish = widget.dish;

    final DateFormat formatter = DateFormat('yyyy-MM-dd HH:mm:ss');
    currentDate = formatter.format(DateTime.now());

    final DateFormat timeFormatter = DateFormat('HH:mm');
    currentTime = timeFormatter.format(DateTime.now());
    timeStamp = '$currentTime IST';

    dishRepository = Provider.of<DishRepository>(context, listen: false);
    currentIndex = widget.dishes.indexWhere((dish) => dish.image == widget.dish.image);
  }

  void updateDish(int index) {
    setState(() {
      currentIndex = index;
      currentDish = widget.dishes[index];
    });
  }

  void _editDialog() async {
    nameController.text = currentDish.name;
    descriptionController.text = currentDish.description;
    priceController.text = currentDish.price.toString();
    imageController.text = currentDish.image;
    rateController.text = currentDish.rate;
    weightController.text = currentDish.weight.toString();
    isSpicy = currentDish.isSpicy;
    isPopular = currentDish.isPopular;

    return showDialog(
        context: context,
        builder: (context) {
          return AlertDialog(
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(0),
            ),
            title: const Text('Edit dish'),
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
                    Dish updated_dish = Dish(
                        id: currentDish.id,
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
                    dishRepository.updateDish(updated_dish);

                    nameController.clear();
                    descriptionController.clear();
                    priceController.clear();
                    imageController.clear();
                    rateController.clear();
                    weightController.clear();
                    isSpicy = false;
                    isPopular = false;

                    Navigator.pop(context);
                    Navigator.pop(context);
                  },
                  child: const Text('Сохранить')),
            ],
          );
        });
  }

  @override
  Widget build(BuildContext context) {
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
                      onPressed: () {
                        _editDialog();
                      },
                      child: Text('Update'),
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.white,
                        foregroundColor: Colors.black,
                        padding: EdgeInsets.symmetric(horizontal: 50, vertical: 16),
                      ),
                    ),
                    ElevatedButton(
                      onPressed: () {
                        dishRepository.deleteDish(currentDish.id);
                        Navigator.push(
                          context,
                          MaterialPageRoute(
                            builder: (context) => FoodListScreen(),
                          ),
                        );
                      },
                      child: Text('Delete'),
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.red,
                        foregroundColor: Colors.black,
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
                              currentDish = widget.dishes[index];

                              print("Current Dish: $currentDish");
                            });
                          },
                          viewportFraction: 0.8,
                          initialPage: widget.dishes.indexWhere(
                                  (dishFromList) => dishFromList.image == currentDish.image),
                        ),
                        items: widget.dishes.map((item) {
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
