import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

import 'hall.dart';

part 'seat.g.dart';

@JsonSerializable()
class Seat {
  String id;
  String? name;
  String hallId;
  // Hall hall;

  Seat(this.id, this.name, this.hallId) {}

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Seat.fromJson(Map<String, dynamic> json) => _$SeatFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$SeatToJson(this);
}
