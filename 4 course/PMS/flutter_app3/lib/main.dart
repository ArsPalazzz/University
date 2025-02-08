import 'dart:async';
import 'dart:convert';

import 'interfaces.dart';
import 'mixins.dart';
import 'serialization.dart';
import 'async_operations.dart';

// Интерфейс для персонажей
abstract class Character {
  void attack();
  void defend();
}

// Абстрактный класс, представляющий игровую сущность
abstract class GameEntity {
  String name;
  int health;

  GameEntity(this.name, this.health);

  void move();
  void takeDamage(int damage);

  // Статическое поле и метод
  static int totalEntities = 0;
  static void displayTotalEntities() {
    print('Всего игровых сущностей: $totalEntities');
  }
}

class Player extends GameEntity with HealingAbility implements Character, Comparable<Player> {
  int level;
  String? weapon;

  Player.withWeapon(String name, int health, this.level, this.weapon)
      : super(name, health);

  Player(String name, int health, this.level) : super(name, health);


  @override
  void move() {
    print('$name передвигается');
  }

  @override
  void attack() {
    if (weapon != null) {
      print('$name атакует с помощью $weapon');
    } else {
      print('$name атакует без оружия');
    }
  }

  @override
  int compareTo(Player other) {
    return this.level.compareTo(other.level); // Сравниваем по уровню
  }

  @override
  void defend() {
    print('$name защищается');
  }


  @override
  void takeDamage(int damage) {
    health -= damage;
    if (health <= 0) {
      print('$name умер');
    } else {
      print('$name получил $damage урона, осталось $health здоровья');
    }
  }

  int get playerLevel => level;
  set playerLevel(int newLevel) => level = newLevel;

  // Метод с параметром по умолчанию
  void collectReward([int reward = 10]) {
    print('$name получил награду: $reward золота');
  }

  // Метод с параметром типа функция
  void onLevelUp(void Function(int) callback) {
    level++;
    callback(level);
  }
}

class Enemy extends GameEntity with HealingAbility {
  String type;

  Enemy(String name, int health, this.type) : super(name, health);

  @override
  void move() {
    print('$name ($type) перемещается');
  }

  @override
  void takeDamage(int damage) {
    health -= damage;
    if (health <= 0) {
      print('$name ($type) уничтожен');
    } else {
      print('$name ($type) получил $damage урона, осталось $health здоровья');
    }
  }
}

void main() async {
  Player player1 = Player.withWeapon('Archer', 80, 2, 'Bow');
  Player player2 = Player.withWeapon('Archer2', 80, 2, 'Bow');
  String jsonString = jsonEncode(player1.toJson());
  print('Сериализованный игрок: $jsonString');

  Player deserializedPlayer = PlayerSerialization.fromJson(jsonDecode(jsonString));
  print('Десериализованный игрок: ${deserializedPlayer.name}');


  List<Player> players = [player1, player2];

  // Демонстрация использования методов класса Player
  player1.attack();
  player1.defend();
  player1.takeDamage(30);
  player1.heal(20);
  player1.collectReward(50);

  PlayerCollection playerCollection = PlayerCollection(players);
  for (Player player in playerCollection) {
    print(player.name);
  }

  player1.onLevelUp((newLevel) {
    print('Уровень игрока ${player1.name} повысился до $newLevel');
  });

  print('CompareTo: ${player1.compareTo(player2)}');

  Enemy goblin = Enemy('Goblin', 50, 'Monster');
  goblin.takeDamage(20);
  goblin.heal(10);

  Player playerAwait = Player.withWeapon('Knight', 100, 1, 'Sword');
  await simulateLoadingPlayerData(playerAwait);
  print('Игра продолжается с игроком: ${playerAwait.name}');


  await for (int value in countdown(5)) {
    print('Отсчет: $value');
  }


  Stream<int> stream = createBroadcastStream(5);

  stream.listen((event) {
    print('Listener 1: $event');
  });

  stream.listen((event) {
    print('Listener 2: $event');
  });
}