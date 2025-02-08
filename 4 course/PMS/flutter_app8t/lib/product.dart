import 'package:hive/hive.dart';

part 'product.g.dart';

@HiveType(typeId: 2)
class Product {
  @HiveField(0)
  final String id;

  @HiveField(1)
  final String name;

  @HiveField(2)
  final String description;

  @HiveField(3)
  final double price;

  Product({
    required this.id,
    required this.name,
    required this.description,
    required this.price,
  });
}
