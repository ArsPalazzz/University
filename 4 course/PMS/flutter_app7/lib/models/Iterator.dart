import 'Entities.dart';

class GameEntityIterator implements Iterator<GameEntity> {
  final List<GameEntity> _entities;
  int _currentIndex = -1;

  GameEntityIterator(this._entities);

  @override
  GameEntity get current => _entities[_currentIndex];

  @override
  bool moveNext() {
    _currentIndex++;
    return _currentIndex < _entities.length;
  }
}

class GameEntityCollection extends Iterable<GameEntity> {
  final List<GameEntity> _entities;

  GameEntityCollection(this._entities);

  @override
  Iterator<GameEntity> get iterator => GameEntityIterator(_entities);
}
