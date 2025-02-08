import 'package:flutter/material.dart';

class NotificationScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Уведомления'),
      ),
      body: Center(
        child: Text(
          'Вы перешли по уведомлению!',
          style: TextStyle(fontSize: 20),
        ),
      ),
    );
  }
}
