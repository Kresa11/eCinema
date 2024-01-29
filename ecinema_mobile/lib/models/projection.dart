import 'dart:core';
import 'dart:ffi';
import 'package:ecinema_mobile/models/hall.dart';
import 'package:ecinema_mobile/models/movie.dart';
import 'package:ecinema_mobile/models/price.dart';
import 'package:json_annotation/json_annotation.dart';
part 'projection.g.dart';

@JsonSerializable()
class Projection {
  String? id;
  DateTime? startTime;
  DateTime? endTime;
  String? hallId;
  Hall? hall;
  String? movieId;
  Movie? movie;
  String? priceId;
  Price? price;
  String? projectionType;
  String? status;
  bool? isActive;
  Projection();
  // this.id,
  // this.startTime,
  // this.endTime,
  // this.hallId,
  // this.hall,
  // this.movieId,
  // this.movie,
  // this.priceId,
  // this.price,
  // this.projectionType,
  // this.status,
  // this.isActive) {}
  // A necessary factory constructor for creating a new User instance
  // from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  // The constructor is named after the source class, in this case, User.
  factory Projection.fromJson(Map<String, dynamic> json) =>
      _$ProjectionFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$ProjectionToJson(this);
}
