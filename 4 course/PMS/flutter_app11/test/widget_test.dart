import 'package:firebase_core/firebase_core.dart';
import 'package:flutter_app11/CheckboxScreen.dart';
import 'package:flutter_app11/FootListScreen.dart';
import 'package:flutter_app11/SliderScreen.dart';
import 'package:flutter_test/flutter_test.dart';
import 'package:flutter/material.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';
import 'package:flutter_app11/AuthService.dart';
import 'package:flutter_app11/LoginScreen.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:mockito/mockito.dart';
import 'package:flutter_test/flutter_test.dart';

import 'mock.dart';

// class MockFirebaseApp extends Mock implements FirebaseApp {}
// class MockFirebaseAuth extends Mock implements FirebaseAuth {}


void main() {
  setupFirebaseAuthMocks();

  setUpAll(() async {
    await Firebase.initializeApp();
  });

  testWidgets('Ввод текста в поле email', (WidgetTester tester) async {
    // Строим виджет
    await tester.pumpWidget(MaterialApp(
      home: LoginScreen(),
    ));

    // Находим текстовое поле для email
    final emailField = find.byKey(Key('emailField'));

    // Проверяем, что поле найдено
    expect(emailField, findsOneWidget);

    // Вводим текст в поле
    await tester.enterText(emailField, 'test@example.com');
    await tester.pump(); // Ждем, чтобы изменения вступили в силу

    // Проверяем, что введенный текст совпадает
    expect(find.text('test@example.com'), findsOneWidget);
  });

  testWidgets('Нажатие на кнопку Login', (WidgetTester tester) async {
    // Строим виджет
    await tester.pumpWidget(MaterialApp(
      home: LoginScreen(),
    ));

    final emailField = find.byKey(Key('emailField'));
    final passwordField = find.byKey(Key('passField'));
    final loginButton = find.byKey(Key('loginButton'));

    // Вводим данные
    await tester.enterText(emailField, 'test@example.com');
    await tester.enterText(passwordField, 'password123');
    await tester.tap(loginButton);
    await tester.pump();

    expect(find.text('Вы успешно вошли'), findsOneWidget);
  });


  testWidgets('Перетаскивание ползунка', (WidgetTester tester) async {
    // Строим виджет с ползунком
    await tester.pumpWidget(MaterialApp(
      home: SliderScreen(),
    ));

    // Находим слайдер
    final slider = find.byKey(Key('volumeSlider'));

    // Проверяем, что слайдер существует
    expect(slider, findsOneWidget);

    // Перетаскиваем слайдер
    await tester.drag(slider, Offset(100.0, 0.0)); // Перемещение вправо
    await tester.pump();

    // Проверяем, что значение слайдера обновилось
    final sliderWidget = tester.widget<Slider>(slider);
    expect(sliderWidget.value, greaterThan(0.5));
  });

  testWidgets('Переключение чекбокса', (WidgetTester tester) async {
    // Строим виджет с чекбоксом
    await tester.pumpWidget(MaterialApp(
      home: CheckboxScreen(), // Предполагаем, что CheckboxScreen содержит чекбокс
    ));

    // Находим чекбокс
    final checkbox = find.byKey(Key('acceptTermsCheckbox'));

    // Проверяем, что чекбокс существует
    expect(checkbox, findsOneWidget);

    // Нажимаем на чекбокс
    await tester.tap(checkbox);
    await tester.pump();

    // Проверка: убедитесь, что состояние чекбокса изменилось
    final checkboxWidget = tester.widget<Checkbox>(checkbox);
    expect(checkboxWidget.value, isTrue);
  });

  testWidgets('Очистка текстового поля', (WidgetTester tester) async {
    // Строим виджет
    await tester.pumpWidget(MaterialApp(
      home: LoginScreen(),
    ));

    // Находим текстовое поле для email
    final emailField = find.byKey(Key('emailField'));
    final clearButton = find.byKey(Key('clearEmailButton'));

    // Вводим текст в поле
    await tester.enterText(emailField, 'test@example.com');
    await tester.pump();

    // Проверяем, что текст введен
    expect(find.text('test@example.com'), findsOneWidget);

    // Нажимаем кнопку очистки
    await tester.tap(clearButton);
    await tester.pump();

    // Проверяем, что текстовое поле очищено
    expect(find.text('test@example.com'), findsNothing);
  });

}
