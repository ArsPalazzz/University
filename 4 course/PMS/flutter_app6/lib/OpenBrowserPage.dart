import 'package:flutter/material.dart';
import 'UrlLauncherService.dart';

class OpenBrowserPage extends StatelessWidget {
  final String url = "https://www.youtube.com";  // URL для передачи

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Open Browser"),
      ),
      body: Center(
        child: ElevatedButton(
          onPressed: () {
            UrlLauncherService.openBrowser(url);
          },
          child: Text("Open Browser"),
        ),
      ),
    );
  }
}
