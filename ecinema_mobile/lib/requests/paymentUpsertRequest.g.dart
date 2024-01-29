// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'paymentUpsertRequest.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

PaymentUpsertRequest _$PaymentUpsertRequestFromJson(
        Map<String, dynamic> json) =>
    PaymentUpsertRequest()
      ..stripePaymentId = json['stripePaymentId'] as String?
      ..amount = (json['amount'] as num?)?.toDouble()
      ..reservation = json['reservation'] == null
          ? null
          : ReservationUpsertRequest.fromJson(
              json['reservation'] as Map<String, dynamic>);

Map<String, dynamic> _$PaymentUpsertRequestToJson(
        PaymentUpsertRequest instance) =>
    <String, dynamic>{
      'stripePaymentId': instance.stripePaymentId,
      'amount': instance.amount,
      'reservation': instance.reservation,
    };
