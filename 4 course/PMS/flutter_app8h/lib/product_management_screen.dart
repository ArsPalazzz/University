import 'package:flutter/material.dart';
import 'package:hive_flutter/adapters.dart';
import 'package:intl/intl.dart';

import 'models/dish_model.dart';

class ProductManagementScreen extends StatefulWidget {
  @override
  _ProductManagementScreenState createState() =>
      _ProductManagementScreenState();
}

class _ProductManagementScreenState extends State<ProductManagementScreen> {
  late Box<DishModel> productsBox;

  @override
  void initState() {
    super.initState();
    productsBox = Hive.box<DishModel>('dishes');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Управление товарами'),
      ),
      body: ValueListenableBuilder(
        valueListenable: productsBox.listenable(),
        builder: (context, Box<DishModel> box, _) {
          if (box.values.isEmpty) {
            return const Center(child: Text('Нет товаров'));
          } else {
            return ListView.builder(
              itemCount: box.values.length,
              itemBuilder: (context, index) {
                DishModel product = box.getAt(index)!;
                return ListTile(
                  title: Text(product.name),
                  subtitle: Text(product.price.toString()),
                  trailing: IconButton(
                    icon: const Icon(Icons.delete),
                    onPressed: () {
                      product.delete();
                      setState(() {});
                    },
                  ),
                  onTap: () => _showEditProductDialog(context, product),
                );
              },
            );
          }
        },
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () => _showAddProductDialog(context),
        child: const Icon(Icons.add),
      ),
    );
  }

  void _showAddProductDialog(BuildContext context) {
    final DateFormat formatter = DateFormat('MMM, dd, yyyy'); // Формат даты
    final String currentDate = formatter.format(DateTime.now()); // Текущая дата

    final DateFormat timeFormatter = DateFormat('HH:mm');
    final String currentTime = timeFormatter.format(DateTime.now());
    final String timeStamp = '$currentTime IST';

    String name = '';
    String description = '';
    double price = 0;
    int weight = 0;
    String image = '';
    String rate = '';

    bool isPopular = false;
    bool isSpicy = false;

    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          title: const Text('Добавить товар'),
          content: SingleChildScrollView(
            child: Column(
              children: [
                TextField(
                  decoration: const InputDecoration(labelText: 'Название'),
                  onChanged: (value) {
                    name = value;
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Описание'),
                  onChanged: (value) {
                    description = value;
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Цена'),
                  onChanged: (value) {
                    price = double.parse(value);
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Вес'),
                  onChanged: (value) {
                    weight = int.parse(value);
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Изображение'),
                  onChanged: (value) {
                    image = value;
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Оценка'),
                  onChanged: (value) {
                    rate = value;
                  },
                ),
                CheckboxListTile(
                  title: const Text('Острое'),
                  value: isSpicy,
                  onChanged: (value) {
                    setState(() {
                      isSpicy = value!;
                    });
                  },
                ),
                CheckboxListTile(
                  title: const Text('Популярное'),
                  value: isPopular,
                  onChanged: (value) {
                    setState(() {
                      isPopular = value!;
                    });
                  },
                ),
              ],
            ),
          ),
          actions: [
            TextButton(
              onPressed: () {
                productsBox.add(DishModel(
                  id: DateTime.now().toString(),
                  name: name,
                  description: description,
                  price: price,
                  weight: weight,
                  image: image,
                  updated: currentDate,
                  rate: rate,
                  timeStamp: timeStamp,
                  isSpicy: isSpicy,
                  isPopular: isPopular,
                ));
                Navigator.pop(context);
              },
              child: const Text('Добавить'),
            ),
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text('Отмена'),
            ),
          ],
        );
      },
    );
  }

  void _showEditProductDialog(BuildContext context, DishModel dish) {
    String name = dish.name;
    String description = dish.description;
    double price = dish.price;
    int weight = dish.weight;
    String image = dish.image;
    String rate = dish.rate;
    bool isSpicy = dish.isSpicy;
    bool isPopular = dish.isPopular;

    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          title: const Text('Редактировать товар'),
          content: SingleChildScrollView(
            child: Column(
              children: [
                TextField(
                  decoration: const InputDecoration(labelText: 'Название'),
                  controller: TextEditingController(text: name),
                  onChanged: (value) {
                    name = value;
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Описание'),
                  controller: TextEditingController(text: description),
                  onChanged: (value) {
                    description = value;
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Цена'),
                  controller: TextEditingController(text: price.toString()),
                  onChanged: (value) {
                    price = double.parse(value);
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Вес'),
                  controller: TextEditingController(text: weight.toString()),
                  onChanged: (value) {
                    weight = int.parse(value);
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Изображение'),
                  controller: TextEditingController(text: image),
                  onChanged: (value) {
                    image = value;
                  },
                ),
                TextField(
                  decoration: const InputDecoration(labelText: 'Оценка'),
                  controller: TextEditingController(text: rate),
                  onChanged: (value) {
                    image = rate;
                  },
                ),
                CheckboxListTile(
                  title: const Text('Острое'),
                  value: isSpicy,
                  onChanged: (value) {
                    setState(() {
                      isSpicy = value!;
                    });
                  },
                ),
                CheckboxListTile(
                  title: const Text('Популярное'),
                  value: isPopular,
                  onChanged: (value) {
                    setState(() {
                      isPopular = value!;
                    });
                  },
                ),
              ],
            ),
          ),
          actions: [
            TextButton(
              onPressed: () {
                final DateFormat formatter = DateFormat('MMM, dd, yyyy'); // Формат даты
                final String currentDate = formatter.format(DateTime.now()); // Текущая дата

                final DateFormat timeFormatter = DateFormat('HH:mm');
                final String currentTime = timeFormatter.format(DateTime.now());

                final String timeStamp = '$currentTime IST';

                dish.name = name;
                dish.description = description;
                dish.price = price;
                dish.weight = weight;
                dish.image = image;
                dish.rate = rate;
                dish.timeStamp = timeStamp;
                dish.isSpicy = isSpicy;
                dish.isPopular = isPopular;
                dish.updated = currentDate;

                dish.save();
                Navigator.pop(context);
              },
              child: const Text('Сохранить'),
            ),
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text('Отмена'),
            ),
          ],
        );
      },
    );
  }
}
