import 'dart:ffi';

import 'package:ecinema_mobile/models/seat.dart';
import 'package:json_annotation/json_annotation.dart';

import 'addStripeCard.dart';

part 'addStripeCustomer.g.dart';

@JsonSerializable()
class AddStripeCustomer {
  String email;
  String name;
  AddStripeCard creditCard;

  AddStripeCustomer(this.email, this.name, this.creditCard);

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory AddStripeCustomer.fromJson(Map<String, dynamic> json) =>
      _$AddStripeCustomerFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$AddStripeCustomerToJson(this);
}
