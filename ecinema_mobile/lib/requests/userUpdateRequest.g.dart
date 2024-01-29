// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'userUpdateRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserUpdateRequest _$UserUpdateRequestFromJson(Map<String, dynamic> json) =>
    UserUpdateRequest()
      ..firstName = json['firstName'] as String?
      ..lastName = json['lastName'] as String?
      ..email = json['email'] as String?
      ..phoneNumber = json['phoneNumber'] as String?
      ..username = json['username'] as String?;

Map<String, dynamic> _$UserUpdateRequestToJson(UserUpdateRequest instance) =>
    <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'email': instance.email,
      'phoneNumber': instance.phoneNumber,
      'username': instance.username,
    };
