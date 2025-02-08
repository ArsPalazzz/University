import 'package:flutter/material.dart';
import 'DatabaseHelper.dart';
import 'GameEntityDetailPage.dart';
import 'EditEntityPage.dart';
import 'FileOperationsPage.dart';
import 'models/Entities.dart';

class GameEntityListPage extends StatefulWidget {
  @override
  _GameEntityListPageState createState() => _GameEntityListPageState();
}

class _GameEntityListPageState extends State<GameEntityListPage> {
  late Future<List<GameEntity>> gameEntityList;

  @override
  void initState() {
    super.initState();
    _loadGameEntityList();
  }

  void _loadGameEntityList() {
    gameEntityList = DatabaseHelper.instance.readAllEntities();
  }

  void _refreshGameEntityList() {
    setState(() {
      _loadGameEntityList();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Game Entities'),
        actions: [
          IconButton(
            icon: Icon(Icons.file_copy),
            onPressed: () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => FutureBuilder<List<GameEntity>>(
                    future: gameEntityList,
                    builder: (context, snapshot) {
                      if (snapshot.connectionState == ConnectionState.waiting) {
                        return Center(child: CircularProgressIndicator());
                      } else if (snapshot.hasError) {
                        return Center(child: Text('Error: ${snapshot.error}'));
                      } else {
                        return FileOperationsPage(entityList: snapshot.data!); // Исправлено на entityList
                      }
                    },
                  ),
                ),
              );
            },
          ),
        ],
      ),
      body: FutureBuilder<List<GameEntity>>(
        future: gameEntityList,
        builder: (context, snapshot) {
          if (!snapshot.hasData) {
            return Center(child: CircularProgressIndicator());
          }
          return ListView.builder(
            itemCount: snapshot.data!.length,
            itemBuilder: (context, index) {
              final entity = snapshot.data![index];
              return ListTile(
                title: Text(entity.name),
                subtitle: Text(entity.description),
                onTap: () => Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => GameEntityDetailPage(
                      entity: entity, // Исправлено на entity
                      onUpdate: _refreshGameEntityList,
                    ),
                  ),
                ),
              );
            },
          );
        },
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => EditEntityPage(),
            ),
          ).then((_) {
            _refreshGameEntityList();
          });
        },
        child: Icon(Icons.add),
      ),
    );
  }
}
