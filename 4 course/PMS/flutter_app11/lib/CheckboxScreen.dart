import 'package:flutter/material.dart';

class CheckboxScreen extends StatefulWidget {
  @override
  _CheckboxScreenState createState() => _CheckboxScreenState();
}

class _CheckboxScreenState extends State<CheckboxScreen> {
  bool _acceptTerms = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Checkbox Screen'),
      ),
      body: Center(
        child: Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Checkbox(
              key: Key('acceptTermsCheckbox'),
              value: _acceptTerms,
              onChanged: (bool? newValue) {
                setState(() {
                  _acceptTerms = newValue ?? false;
                });
              },
            ),
            Text('Accept Terms'),
          ],
        ),
      ),
    );
  }
}
