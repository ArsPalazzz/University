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

class Player extends GameEntity implements Character {
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

  // Метод с именованным параметром
  void heal({required int amount}) {
    health += amount;
    print('$name исцелен на $amount, текущее здоровье: $health');
  }

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


class Enemy extends GameEntity {
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

void main() {
  // Создаем игроков
  Player player1 = Player('Knight', 100, 1);
  Player player2 = Player.withWeapon('Archer', 80, 2, 'Bow');

  // Работа с массивом
  List<Player> players = [player1, player2];
  List<Player> reversedPlayers = players.reversed.toList();
  print('Перевернутый массив: $reversedPlayers');

  // Работа с коллекцией (List)
  List<GameEntity> entities = [];
  entities.addAll(players);
  entities.add(Enemy('Goblin', 50, 'Monster'));

  // Работа с множеством (Set)
  Set<String> items = {'Sword', 'Shield'};
  items.add('Bow');
  items.add('Shield'); // Повторяющийся элемент не добавится

  // Вывод содержимого коллекций
  for (var entity in entities) {
    entity.move();
  }

  print('Айтемы игрока: $items');

  // Работа с continue и break
  for (var i = 0; i < entities.length; i++) {
    if (entities[i].health <= 0) continue;
    print('${entities[i].name} жив');
    if (i == 1) break; // Прерываем после второго элемента
  }

  // Обработка исключений
  try {
    int experience = 100 ~/ 0; // Исключение деления на ноль
    print('Полученный опыт: $experience');
  } catch (e) {
    print('Ошибка: $e');
  } finally {
    print('Игра продолжается.');
  }

  // Использование статического метода и поля
  GameEntity.totalEntities = entities.length;
  GameEntity.displayTotalEntities();

  // Демонстрация использования методов класса Player
  player1.attack();
  player1.defend();
  player1.takeDamage(30);
  player1.heal(amount: 20);
  player1.collectReward(50);

  // Демонстрация повышения уровня с использованием callback-функции
  player1.onLevelUp((newLevel) {
    print('Уровень игрока ${player1.name} повысился до $newLevel');
  });
}