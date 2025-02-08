import 'main.dart';

extension PlayerSerialization on Player {
  Map<String, dynamic> toJson() {
    return {
      'name': name,
      'health': health,
      'level': level,
      'weapon': weapon,
    };
  }

  static Player fromJson(Map<String, dynamic> json) {
    return Player.withWeapon(json['name'], json['health'], json['level'], json['weapon']);
  }
}