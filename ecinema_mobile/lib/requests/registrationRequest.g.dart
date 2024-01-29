// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'registrationRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RegistrationRequest _$RegistrationRequestFromJson(Map<String, dynamic> json) =>
    RegistrationRequest()
      ..firstName = json['firstName'] as String?
      ..lastName = json['lastName'] as String?
      ..email = json['email'] as String?
      ..phoneNumber = json['phoneNumber'] as String?
      ..username = json['username'] as String?
      ..password = json['password'] as String?
      ..confirmPassword = json['confirmPassword'] as String?;

Map<String, dynamic> _$RegistrationRequestToJson(
        RegistrationRequest instance) =>
    <String, dynamic>{
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'email': instance.email,
      'phoneNumber': instance.phoneNumber,
      'username': instance.username,
      'password': instance.password,
      'confirmPassword': instance.confirmPassword,
    };
