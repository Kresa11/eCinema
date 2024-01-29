import 'dart:ffi';

import 'package:ecinema_mobile/models/seat.dart';
import 'package:json_annotation/json_annotation.dart';

part 'addStripeCard.g.dart';

@JsonSerializable()
class AddStripeCard {
  String? cardNumber;
  String? expirationYear;
  String? expirationMonth;
  String? cvc;

  AddStripeCard(
      this.cardNumber, this.expirationYear, this.expirationMonth, this.cvc);

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory AddStripeCard.fromJson(Map<String, dynamic> json) =>
      _$AddStripeCardFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$AddStripeCardToJson(this);
}
