import 'package:ecinema_mobile/models/payment.dart';
import 'package:ecinema_mobile/models/reservation.dart';

import '../models/movie.dart';
import 'baseProvider.dart';

class PaymentProvider extends BaseProvider<Payment> {
  PaymentProvider() : super("Payment");

  @override
  Payment fromJson(data) {
    return Payment.fromJson(data);
  }
}
