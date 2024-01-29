import 'package:ecinema_mobile/requests/reservationUpsertRequest.dart';
import 'package:json_annotation/json_annotation.dart';

part 'paymentUpsertRequest.g.dart';

@JsonSerializable()
class PaymentUpsertRequest {
  String? stripePaymentId;
  double? amount;
  ReservationUpsertRequest? reservation;

  PaymentUpsertRequest();

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory PaymentUpsertRequest.fromJson(Map<String, dynamic> json) =>
      _$PaymentUpsertRequestFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$PaymentUpsertRequestToJson(this);
}
