import 'package:flutter/services.dart';

class UrlLauncherService {
  static const MethodChannel _platform = MethodChannel('com.example.flutter_app6/url_launcher');

  // Метод для передачи URL на Android
  static Future<void> openBrowser(String url) async {
    try {
      await _platform.invokeMethod('openBrowser', {"url": url});
    } on PlatformException catch (e) {
      print("Failed to open browser: '${e.message}'.");
    }
  }
}
