// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'reservation.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Reservation _$ReservationFromJson(Map<String, dynamic> json) => Reservation()
  ..id = json['id'] as String?
  ..userId = json['userId'] as String?
  ..projectionId = json['projectionId'] as String?
  ..projection = json['projection'] == null
      ? null
      : Projection.fromJson(json['projection'] as Map<String, dynamic>)
  ..isActive = json['isActive'] as bool?
  ..dateTime = json['dateTime'] == null
      ? null
      : DateTime.parse(json['dateTime'] as String)
  ..seats = (json['seats'] as List<dynamic>?)
      ?.map((e) => SeatxrefReservation.fromJson(e as Map<String, dynamic>))
      .toList();

Map<String, dynamic> _$ReservationToJson(Reservation instance) =>
    <String, dynamic>{
      'id': instance.id,
      'userId': instance.userId,
      'projectionId': instance.projectionId,
      'projection': instance.projection,
      'isActive': instance.isActive,
      'dateTime': instance.dateTime?.toIso8601String(),
      'seats': instance.seats,
    };
