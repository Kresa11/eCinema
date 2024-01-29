// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'hall.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Hall _$HallFromJson(Map<String, dynamic> json) => Hall(
      json['id'] as String,
      json['name'] as String?,
      (json['seat'] as List<dynamic>?)
          ?.map((e) => Seat.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$HallToJson(Hall instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'seat': instance.seat,
    };
