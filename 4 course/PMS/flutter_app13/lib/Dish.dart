class Dish {
  final String id;
  final String name;
  final String description;
  final double price;
  final String image;
  final String updated;
  final String rate;
  final String timeStamp;
  final int weight;
  final bool isSpicy;
  final bool isPopular;

  Dish({
    required this.id,
    required this.name,
    required this.description,
    required this.price,
    required this.image,
    required this.updated,
    required this.rate,
    required this.timeStamp,
    required this.weight,
    required this.isSpicy,
    required this.isPopular,
  });

  Map<String, dynamic> toMap() {
    return {
      'name': name,
      'description': description,
      'price': price,
      'image': image,
      'updated': updated,
      'rate': rate,
      'timeStamp': timeStamp,
      'weight': weight,
      'isSpicy': isSpicy,
      'isPopular': isPopular,
    };
  }

  factory Dish.fromMap(String id, Map<String, dynamic> map) {
    return Dish(
      id: id,
      name: map['name'],
      description: map['description'],
      price: map['price'],
      image: map['image'],
      updated: map['updated'],
      rate: map['rate'],
      timeStamp: map['timeStamp'],
      weight: map['weight'],
      isSpicy: map['isSpicy'],
      isPopular: map['isPopular'],
    );
  }


  factory Dish.fromFirestore(String id, Map<String, dynamic> map) {
    return Dish(
      id: id,
      name: map['name'] ?? '',
      description: map['description'] ?? '',
      price: (map['price'] as num?)?.toDouble() ?? 0.0,
      image: map['image'] ?? '',
      updated: map['updated'] ?? '',
      rate: map['rate'] ?? '',
      timeStamp: map['timeStamp'] ?? '',
      weight: map['weight'] ?? 0,
      isSpicy: map['isSpicy'] ?? false,
      isPopular: map['isPopular'] ?? false,
    );
  }
}
