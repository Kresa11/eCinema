import 'dart:ffi';
import 'package:ecinema_mobile/models/projection.dart';
import 'package:ecinema_mobile/models/projection.dart';
import 'package:ecinema_mobile/models/reservation.dart';
import 'package:ecinema_mobile/models/seat.dart';
import 'package:json_annotation/json_annotation.dart';
part 'seatxrefReservation.g.dart';

@JsonSerializable()
class SeatxrefReservation {
  String id;
  String seatId;
  String reservationId;
  Seat? seat;
  //Reservation reservation;
  bool? isTaken;

  SeatxrefReservation(
      this.id, this.seatId, this.reservationId, this.seat, this.isTaken);

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory SeatxrefReservation.fromJson(Map<String, dynamic> json) =>
      _$SeatxrefReservationFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$SeatxrefReservationToJson(this);
}
