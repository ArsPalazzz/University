class Dish {
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

  factory Dish.fromJson(Map<String, dynamic> json) {
    return Dish(
      name: json['name'],
      description: json['description'],
      price: json['price'],
      image: json['image'],
      updated: json['updated'],
      rate: json['rate'],
      timeStamp: json['timeStamp'],
      weight: json['weight'],
      isSpicy: json['isSpicy'],
      isPopular: json['isPopular'],
    );
  }
}
