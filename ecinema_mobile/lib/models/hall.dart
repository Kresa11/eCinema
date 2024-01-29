import 'dart:ffi';

import 'package:ecinema_mobile/models/seat.dart';
import 'package:json_annotation/json_annotation.dart';

part 'hall.g.dart';

@JsonSerializable()
class Hall {
  String id;
  String? name;
  List<Seat>? seat;

  Hall(this.id, this.name, this.seat) {}

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Hall.fromJson(Map<String, dynamic> json) => _$HallFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$HallToJson(this);
}
