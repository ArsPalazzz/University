import 'package:hive/hive.dart';

part 'dish_model.g.dart';

@HiveType(typeId: 1)
class DishModel extends HiveObject {
  @HiveField(0)
  String id;

  @HiveField(1)
  String name;

  @HiveField(2)
  String description;

  @HiveField(3)
  double price;

  @HiveField(4)
  int weight;

  @HiveField(5)
  String image;

  @HiveField(6)
  String updated;

  @HiveField(7)
  String rate;

  @HiveField(8)
  String timeStamp;

  @HiveField(9)
  bool isSpicy;

  @HiveField(10)
  bool isPopular;

  DishModel({
    required this.id,
    required this.name,
    required this.description,
    required this.price,
    required this.weight,
    required this.image,
    required this.updated,
    required this.rate,
    required this.timeStamp,
    required this.isSpicy,
    required this.isPopular,
  });
}
