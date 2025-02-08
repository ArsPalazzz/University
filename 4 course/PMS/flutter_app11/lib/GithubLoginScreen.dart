import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'AuthService.dart';
import 'FootListScreen.dart';

class GitHubLoginScreen extends StatelessWidget {
  const GitHubLoginScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final authService = Provider.of<AuthService>(context, listen: false);

    return Scaffold(
      appBar: AppBar(title: const Text('GitHub Login')),
      body: Center(
        child: ElevatedButton(
          onPressed: () async {
            try {
              final user = await authService.signInWithGitHub();
              if (user != null) {
                ScaffoldMessenger.of(context).showSnackBar(
                  SnackBar(content: Text('Добро пожаловать, ${user.displayName}')),
                );
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => FoodListScreen(),
                  ),
                );
              }
            } catch (e) {
              ScaffoldMessenger.of(context).showSnackBar(
                SnackBar(content: Text('Ошибка: $e')),
              );
            }
          },
          child: const Text('Войти через GitHub'),
        ),
      ),
    );
  }

  // Future<String?> _getGitHubTokenFromUser() async {
  //   final flutterWebviewPlugin = FlutterWebviewPlugin();
  //
  //   // URL для GitHub OAuth авторизации
  //   final authorizationUrl = Uri.https('github.com', '/login/oauth/authorize', {
  //     'client_id': '<YOUR_CLIENT_ID>',
  //     'redirect_uri': 'https://<ваш_project_id>.firebaseapp.com/__/auth/handler',
  //     'scope': 'read:user user:email',
  //   });
  //
  //   // Прослушивание изменения URL
  //   String? token;
  //   flutterWebviewPlugin.onUrlChanged.listen((String url) {
  //     if (url.contains('code=')) {
  //       // Извлечение токена из URL
  //       final code = Uri.parse(url).queryParameters['code'];
  //       token = code; // GitHub вернёт временный `code`, который используется для получения токена.
  //       flutterWebviewPlugin.close();
  //     }
  //   });
  //
  //   // Открываем веб-страницу
  //   flutterWebviewPlugin.launch(authorizationUrl.toString());
  //
  //   // Ждём завершения
  //   await flutterWebviewPlugin.onDestroy.first;
  //   return token;
  // }
}
