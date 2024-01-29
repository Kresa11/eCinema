// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'notification.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Notification _$NotificationFromJson(Map<String, dynamic> json) => Notification()
  ..id = json['id'] as String?
  ..title = json['title'] as String?
  ..description = json['description'] as String?
  ..userId = json['userId'] as String?
  ..date = json['date'] == null ? null : DateTime.parse(json['date'] as String)
  ..user = json['user'] == null
      ? null
      : User.fromJson(json['user'] as Map<String, dynamic>)
  ..picture = json['picture'] as String?
  ..notificationType = json['notificationType'] as String?
  ..isActive = json['isActive'] as bool?;

Map<String, dynamic> _$NotificationToJson(Notification instance) =>
    <String, dynamic>{
      'id': instance.id,
      'title': instance.title,
      'description': instance.description,
      'userId': instance.userId,
      'dateTime': instance.date?.toIso8601String(),
      'user': instance.user,
      'picture': instance.picture,
      'notificationType': instance.notificationType,
      'isActive': instance.isActive,
    };
