import 'package:flutter/material.dart';
import 'GameEntityListPage.dart';

void main() async {
  runApp(GameApp());
}

class GameApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Games',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: GameEntityListPage(),
    );
  }
}
