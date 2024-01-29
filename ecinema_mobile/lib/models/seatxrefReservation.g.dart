// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'seatxrefReservation.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

SeatxrefReservation _$SeatxrefReservationFromJson(Map<String, dynamic> json) =>
    SeatxrefReservation(
      json['id'] as String,
      json['seatId'] as String,
      json['reservationId'] as String,
      json['seat'] == null
          ? null
          : Seat.fromJson(json['seat'] as Map<String, dynamic>),
      json['isTaken'] as bool?,
    );

Map<String, dynamic> _$SeatxrefReservationToJson(
        SeatxrefReservation instance) =>
    <String, dynamic>{
      'id': instance.id,
      'seatId': instance.seatId,
      'reservationId': instance.reservationId,
      'seat': instance.seat,
      'isTaken': instance.isTaken,
    };
