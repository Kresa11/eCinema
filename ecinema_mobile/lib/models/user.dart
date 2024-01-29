import 'dart:ffi';

import 'package:ecinema_mobile/models/reservation.dart';
import 'package:json_annotation/json_annotation.dart';

part 'user.g.dart';

@JsonSerializable()
class User {
  String id;
  String? firstName;
  String? lastName;
  String? email;
  String? phoneNumber;
  String? username;
  bool? isActive;

  //List<Reservation>? reservations;

  User(this.id, this.firstName, this.lastName, this.email, this.phoneNumber,
      this.username, this.isActive) {}

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$UserToJson(this);
}
