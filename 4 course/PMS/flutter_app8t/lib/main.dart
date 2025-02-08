import 'package:flutter/material.dart';
import 'dart:async'; // Для работы с Platform Channel
import 'package:flutter/services.dart'; // Для MethodChannel
import 'package:hive_flutter/hive_flutter.dart';
import './user.dart';
import './favorite.dart';
import './product.dart';
import './user_page.dart';
import './product_page.dart';
import './favorites_screen.dart';



void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Hive.initFlutter();
  //await Hive.deleteBoxFromDisk('favorites');


  // Регистрируем адаптеры
  Hive.registerAdapter(UserAdapter());
  Hive.registerAdapter(FavoriteAdapter());
  Hive.registerAdapter(ProductAdapter());

  // Открываем боксы
  await Hive.openBox<User>('users');
  await Hive.openBox<Favorite>('favorites');
  await Hive.openBox<Product>('products');

  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: ToasterScreen(),
    );
  }
}

// МетодChannel для получения данных о GPS
const platform = MethodChannel('com.example.lab6_wid_gps_battery');

Future<bool> isGpsEnabled() async {
  try {
    final bool result = await platform.invokeMethod('isGpsEnabled');
    return result;
  } on PlatformException catch (e) {
    print("Failed to get GPS status: '${e.message}'.");
    return false;
  }
}
// МетодChannel для отправки SMS
Future<void> sendSms(String phoneNumber, String message) async {
  try {
    await platform.invokeMethod('sendSms', {
      'phoneNumber': phoneNumber,
      'message': message,
    });
  } on PlatformException catch (e) {
    print("Failed to send SMS: '${e.message}'.");
  }
}
Future<int> getBatteryLevel() async {
  try {
    final int result = await platform.invokeMethod('getBatteryLevel');
    return result;
  } on PlatformException catch (e) {
    print("Failed to get battery level: '${e.message}'.");
    return -1;
  }
}


class ToasterScreen extends StatefulWidget {
  @override
  _ToasterScreenState createState() => _ToasterScreenState();
}

class _ToasterScreenState extends State<ToasterScreen> {
  final Box<Product> productBox = Hive.box<Product>('products');
  final Box<Favorite> favoriteBox = Hive.box<Favorite>('favorites');
  final User currentUser = Hive.box<User>('users').get('currentUser', defaultValue:  new User(name: 'Admin', role: 'admin'));

  bool _isFavorite(Product product) {
    return favoriteBox.values.any(
          (fav) => fav.itemId == product.id && fav.userId == currentUser.name,
    );
  }

  void _toggleFavorite(BuildContext context, Product product) {
    if (currentUser.role == 'Admin') {
      showDialog(
        context: context,
        builder: (context) => AlertDialog(
          title: Text('Action not allowed'),
          content: Text('Favorites not available for admins'),
          actions: [
            TextButton(
              onPressed: () => Navigator.of(context).pop(),
              child: Text('OK'),
            ),
          ],
        ),
      );
      return;
    }


    // Изменяем состояние избранного для пользователя
    final favoriteKey = favoriteBox.keys.firstWhere(
          (key) {
        final favorite = favoriteBox.get(key);
        return favorite?.itemId == product.id;
      },
      orElse: () => null,
    );

    setState(() {
      if (favoriteKey != null) {
        // Если товар уже в избранном — удаляем
        favoriteBox.delete(favoriteKey);
        // ScaffoldMessenger.of(context).showSnackBar(
        //   SnackBar(content: Text('${product.name} removed from favorites!')),
        // );
      } else {
        // Если товара нет в избранном — добавляем
        favoriteBox.add(Favorite(
          itemId: product.id,
          description: product.name,
          userId: currentUser.name,
        ));

        // ScaffoldMessenger.of(context).showSnackBar(
        //   SnackBar(content: Text('${product.name} added to favorites!')),
        // );
      }
    });


  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: <Widget>[
          // Фоновое изображение
          Positioned.fill(
            child: Image.asset(
              './web/bg.png',
              fit: BoxFit.cover, // подгоняет изображение под размер экрана
            ),
          ),
          Column(
            children: [
              // Логотип сверху
              Container(
                padding: EdgeInsets.only(top: 50, bottom: 10),
                child: Image.network(
                  'https://upload.wikimedia.org/wikipedia/commons/thumb/0/06/Smeg_logo.svg/768px-Smeg_logo.svg.png?20190722122746',
                  height: 22,
                ),
              ),
              Column(
                crossAxisAlignment: CrossAxisAlignment.end, // Выравнивание по правому краю для всего
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween, // Занимает все доступное пространство
                    children: [
                      // Картинка слева
                      Container(
                        padding: EdgeInsets.only(top: 60, left: 20),
                        child: Image.asset(
                          './web/toaster.png',
                          height: 200,
                        ),
                      ),
                      // Текст "25%" и "OFF" справа
                      Padding(
                        padding: const EdgeInsets.only(right: 80), // Отступ от картинки
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.end, // Выравнивание по правому краю
                          children: [
                            Padding(
                              padding: const EdgeInsets.only(top: 50), // Отступ сверху
                              child: Text(
                                '25%',
                                style: TextStyle(color: Colors.white, fontWeight: FontWeight.bold, fontSize: 24),
                              ),
                            ),
                            Text(
                              'OFF',
                              style: TextStyle(color: Colors.black, fontWeight: FontWeight.bold, fontSize: 24),
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                  // Второй блок под картинкой
                  Padding(
                    padding: const EdgeInsets.only(top: 0, right: 50, bottom: 0), // Отступ сверху и справа
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start, // Выравнивание по правому краю
                      children: [
                        Text(
                          '2 Slice',
                          style: TextStyle(color: Colors.white, fontSize: 20), // Тонкий текст
                        ),
                        Padding(
                          padding: const EdgeInsets.only(top: 0, left: 20), // Отступ сверху
                          child: Container(
                            child: Text(
                              'Toaster',
                              style: TextStyle(color: Colors.white, fontSize: 26, fontWeight: FontWeight.bold),
                            ),
                          ),
                        ),
                        // Квадрат с закругленными краями под текстом "Toaster"
                        Padding(
                          padding: const EdgeInsets.only(top: 0, left: 50), // Отступ сверху
                          child: Container(
                            padding: EdgeInsets.all(8),
                            decoration: BoxDecoration(
                              color: Colors.red, // Красный фон
                              borderRadius: BorderRadius.circular(8),
                              // Закругленные края
                            ),
                            child: Text(
                              '5 Year Warranty',
                              style: TextStyle(color: Colors.white, fontSize: 16), // Уменьшенный размер шрифта
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
              SizedBox(height: 30),
              Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20.0),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text(
                      'Featured',
                      style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
                    ),
                    Text(
                      'View All',
                      style: TextStyle(color: Colors.grey, fontSize: 16),
                    ),
                  ],
                ),
              ),
              SizedBox(height: 20),
              Expanded(
                child: ValueListenableBuilder(
                  valueListenable: productBox.listenable(),
                  builder: (context, Box<Product> box, _) {
                    if (box.values.isEmpty) {
                      return Center(child: Text('No products available.'));
                    }
                    return ListView(
                      scrollDirection: Axis.horizontal,
                      children: box.values.map((product) {
                        return ProductCard(
                          product: product,
                          isFavorite: currentUser.role == 'User' && _isFavorite(product),
                          isAdmin: currentUser.role != 'User',
                          onToggleFavorite: () => _toggleFavorite(context, product),
                        );
                      }).toList(),
                    );
                  },
                ),
              ),
            ],
          ),


          Positioned(
            bottom: 0,
            left: 0,
            right: 0,
            child: Container(
              padding: EdgeInsets.symmetric(horizontal: 30, vertical: 20),
              color: Colors.black, // Черный фон
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  IconButton(
                    icon: Icon(Icons.home, color: Colors.white),
                    onPressed: () {
                      // На главную страницу
                    },
                  ),
                  IconButton(
                    icon: Icon(Icons.menu_outlined, color: Colors.grey),
                    onPressed: () {
                      // Меню (добавьте экран, если необходимо)
                    },
                  ),
                  IconButton(
                    icon: Icon(Icons.shopping_bag_sharp, color: Colors.grey),
                    onPressed: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => ProductPage()),
                      );
                    },
                  ),
                  IconButton(
                    icon: Icon(Icons.favorite, color: Colors.grey),
                    onPressed: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => FavoritesScreen()),
                      );
                    },
                  ),
                  IconButton(
                    icon: Icon(Icons.person, color: Colors.grey),
                    onPressed: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => UserPage()),
                      );
                    },
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }
}


// Экран для чайников с передачей данных и PageView
class KettleScreen extends StatelessWidget {
  final String data;

  KettleScreen({required this.data});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(data),
        leading: IconButton(
          icon: Icon(Icons.arrow_back),
          onPressed: () {
            Navigator.pop(context); // Возврат на предыдущий экран
          },
        ),
      ),
      body: PageView(
        children: [
          _buildKettleScreen3(context), // Передаем контекст
        ],
      ),
    );
  }

  // Метод для построения третьей страницы
  Widget _buildKettleScreen3(BuildContext context) {
    return Stack(
      children: <Widget>[
        Positioned.fill(
          child: Image.asset(
            './web/bg2.png',
            fit: BoxFit.cover, // подгоняет изображение под размер экрана
          ),
        ),
        Column(
          children: [
            Stack(
              children: [
                Container(
                  height: 160,
                ),
                Positioned(
                  top: 20,
                  left: 20,
                  child: Column(
                    children: [
                      IconButton(
                        icon: Icon(Icons.share),
                        onPressed: () {},
                      ),
                      IconButton(
                        icon: Icon(Icons.favorite_border),
                        onPressed: () {},
                      ),
                    ],
                  ),
                ),
                Positioned(
                  top: 0,
                  right: 130,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(
                        'Kettles',
                        style: TextStyle(
                            color: Colors.white,
                            fontSize: 30,
                            fontWeight: FontWeight.bold),
                      ),
                      Text(
                        'KLF04WHEU',
                        style: TextStyle(fontSize: 20, color: Colors.white),
                      ),
                    ],
                  ),
                ),
                Positioned(
                  bottom: 40,
                  right: 108,
                  child: Container(
                    padding: EdgeInsets.symmetric(vertical: 4, horizontal: 8),
                    decoration: BoxDecoration(
                      color: Colors.red,
                      borderRadius: BorderRadius.circular(4),
                    ),
                    child: Text(
                      '12 Month Warranty',
                      style: TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                ),
              ],
            ),
            Padding(
              padding: const EdgeInsets.only(top: 0, bottom: 40.0, right: 100),
              child: ConstrainedBox(
                constraints: BoxConstraints(
                  maxHeight: 210,
                ),
                child: Image.asset(
                  './web/kettle.png',
                  fit: BoxFit.contain,
                ),
              ),
            ),
            Expanded(
              child: Row(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Expanded(
                    child: Container(
                      decoration: BoxDecoration(
                        color: Color(0xFF808B77),
                        borderRadius: BorderRadius.only(
                          topLeft: Radius.circular(20),
                        ),
                      ),
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                        children: [
                          Center(child: _smallImage()),
                          SizedBox(height: 20),
                          Center(child: _smallImage()),
                          SizedBox(height: 20),
                          Center(child: _smallImage()),
                        ],
                      ),
                    ),
                  ),
                  Expanded(
                    flex: 2,
                    child: Padding(
                      padding: const EdgeInsets.only(left: 20.0),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          Padding(
                            padding: const EdgeInsets.symmetric(horizontal: 16.0),
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                Text(
                                  'Max capacity',
                                  style: TextStyle(
                                      fontSize: 18,
                                      color: Colors.white,
                                      fontWeight: FontWeight.bold),
                                ),
                                Text(
                                  'Colour',
                                  style: TextStyle(
                                      fontSize: 18,
                                      color: Colors.white,
                                      fontWeight: FontWeight.bold),
                                ),
                              ],
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(horizontal: 25.0),
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                Text(
                                  '1.7lt / 7 cups',
                                  style: TextStyle(
                                      fontSize: 16, fontWeight: FontWeight.bold),
                                ),
                                Text(
                                  'Red',
                                  style: TextStyle(
                                      fontSize: 16, fontWeight: FontWeight.bold),
                                ),
                              ],
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.all(8.0),
                            child: ConstrainedBox(
                              constraints: BoxConstraints(
                                maxWidth: 200,
                              ),
                              child: Text(
                                'Opening the lid with the soft A opening system. A double way to visualize the water level (L/cups), removable stainless steel lime filter. Temperature setting button. The function button A keep warm. The audible signal.',
                                style: TextStyle(
                                    fontSize: 16, color: Colors.black),
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 50, vertical: 10),
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                Padding(
                                  padding: const EdgeInsets.only(right: 14.0),
                                  child: Text(
                                    '\$172',
                                    style: TextStyle(
                                        fontSize: 24,
                                        fontWeight: FontWeight.bold),
                                  ),
                                ),
                                Container(
                                  padding: EdgeInsets.all(9),
                                  decoration: BoxDecoration(
                                    color: Colors.black,
                                    borderRadius: BorderRadius.circular(12),
                                  ),
                                  child: IconButton(
                                    icon: Icon(
                                      Icons.shopping_basket,
                                      color: Colors.white,
                                      size: 30,
                                    ),
                                    onPressed: () {
                                      // Действие при нажатии
                                    },
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ],
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ],
    );
  }

  Widget _smallImage() {
    return Container(
      width: 80,
      height: 80,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(12),
      ),
      child: Image.network(
        'https://byversloot.nl/10541-large_default/smeg-waterkoker-emerald-green-17l.jpg',
        fit: BoxFit.cover,
      ),
    );
  }
}

class ProductCard extends StatelessWidget {
  final Product product;
  final bool isFavorite;
  final bool isAdmin;
  final VoidCallback onToggleFavorite;

  const ProductCard({
    required this.product,
    required this.isFavorite,
    required this.isAdmin,
    required this.onToggleFavorite,
  });

  @override
  Widget build(BuildContext context) {
    return Card(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Image.network(
           'https://byversloot.nl/10541-large_default/smeg-waterkoker-emerald-green-17l.jpg',
            width: 150,
            height: 100,
            fit: BoxFit.cover,
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Text(
              product.name,
              style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Text('\$${product.price.toStringAsFixed(2)}'),
          ),
          // IconButton(
          //   icon: Icon(
          //     Icons.favorite,
          //     color: isAdmin
          //         ? Colors.grey // Серые сердечки для администратора
          //         : (isFavorite ? Colors.red : Colors.grey),
          //   ),
          //   onPressed: onToggleFavorite,
          // ),
          IconButton(
            icon: Icon(
              Icons.favorite,
              color: isAdmin ? Colors.grey : (isFavorite ? Colors.red : Colors.grey),
            ),
            onPressed: isAdmin
                ? null // Отключаем возможность взаимодействия для администратора
                : onToggleFavorite,
          ),

        ],
      ),
    );
  }
}