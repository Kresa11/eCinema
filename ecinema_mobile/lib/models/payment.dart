import 'dart:ffi';

import 'package:ecinema_mobile/models/reservation.dart';
import 'package:json_annotation/json_annotation.dart';

part 'payment.g.dart';

@JsonSerializable()
class Payment {
  String? id;
  String? stripePaymentId;
  DateTime? created;
  double? amount;
  String? reservationId;
  Reservation? reservation;

  // Payment(this.id, this.stripePaymentId, this.created, this.amount,
  //     this.reservationId, this.reservation) {}
  Payment() {}

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Payment.fromJson(Map<String, dynamic> json) =>
      _$PaymentFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$PaymentToJson(this);
}
