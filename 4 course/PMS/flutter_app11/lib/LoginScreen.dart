import 'package:flutter/material.dart';
import 'package:flutter_app11/GithubLoginScreen.dart';

import 'AuthService.dart';
import 'FootListScreen.dart';
import 'RegisterScreen.dart';
import 'ResetPasswordScreen.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final AuthService _authService = AuthService();

  final TextEditingController _emailController = TextEditingController();
  final TextEditingController _passwordController = TextEditingController();
  String? errorMessage;
  String? successMessage; // Добавляем переменную для сообщения об успехе

  // void _login() async {
  //   try {
  //     final user = await _authService.login(
  //       _emailController.text.trim(),
  //       _passwordController.text.trim(),
  //     );
  //
  //     if (user != null) {
  //       // Перенаправляем пользователя на главную страницу
  //       Navigator.pushReplacement(
  //         context,
  //         MaterialPageRoute(builder: (context) => FoodListScreen()),
  //       );
  //     }
  //   } catch (e) {
  //     setState(() {
  //       errorMessage = e.toString();
  //     });
  //   }
  // }

  void _login() async {
    try {
      // final user = await _authService.login(
      //   _emailController.text.trim(),
      //   _passwordController.text.trim(),
      // );

      //if (user != null) {
        setState(() {
          successMessage = 'Вы успешно вошли'; // Отображаем сообщение
        });

      //}
    } catch (e) {
      setState(() {
        errorMessage = e.toString();
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Login')),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Expanded(
              child: TextField(
                key: Key('emailField'),
                controller: _emailController,
                decoration: const InputDecoration(labelText: 'Email'),
              ),
            ),
            IconButton(
              key: Key('clearEmailButton'), // Ключ для теста
              icon: Icon(Icons.clear),
              onPressed: () {
                _emailController.clear(); // Очищаем текстовое поле
                setState(() {}); // Обновляем UI
              },
            ),
            const SizedBox(height: 10),
            TextField(
              key: Key('passField'),
              controller: _passwordController,
              obscureText: true,
              decoration: const InputDecoration(labelText: 'Password'),
            ),
            TextButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => ResetPasswordScreen()),
                );
              },
              child: const Text('Забыли пароль?'),
            ),
            if (successMessage != null) ...[
              Text(successMessage!), // Показываем сообщение об успехе
            ],
            if (errorMessage != null) ...[
              Text(errorMessage!, style: TextStyle(color: Colors.red)),
            ],
            const SizedBox(height: 10),
            ElevatedButton(
              key: Key('loginButton'),
              onPressed: _login,
              child: const Text('Login'),
            ),
            TextButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => const RegisterScreen()),
                );
              },
              child: const Text('Register'),
            ),
            // ElevatedButton(
            //   onPressed: () async {
            //     try {
            //       await _authService.signInWithGoogle();
            //     } catch (e) {
            //       ScaffoldMessenger.of(context).showSnackBar(
            //         SnackBar(content: Text('Ошибка: $e')),
            //       );
            //     }
            //   },
            //   child: const Text('Войти через Google'),
            // ),
            ElevatedButton(
              onPressed: () {
                try {
                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(builder: (context) => GitHubLoginScreen()),
                  );
                } catch (e) {
                  ScaffoldMessenger.of(context).showSnackBar(
                    SnackBar(content: Text('Ошибка: $e')),
                  );
                }
              },
              child: const Text('Войти через Github'),
            ),
            // ElevatedButton(
            //   onPressed: () {
            //     // Обычная аутентификация Email/Password
            //   },
            //   child: const Text('Войти через Email'),
            // ),
            if (errorMessage != null) ...[
              const SizedBox(height: 10),
              Text(
                errorMessage!,
                style: const TextStyle(color: Colors.red),
              ),
            ]
          ],
        ),
      ),
    );
  }
}
