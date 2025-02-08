import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/services.dart';
import 'package:google_sign_in/google_sign_in.dart';

class AuthService {
  final FirebaseAuth _auth = FirebaseAuth.instance;
  final GoogleSignIn _googleSignIn = GoogleSignIn();

  Stream<User?> authStateChanges() {
    return _auth.authStateChanges();
  }

  Future<User?> register(String email, String password) async {
    final credential =
    await _auth.createUserWithEmailAndPassword(email: email, password: password);
    return credential.user;
  }

  Future<User?> login(String email, String password) async {
    final credential =
    await _auth.signInWithEmailAndPassword(email: email, password: password);
    return credential.user;
  }


  // Future<User?> signInWithGoogle() async {
  //   try {
  //     // Запуск Google Sign-In
  //     final GoogleSignInAccount? googleUser = await _googleSignIn.signIn();
  //
  //     if (googleUser == null) {
  //       // Если пользователь отменил вход
  //       return null;
  //     }
  //
  //     // Получение токенов Google
  //     final GoogleSignInAuthentication googleAuth =
  //     await googleUser.authentication;
  //
  //     // Создание учетных данных для Firebase
  //     final credential = GoogleAuthProvider.credential(
  //       accessToken: googleAuth.accessToken,
  //       idToken: googleAuth.idToken,
  //     );
  //
  //     // Вход в Firebase с использованием Google
  //     final userCredential = await _auth.signInWithCredential(credential);
  //     return userCredential.user;
  //   } catch (e) {
  //     print('Ошибка входа через Google: $e');
  //     rethrow;
  //   }
  // }

  Future<User?> signInWithGitHub() async {
    try {
      final GithubAuthProvider githubProvider = GithubAuthProvider();

      // Открывает браузер для входа через GitHub
      final UserCredential userCredential =
      await FirebaseAuth.instance.signInWithProvider(githubProvider);

      return userCredential.user;
    } catch (e) {
      print('Ошибка входа через GitHub: $e');
      throw FirebaseAuthException(
        code: 'GITHUB_SIGN_IN_FAILED',
        message: e.toString(),
      );
    }
  }

  Future<void> resetPassword(String email) async {
    try {
      FirebaseAuth.instance.setLanguageCode('en');
      await FirebaseAuth.instance.sendPasswordResetEmail(email: email);
      print("Password reset email sent.");
    } on FirebaseAuthException catch (e) {
      print("Error resetting password: ${e.message}");
    } catch (e) {
      print("Unexpected error: $e");
    }
  }

  Future<void> logout() async {
    await _auth.signOut();
    await _googleSignIn.signOut();
  }
}
