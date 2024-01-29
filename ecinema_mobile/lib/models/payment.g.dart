// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'payment.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Payment _$PaymentFromJson(Map<String, dynamic> json) => Payment()
  ..id = json['id'] as String?
  ..stripePaymentId = json['stripePaymentId'] as String?
  ..created =
      json['created'] == null ? null : DateTime.parse(json['created'] as String)
  ..amount = (json['amount'] as num?)?.toDouble()
  ..reservationId = json['reservationId'] as String?
  ..reservation = json['reservation'] == null
      ? null
      : Reservation.fromJson(json['reservation'] as Map<String, dynamic>);

Map<String, dynamic> _$PaymentToJson(Payment instance) => <String, dynamic>{
      'id': instance.id,
      'stripePaymentId': instance.stripePaymentId,
      'created': instance.created?.toIso8601String(),
      'amount': instance.amount,
      'reservationId': instance.reservationId,
      'reservation': instance.reservation,
    };
