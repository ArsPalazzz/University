import 'package:flutter_test/flutter_test.dart';
import 'package:mockito/mockito.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:mockito/annotations.dart';
import 'mocks.mocks.dart';
import '../lib/AuthService.dart';

void main() {
  TestWidgetsFlutterBinding.ensureInitialized();

  late AuthService authService;
  late MockFirebaseAuth mockFirebaseAuth;
  late MockUserCredential mockUserCredential;
  late MockUser mockUser;

  setUp(() {
    mockFirebaseAuth = MockFirebaseAuth();
    mockUserCredential = MockUserCredential();

    mockUser = MockUser();
    authService = AuthService(firebaseAuth: mockFirebaseAuth);
  });

  test('Успешный вход пользователя', () async {
    // Настройка мока
    when(mockFirebaseAuth.signInWithEmailAndPassword(
      email: anyNamed('email'),
      password: anyNamed('password'),
    )).thenAnswer((_) async => mockUserCredential);

    when(mockUserCredential.user).thenReturn(mockUser);

    // Выполнение
    final user = await authService.login('test@example.com', 'password');

    // Проверка
    expect(user, mockUser);
    verify(mockFirebaseAuth.signInWithEmailAndPassword(
      email: 'test@example.com',
      password: 'password',
    )).called(1);
  });

  test('Неудачный вход пользователя', () async {
    // Настройка мока
    when(mockFirebaseAuth.signInWithEmailAndPassword(
      email: anyNamed('email'),
      password: anyNamed('password'),
    )).thenThrow(FirebaseAuthException(code: 'user-not-found'));

    // Выполнение
    final user = await authService.login('test@example.com', 'wrongpassword');

    // Проверка
    expect(user, null);
    verify(mockFirebaseAuth.signInWithEmailAndPassword(
      email: 'test@example.com',
      password: 'wrongpassword',
    )).called(1);
  });

  test('Выход пользователя', () async {
    // Выполнение
    await authService.logout();

    // Проверка
    verify(mockFirebaseAuth.signOut()).called(1);
  });
}
