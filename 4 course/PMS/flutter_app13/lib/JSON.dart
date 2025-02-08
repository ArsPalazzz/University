import 'dart:convert';
import 'package:flutter/services.dart' show rootBundle;

import 'Dish.dart';

Future<List<Dish>> loadDishes() async {
  final String response = await rootBundle.loadString('assets/dishes.json');
  final List<dynamic> data = json.decode(response);
  return data.map((json) => Dish.fromMap('', json)).toList();
}
