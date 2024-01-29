// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'reservationUpsertRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

ReservationUpsertRequest _$ReservationUpsertRequestFromJson(
        Map<String, dynamic> json) =>
    ReservationUpsertRequest()
      ..projectionId = json['projectionId'] as String?
      ..userId = json['userId'] as String?
      ..seats = (json['seats'] as List<dynamic>?)
          ?.map((e) => Seat.fromJson(e as Map<String, dynamic>))
          .toList();

Map<String, dynamic> _$ReservationUpsertRequestToJson(
        ReservationUpsertRequest instance) =>
    <String, dynamic>{
      'projectionId': instance.projectionId,
      'userId': instance.userId,
      'seats': instance.seats,
    };
