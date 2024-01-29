// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'projection.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Projection _$ProjectionFromJson(Map<String, dynamic> json) => Projection()
  ..id = json['id'] as String?
  ..startTime = json['startTime'] == null
      ? null
      : DateTime.parse(json['startTime'] as String)
  ..endTime =
      json['endTime'] == null ? null : DateTime.parse(json['endTime'] as String)
  ..hallId = json['hallId'] as String?
  ..hall = json['hall'] == null
      ? null
      : Hall.fromJson(json['hall'] as Map<String, dynamic>)
  ..movieId = json['movieId'] as String?
  ..movie = json['movie'] == null
      ? null
      : Movie.fromJson(json['movie'] as Map<String, dynamic>)
  ..priceId = json['priceId'] as String?
  ..price = json['price'] == null
      ? null
      : Price.fromJson(json['price'] as Map<String, dynamic>)
  ..projectionType = json['projectionType'] as String?
  ..status = json['status'] as String?
  ..isActive = json['isActive'] as bool?;

Map<String, dynamic> _$ProjectionToJson(Projection instance) =>
    <String, dynamic>{
      'id': instance.id,
      'startTime': instance.startTime?.toIso8601String(),
      'endTime': instance.endTime?.toIso8601String(),
      'hallId': instance.hallId,
      'hall': instance.hall,
      'movieId': instance.movieId,
      'movie': instance.movie,
      'priceId': instance.priceId,
      'price': instance.price,
      'projectionType': instance.projectionType,
      'status': instance.status,
      'isActive': instance.isActive,
    };
