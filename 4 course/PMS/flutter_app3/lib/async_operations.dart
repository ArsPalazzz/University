import 'dart:async';

import 'main.dart';

Future<void> simulateLoadingPlayerData(Player player) async {
  print('Загрузка данных игрока ${player.name}...');
  await Future.delayed(Duration(seconds: 2));
  print('Данные игрока ${player.name} загружены.');
}

Stream<int> countdown(int from) async* {
  for (int i = from; i >= 0; i--) {
    await Future.delayed(Duration(seconds: 1));
    yield i;
  }
}

Stream<int> createBroadcastStream(int maxCount) {
  StreamController<int> controller = StreamController<int>.broadcast();

  Timer.periodic(Duration(seconds: 1), (timer) {
    if (maxCount < 0) {
      controller.close();
      timer.cancel();
    } else {
      controller.add(maxCount--);
    }
  });

  return controller.stream;
}