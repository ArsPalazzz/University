import 'main.dart';

mixin HealingAbility {
  void heal(int amount) {
    if (this is GameEntity) {
      (this as GameEntity).health += amount;
      print('${(this as GameEntity).name} исцелен на $amount, текущее здоровье: ${(this as GameEntity).health}');
    }
  }
}