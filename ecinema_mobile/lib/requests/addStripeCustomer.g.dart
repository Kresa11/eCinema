// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'addStripeCustomer.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AddStripeCustomer _$AddStripeCustomerFromJson(Map<String, dynamic> json) =>
    AddStripeCustomer(
      json['email'] as String,
      json['name'] as String,
      AddStripeCard.fromJson(json['creditCard'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$AddStripeCustomerToJson(AddStripeCustomer instance) =>
    <String, dynamic>{
      'email': instance.email,
      'name': instance.name,
      'creditCard': instance.creditCard,
    };
