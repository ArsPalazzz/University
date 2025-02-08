import 'package:flutter/material.dart';
import 'package:hive/hive.dart';
import './user.dart';
import 'package:hive_flutter/hive_flutter.dart';
import 'package:flutter/material.dart';
import 'package:hive/hive.dart';

class UserPage extends StatefulWidget {
  @override
  _UserPageState createState() => _UserPageState();
}

class _UserPageState extends State<UserPage> {
  final _userBox = Hive.box<User>('users');

  // Переменная для текущего пользователя
  late User currentUser;

  @override
  void initState() {
    super.initState();
    _initializeUser();
  }

  void _initializeUser() {
    if (_userBox.isEmpty) {
      // Если данных нет, создаем пользователя по умолчанию
      currentUser = User(name: 'Default User', role: 'User');
      _userBox.put('currentUser', currentUser);
    } else {
      currentUser = _userBox.get('currentUser')!;
    }
    setState(() {});
  }

  void _switchRole(String role) {
    currentUser = User(name: currentUser.name, role: role);
    _userBox.put('currentUser', currentUser);
    setState(() {
      Hive.box<User>('users').put('currentUser', currentUser);
    });
  }
  void _updateFavoritesState() {
    setState(() {
      // Перезагрузка состояния, чтобы сердечки обновились
    });
  }


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('User Settings')),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text('Current Role: ${currentUser.role}', style: TextStyle(fontSize: 20)),
          SizedBox(height: 20),
          ElevatedButton(
            onPressed: () {
              _switchRole('Admin');
              _updateFavoritesState();
            },
            child: Text('Switch to Admin'),
          ),

          ElevatedButton(
            onPressed: () => _switchRole('User'),
            child: Text('Switch to User'),
          ),
        ],
      ),
    );
  }
}
