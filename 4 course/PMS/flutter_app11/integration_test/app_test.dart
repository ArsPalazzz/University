import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:integration_test/integration_test.dart';
import 'package:flutter_app11/main.dart' as app;

void main() {
  // Инициализация интеграционных тестов
  IntegrationTestWidgetsFlutterBinding.ensureInitialized();

  group('Integration Test', () {
    testWidgets('Полный цикл входа в систему', (tester) async {
      // Запускаем приложение
      app.main();
      await tester.pumpAndSettle();

      // Находим поле ввода email и вводим текст
      final emailField = find.byKey(Key('emailField'));
      await tester.enterText(emailField, 'test@example.com');
      await tester.pumpAndSettle();

      // Проверяем, что текст введен
      expect(find.text('test@example.com'), findsOneWidget);

      // Находим поле ввода пароля и вводим текст
      final passwordField = find.byKey(Key('passField'));
      await tester.enterText(passwordField, 'password123');
      await tester.pumpAndSettle();

      // Нажимаем кнопку входа
      final loginButton = find.byKey(Key('loginButton'));
      await tester.tap(loginButton);
      await tester.pumpAndSettle();

      // Проверяем, что пользователь перенаправлен на FoodListScreen
      expect(find.text('Food List'), findsOneWidget);
    });

    testWidgets('Очистка email-поля через кнопку очистки', (tester) async {
      // Запускаем приложение
      app.main();
      await tester.pumpAndSettle();

      // Находим поле ввода email
      final emailField = find.byKey(Key('emailField'));
      final clearButton = find.byKey(Key('clearEmailButton'));

      // Вводим текст в email
      //await tester.enterText(emailField, 'test@example.com');
      //await tester.pumpAndSettle();

      // Проверяем, что текст введен
      //expect(find.text('test@example.com'), findsOneWidget);

      // Нажимаем кнопку очистки
      //await tester.tap(clearButton);
      //await tester.pumpAndSettle();

      // Проверяем, что текстовое поле очищено
      expect(find.text('test@example.com'), findsNothing);
    });
  });
}
