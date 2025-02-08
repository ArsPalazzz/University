import 'package:flutter/material.dart';
import 'package:hive/hive.dart';
import '/product.dart';
import '/user.dart';
import 'package:hive_flutter/hive_flutter.dart';

import 'favorite.dart';


class ProductPage extends StatefulWidget {
  @override
  _ProductPageState createState() => _ProductPageState();
}

class _ProductPageState extends State<ProductPage> {
  late Box<Product> _productBox;
  late User currentUser;
  late Box<Favorite> favoriteBox;

  @override
  void initState() {
    super.initState();
    _initializeBoxes();
  }

  void _initializeBoxes() {
    _productBox = Hive.box<Product>('products');
    currentUser = Hive.box<User>('users').get('currentUser')!;
    favoriteBox = Hive.box('favorites');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Products')),
      body: Column(
        children: [
          if (currentUser.role == 'Admin') ...[
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: ElevatedButton(
                onPressed: () {
                  _showAddProductDialog(context);
                },
                child: Text('Add Product'),
              ),
            ),
          ],
          Expanded(
            child: ValueListenableBuilder(
              valueListenable: _productBox.listenable(),
              builder: (context, Box<Product> box, _) {
                if (box.values.isEmpty) {
                  return Center(child: Text('No products available.'));
                }
                return ListView.builder(
                  itemCount: box.length,
                  itemBuilder: (context, index) {
                    final product = box.getAt(index);
                    return ListTile(
                      title: Text(product!.name),
                      subtitle: Text('\$${product.price.toStringAsFixed(2)}'),
                      trailing: currentUser.role == 'Admin'
                          ? Row(
                        mainAxisSize: MainAxisSize.min,
                        children: [
                          IconButton(
                            icon: Icon(Icons.edit, color: Colors.blue),
                            onPressed: () => _showEditProductDialog(context, product, index),
                          ),
                          IconButton(
                            icon: Icon(Icons.delete, color: Colors.red),
                            onPressed: () => deleteProduct(product,index),
                          ),
                        ],
                      )
                          : null,
                    );
                  },
                );
              },
            ),
          ),
        ],
      ),
    );
  }

  void _showAddProductDialog(BuildContext context) {
    final _nameController = TextEditingController();
    final _descriptionController = TextEditingController();
    final _priceController = TextEditingController();

    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          title: Text('Add Product'),
          content: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextField(controller: _nameController, decoration: InputDecoration(labelText: 'Name')),
              TextField(controller: _descriptionController, decoration: InputDecoration(labelText: 'Description')),
              TextField(controller: _priceController, decoration: InputDecoration(labelText: 'Price'), keyboardType: TextInputType.number),
            ],
          ),
          actions: [
            TextButton(
              onPressed: () {
                final name = _nameController.text;
                final description = _descriptionController.text;
                final price = double.tryParse(_priceController.text) ?? 0.0;
                _addProduct(name, description, price);
                Navigator.of(context).pop();
              },
              child: Text('Add'),
            ),
          ],
        );
      },
    );
  }

  void _showEditProductDialog(BuildContext context, Product product, int index) {
    final _nameController = TextEditingController(text: product.name);
    final _descriptionController = TextEditingController(text: product.description);
    final _priceController = TextEditingController(text: product.price.toString());

    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          title: Text('Edit Product'),
          content: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              TextField(controller: _nameController, decoration: InputDecoration(labelText: 'Name')),
              TextField(controller: _descriptionController, decoration: InputDecoration(labelText: 'Description')),
              TextField(controller: _priceController, decoration: InputDecoration(labelText: 'Price'), keyboardType: TextInputType.number),
            ],
          ),
          actions: [
            TextButton(
              onPressed: () {
                final updatedName = _nameController.text;
                final updatedDescription = _descriptionController.text;
                final updatedPrice = double.tryParse(_priceController.text) ?? product.price;

                _updateProduct(index, updatedName, updatedDescription, updatedPrice);
                Navigator.of(context).pop();
              },
              child: Text('Update'),
            ),
          ],
        );
      },
    );
  }

  void _addProduct(String name, String description, double price) {
    final id = DateTime.now().millisecondsSinceEpoch.toString();
    final product = Product(id: id, name: name, description: description, price: price);
    _productBox.add(product);
  }

  void _updateProduct(int index, String name, String description, double price) {
    final product = _productBox.getAt(index);
    if (product != null) {
      _productBox.putAt(
        index,
        Product(id: product.id, name: name, description: description, price: price),
      );
    }
  }


  void deleteProduct(Product product,int index ) {
    // Удаляем товар из списка продуктов
    _productBox.deleteAt(index);

// Удаляем товар из списка избранного у всех пользователей
    final favoriteKeys = favoriteBox.keys.where((key) {
      final favorite = favoriteBox.get(key);
      return favorite?.itemId == product.id;
    }).toList();

    for (final key in favoriteKeys) {
      favoriteBox.delete(key);
    }


    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(content: Text('${product.name} has been removed!')),
    );
  }


}

