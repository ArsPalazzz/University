import 'package:flutter/material.dart';
import 'package:firebase_auth/firebase_auth.dart';

class UserProfileScreen extends StatelessWidget {
  const UserProfileScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final User? user = FirebaseAuth.instance.currentUser;

    return Scaffold(
      appBar: AppBar(title: const Text('Профиль')),
      body: user == null
          ? const Center(
        child: Text('Пользователь не авторизован'),
      )
          : Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'Имя пользователя:',
              style: Theme.of(context).textTheme.headlineSmall,
            ),
            Text(
              user.displayName ?? 'Имя не указано',
              style: const TextStyle(fontSize: 16),
            ),
            const SizedBox(height: 16),
            Text(
              'Email:',
              style: Theme.of(context).textTheme.headlineSmall,
            ),
            Text(
              user.email ?? 'Email не указан',
              style: const TextStyle(fontSize: 16),
            ),
            const SizedBox(height: 16),
            Text(
              'UID:',
              style: Theme.of(context).textTheme.headlineSmall,
            ),
            Text(
              user.uid,
              style: const TextStyle(fontSize: 16),
            ),
            const SizedBox(height: 16),
            ElevatedButton(
              onPressed: () async {
                await FirebaseAuth.instance.signOut();
                Navigator.of(context).popUntil((route) => route.isFirst);
              },
              child: const Text('Выйти'),
            ),
          ],
        ),
      ),
    );
  }
}
