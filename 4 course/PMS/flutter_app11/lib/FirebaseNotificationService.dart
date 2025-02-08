import 'package:firebase_messaging/firebase_messaging.dart';
import 'package:flutter/material.dart';

import 'NotificationScreen.dart';

class FirebaseNotificationService {
  // Метод для инициализации Firebase Messaging
  static void initialize(BuildContext context) async {
    // 1. Прослушивание уведомлений при открытии приложения
    FirebaseMessaging.onMessage.listen((RemoteMessage message) {
      print('Сообщение в foreground: ${message.notification?.title}');
    });

    // 2. Обработка клика по уведомлению при открытии приложения
    FirebaseMessaging.onMessageOpenedApp.listen((RemoteMessage message) {
      print('Сообщение открыто через клик: ${message.notification?.title}');
      Navigator.push(
        context,
        MaterialPageRoute(builder: (context) => NotificationScreen()),
      );
    });

    // 3. Получение токена
    String? token = await FirebaseMessaging.instance.getToken();
    print('Токен устройства: $token');
  }
}
