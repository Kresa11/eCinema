// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'seat.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Seat _$SeatFromJson(Map<String, dynamic> json) => Seat(
      json['id'] as String,
      json['name'] as String?,
      json['hallId'] as String,
    );

Map<String, dynamic> _$SeatToJson(Seat instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'hallId': instance.hallId,
    };
