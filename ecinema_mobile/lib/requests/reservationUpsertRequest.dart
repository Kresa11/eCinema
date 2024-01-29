import 'dart:ffi';

import 'package:ecinema_mobile/models/projection.dart';
import 'package:ecinema_mobile/models/reservation.dart';
import 'package:json_annotation/json_annotation.dart';

import '../models/seat.dart';

part 'reservationUpsertRequest.g.dart';

@JsonSerializable()
class ReservationUpsertRequest {
  String? projectionId;
  String? userId;
  List<Seat>? seats;

  ReservationUpsertRequest();

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory ReservationUpsertRequest.fromJson(Map<String, dynamic> json) =>
      _$ReservationUpsertRequestFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$ReservationUpsertRequestToJson(this);
}
