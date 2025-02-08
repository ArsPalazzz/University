import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';
import 'models/Entities.dart';
import 'dart:developer';

class DatabaseHelper {
  static final DatabaseHelper instance = DatabaseHelper._init();
  static Database? _database;

  DatabaseHelper._init();

  Future<Database> get database async {
    if (_database != null) return _database!;
    _database = await _initDB('game_entities.db');
    return _database!;
  }

  Future<Database> _initDB(String filePath) async {
    final dbPath = await getDatabasesPath();
    final path = join(dbPath, filePath);
    log("Initializing database at path: $path");  // Лог для отслеживания пути базы данных
    return await openDatabase(path, version: 1, onCreate: _createDB);
  }

  Future _createDB(Database db, int version) async {
    log("Creating table game_entity"); // Лог для отслеживания создания таблицы
    await db.execute('''CREATE TABLE game_entity (
      ${GameEntityFields.id} INTEGER PRIMARY KEY AUTOINCREMENT,
      ${GameEntityFields.name} TEXT NOT NULL,
      ${GameEntityFields.type} TEXT NOT NULL,
      ${GameEntityFields.description} TEXT NOT NULL
    )''');
  }

  Future<GameEntity> create(GameEntity entity) async {
    final db = await instance.database;
    final id = await db.insert(tableGameEntity, entity.toJson());
    return entity.copy(id: id);
  }

  Future<GameEntity> readEntity(int id) async {
    final db = await instance.database;
    final maps = await db.query(
      tableGameEntity,
      columns: GameEntityFields.values,
      where: '${GameEntityFields.id} = ?',
      whereArgs: [id],
    );

    if (maps.isNotEmpty) {
      return GameEntity.fromJson(maps.first);
    } else {
      throw Exception('ID $id not found');
    }
  }

  Future<List<GameEntity>> readAllEntities() async {
    final db = await instance.database;
    final result = await db.query(tableGameEntity);
    return result.map((json) => GameEntity.fromJson(json)).toList();
  }

  Future<int> update(GameEntity entity) async {
    final db = await instance.database;
    return db.update(
      tableGameEntity,
      entity.toJson(),
      where: '${GameEntityFields.id} = ?',
      whereArgs: [entity.id],
    );
  }

  Future<int> delete(int id) async {
    final db = await instance.database;
    return db.delete(
      tableGameEntity,
      where: '${GameEntityFields.id} = ?',
      whereArgs: [id],
    );
  }
}
