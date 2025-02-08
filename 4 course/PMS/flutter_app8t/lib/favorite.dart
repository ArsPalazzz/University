import 'package:hive/hive.dart';

part 'favorite.g.dart';

@HiveType(typeId: 1)
class Favorite {
  @HiveField(0)
  final String itemId;

  @HiveField(1)
  final String description;

  @HiveField(2)
  final String userId;

  Favorite({required this.itemId, required this.description, required this.userId});
}
