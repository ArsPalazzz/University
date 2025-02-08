import 'package:firebase_auth/firebase_auth.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:firebase_messaging/firebase_messaging.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

import 'AuthService.dart';
import 'DishRepository.dart';
import 'FootListScreen.dart';
import 'LoginScreen.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp();

  // Инициализация Firebase Messaging
  await initializeFirebaseMessaging();

  runApp(
    MultiProvider(
      providers: [
        Provider<AuthService>(
          create: (_) => AuthService(),
        ),
        Provider<DishRepository>(
          create: (_) => DishRepository(),
        ),
      ],
      child: const FoodApp(),
    ),
  );
}

/// Метод инициализации Firebase Messaging
Future<void> initializeFirebaseMessaging() async {
  // Получаем токен устройства и печатаем его
  String? token = await FirebaseMessaging.instance.getToken();
  print("Токен устройства: $token");

  // Обработка уведомлений при foreground
  FirebaseMessaging.onMessage.listen((RemoteMessage message) {
    print("Сообщение в foreground: ${message.notification?.title}");
  });

  // Обработка уведомлений при клике
  FirebaseMessaging.onMessageOpenedApp.listen((RemoteMessage message) {
    print("Открыли уведомление: ${message.notification?.title}");
  });
}

class FoodApp extends StatelessWidget {
  const FoodApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        textTheme: GoogleFonts.poppinsTextTheme(),
        primaryColor: Colors.orange,
      ),
      home: const AuthWrapper(),
    );
  }
}

class AuthWrapper extends StatelessWidget {
  const AuthWrapper({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return StreamBuilder<User?>(
      stream: FirebaseAuth.instance.authStateChanges(),
      builder: (context, snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const Center(child: CircularProgressIndicator());
        }

        // Если пользователь авторизован, показываем FoodListScreen
        if (snapshot.hasData) {
          return FoodListScreen();
        }

        // Если пользователь не авторизован, показываем LoginScreen
        return LoginScreen();
      },
    );
  }
}




