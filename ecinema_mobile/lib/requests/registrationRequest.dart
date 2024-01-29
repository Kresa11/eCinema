import 'dart:ffi';

import 'package:ecinema_mobile/models/reservation.dart';
import 'package:json_annotation/json_annotation.dart';

part 'registrationRequest.g.dart';

@JsonSerializable()
class RegistrationRequest {
  String? firstName;
  String? lastName;
  String? email;
  String? phoneNumber;
  String? username;
  String? password;
  String? confirmPassword;

  RegistrationRequest() {}

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory RegistrationRequest.fromJson(Map<String, dynamic> json) =>
      _$RegistrationRequestFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$RegistrationRequestToJson(this);
}
