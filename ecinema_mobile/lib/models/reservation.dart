import 'dart:ffi';
import 'package:ecinema_mobile/models/projection.dart';
import 'package:ecinema_mobile/models/projection.dart';
import 'package:ecinema_mobile/models/user.dart';
import 'package:json_annotation/json_annotation.dart';

import 'seat.dart';
import 'seatxrefReservation.dart';
part 'reservation.g.dart';

@JsonSerializable()
class Reservation {
  String? id;
  String? userId;
  String? projectionId;
  Projection? projection;
  bool? isActive;
  DateTime? dateTime;
  List<SeatxrefReservation>? seats;

  Reservation();

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Reservation.fromJson(Map<String, dynamic> json) =>
      _$ReservationFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$ReservationToJson(this);
}
