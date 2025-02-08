import 'package:flutter/material.dart';

import 'DishBloC.dart';

class DishBlocProvider extends InheritedWidget {
  final DishBloc dishBloc;

  DishBlocProvider({required Widget child, required this.dishBloc}) : super(child: child);

  @override
  bool updateShouldNotify(InheritedWidget oldWidget) => false;

  static DishBloc of(BuildContext context) {
    final DishBlocProvider? provider = context.dependOnInheritedWidgetOfExactType<DishBlocProvider>();
    assert(provider != null, 'No DishBloc found in context');
    return provider!.dishBloc;
  }
}
