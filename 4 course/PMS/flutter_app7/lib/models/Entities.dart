const String tableGameEntity = 'game_entity';

class GameEntityFields {
  static final List<String> values = [
    id, name, type, description
  ];

  static const String id = '_id';
  static const String name = 'name';
  static const String type = 'type';
  static const String description = 'description';
}

class GameEntity {
  final int? id;
  final String name;
  final String type; // "Enemy" или "Player"
  final String description;

  GameEntity({
    this.id,
    required this.name,
    required this.type,
    required this.description,
  });

  GameEntity copy({int? id, String? name, String? type, String? description}) =>
      GameEntity(
        id: id ?? this.id,
        name: name ?? this.name,
        type: type ?? this.type,
        description: description ?? this.description,
      );

  Map<String, dynamic> toJson() => {
    GameEntityFields.id: id,
    GameEntityFields.name: name,
    GameEntityFields.type: type,
    GameEntityFields.description: description,
  };

  static GameEntity fromJson(Map<String, Object?> json) => GameEntity(
    id: json[GameEntityFields.id] as int?,
    name: json[GameEntityFields.name] as String,
    type: json[GameEntityFields.type] as String,
    description: json[GameEntityFields.description] as String,
  );

  static List<Map<String, dynamic>> listToJson(List<GameEntity> entityList) {
    return entityList.map((entity) => entity.toJson()).toList();
  }

  static List<GameEntity> listFromJson(List<dynamic> jsonList) {
    return jsonList.map((json) => GameEntity.fromJson(json)).toList();
  }
}

class Player extends GameEntity {
  Player({int? id, required String name, required String description})
      : super(id: id, name: name, type: 'Player', description: description);
}

class Enemy extends GameEntity {
  Enemy({int? id, required String name, required String description})
      : super(id: id, name: name, type: 'Enemy', description: description);
}
