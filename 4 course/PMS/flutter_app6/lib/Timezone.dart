import 'package:flutter/services.dart';

class TimeZoneService {
  static const MethodChannel _platform = MethodChannel('com.example.flutter_app6/timezone');

  // Метод для получения часового пояса через платформенный канал
  static Future<String> getTimeZone() async {
    String timeZone;
    try {
      timeZone = await _platform.invokeMethod('getTimeZone');
    } on PlatformException catch (e) {
      timeZone = "Failed to get time zone: '${e.message}'.";
    }
    return timeZone;
  }
}
