// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'addStripeCard.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AddStripeCard _$AddStripeCardFromJson(Map<String, dynamic> json) =>
    AddStripeCard(
      json['cardNumber'] as String?,
      json['expirationYear'] as String?,
      json['expirationMonth'] as String?,
      json['cvc'] as String?,
    );

Map<String, dynamic> _$AddStripeCardToJson(AddStripeCard instance) =>
    <String, dynamic>{
      'cardNumber': instance.cardNumber,
      'expirationYear': instance.expirationYear,
      'expirationMonth': instance.expirationMonth,
      'cvc': instance.cvc,
    };
