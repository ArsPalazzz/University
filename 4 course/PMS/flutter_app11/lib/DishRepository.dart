import 'package:cloud_firestore/cloud_firestore.dart';

import 'Dish.dart';

class DishRepository {
  final CollectionReference _dishCollection =
  FirebaseFirestore.instance.collection('dishes');

  Future<void> createDish(Dish dish) async {
    await _dishCollection.add(dish.toMap());
  }

  Future<List<Dish>> readDishes() async {
    final querySnapshot = await _dishCollection.get();
    return querySnapshot.docs
        .map((doc) => Dish.fromMap(doc.id, doc.data() as Map<String, dynamic>))
        .toList();
  }

  Future<void> updateDish(Dish dish) async {
    await _dishCollection.doc(dish.id).update(dish.toMap());
  }

  Future<void> deleteDish(String id) async {
    await _dishCollection.doc(id).delete();
  }
}
