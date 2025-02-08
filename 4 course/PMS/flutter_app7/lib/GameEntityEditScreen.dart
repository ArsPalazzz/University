import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import 'models/Entities.dart';

class GameEntityEditScreen extends StatefulWidget {
  final GameEntity? gameEntity; // Если null — это новый элемент, если не null — это редактирование

  GameEntityEditScreen({this.gameEntity});

  @override
  _GameEntityEditScreenState createState() => _GameEntityEditScreenState();
}

class _GameEntityEditScreenState extends State<GameEntityEditScreen> {
  final _formKey = GlobalKey<FormState>();
  late TextEditingController _nameController;
  late TextEditingController _descriptionController;

  @override
  void initState() {
    super.initState();
    _nameController = TextEditingController(text: widget.gameEntity?.name ?? '');
    _descriptionController = TextEditingController(text: widget.gameEntity?.description ?? '');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.gameEntity == null ? 'Add Game Entity' : 'Edit Game Entity'),
      ),
      body: Form(
        key: _formKey,
        child: Column(
          children: [
            TextFormField(
              controller: _nameController,
              decoration: InputDecoration(labelText: 'Name'),
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return 'Please enter a name';
                }
                return null;
              },
            ),
            TextFormField(
              controller: _descriptionController,
              decoration: InputDecoration(labelText: 'Description'),
            ),
            ElevatedButton(
              onPressed: () {
                if (_formKey.currentState!.validate()) {
                  // Логика для сохранения нового элемента или обновления существующего
                  final newGameEntity = GameEntity(
                    id: widget.gameEntity?.id,
                    name: _nameController.text,
                    description: _descriptionController.text,
                    type: widget.gameEntity?.type ?? 'defaultType', // or another suitable default
                  );


                  if (widget.gameEntity == null) {
                    // Логика добавления нового элемента
                    // Например, DatabaseHelper.instance.create(newGameEntity);
                  } else {
                    // Логика обновления существующего элемента
                    // Например, DatabaseHelper.instance.update(newGameEntity);
                  }

                  Navigator.pop(context);
                }
              },
              child: Text(widget.gameEntity == null ? 'Add' : 'Save'),
            ),
          ],
        ),
      ),
    );
  }
}
