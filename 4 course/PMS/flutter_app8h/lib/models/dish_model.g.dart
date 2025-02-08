// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'dish_model.dart';

// **************************************************************************
// TypeAdapterGenerator
// **************************************************************************

class DishModelAdapter extends TypeAdapter<DishModel> {
  @override
  final int typeId = 1;

  @override
  DishModel read(BinaryReader reader) {
    final numOfFields = reader.readByte();
    final fields = <int, dynamic>{
      for (int i = 0; i < numOfFields; i++) reader.readByte(): reader.read(),
    };
    return DishModel(
      id: fields[0] as String,
      name: fields[1] as String,
      description: fields[2] as String,
      price: fields[3] as double,
      weight: fields[4] as int,
      image: fields[5] as String,
      updated: fields[6] as String,
      rate: fields[7] as String,
      timeStamp: fields[8] as String,
      isSpicy: fields[9] as bool,
      isPopular: fields[10] as bool,
    );
  }

  @override
  void write(BinaryWriter writer, DishModel obj) {
    writer
      ..writeByte(11)
      ..writeByte(0)
      ..write(obj.id)
      ..writeByte(1)
      ..write(obj.name)
      ..writeByte(2)
      ..write(obj.description)
      ..writeByte(3)
      ..write(obj.price)
      ..writeByte(4)
      ..write(obj.weight)
      ..writeByte(5)
      ..write(obj.image)
      ..writeByte(6)
      ..write(obj.updated)
      ..writeByte(7)
      ..write(obj.rate)
      ..writeByte(8)
      ..write(obj.timeStamp)
      ..writeByte(9)
      ..write(obj.isSpicy)
      ..writeByte(10)
      ..write(obj.isPopular);
  }

  @override
  int get hashCode => typeId.hashCode;

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is DishModelAdapter &&
          runtimeType == other.runtimeType &&
          typeId == other.typeId;
}
