import 'main.dart';

class PlayerIterator implements Iterator<Player> {
  final List<Player> _players;
  int _index = -1;

  PlayerIterator(this._players);

  @override
  bool moveNext() {
    _index++;
    return _index < _players.length;
  }

  @override
  Player get current => _players[_index];
}

class PlayerCollection extends Iterable<Player> {
  final List<Player> players;

  PlayerCollection(this.players);

  @override
  Iterator<Player> get iterator => PlayerIterator(players);
}