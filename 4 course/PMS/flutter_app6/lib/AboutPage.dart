import 'package:flutter/material.dart';
import 'package:flutter/services.dart'; // Добавить для MethodChannel

class AboutPage extends StatefulWidget {
  @override
  _AboutPageState createState() => _AboutPageState();
}

class _AboutPageState extends State<AboutPage> {
  String? _timeZone = "Loading...";  // Изначально показываем "Loading..."
  String? _batteryLevel = "Loading...";
  static const platform = MethodChannel('com.example.flutter_app6/timezone');  // Определяем канал
  static const platformBattery = MethodChannel('com.example.flutter_app6/battery');

  @override
  void initState() {
    super.initState();
    _getTimeZone();  // Вызываем метод для получения часового пояса
    _getBatteryLevel();
  }

  // Метод для получения часового пояса с помощью платформенного канала
  Future<void> _getTimeZone() async {
    String timeZone;
    try {
      timeZone = await platform.invokeMethod('getTimeZone');
    } on PlatformException catch (e) {
      timeZone = "Failed to get time zone: '${e.message}'.";
    }

    // Обновляем состояние с новым значением часового пояса
    setState(() {
      _timeZone = timeZone;
    });
  }

  Future<void> _getBatteryLevel() async {
    String batteryLevel;
    try {
      final int result = await platformBattery.invokeMethod('getBatteryLevel');
      batteryLevel = '$result%';
    } on PlatformException catch (e) {
      batteryLevel = "Failed to get battery level: '${e.message}'";
    }

    setState(() {
      _batteryLevel = batteryLevel;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("About Us"),
        leading: IconButton(
          icon: Icon(Icons.arrow_back),
          onPressed: () {
            Navigator.pop(context);
          },
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              "About This App",
              style: TextStyle(
                fontSize: 24,
                fontWeight: FontWeight.bold,
              ),
            ),
            SizedBox(height: 16),
            Text(
              "This is a demo food app that allows users to browse various dishes and explore details about them. "
                  "It is built using Flutter, and features such as page navigation, filtering options, and detail pages for dishes are available.",
              style: TextStyle(fontSize: 16),
            ),
            SizedBox(height: 20),
            Text(
              "Developer",
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
            SizedBox(height: 8),
            Text(
              "Sanoj Dilshan 👋",
              style: TextStyle(fontSize: 16),
            ),
            SizedBox(height: 20),
            Text(
              "Current Time Zone:",
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
            SizedBox(height: 8),
            Text(
              _timeZone ?? "Loading...",  // Отображаем часовой пояс или "Loading..."
              style: TextStyle(fontSize: 16),
            ),
            SizedBox(height: 20),
            Text(
              "Battery Level:",
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
            SizedBox(height: 8),
            Text(
              _batteryLevel ?? "Loading...",  // Отображаем уровень заряда батареи или "Loading..."
              style: TextStyle(fontSize: 16),
            ),
          ],
        ),
      ),
    );
  }
}
