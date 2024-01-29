import 'dart:ffi';

import 'package:ecinema_mobile/models/user.dart';
import 'package:json_annotation/json_annotation.dart';

part 'notification.g.dart';

@JsonSerializable()
class Notification {
  String? id;
  String? title;
  String? description;
  String? userId;
  DateTime? date;
  User? user;
  String? picture;
  String? notificationType;
  bool? isActive;

  Notification();

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Notification.fromJson(Map<String, dynamic> json) =>
      _$NotificationFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$NotificationToJson(this);
}
