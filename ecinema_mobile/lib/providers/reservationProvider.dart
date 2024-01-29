import 'package:ecinema_mobile/models/reservation.dart';

import '../models/movie.dart';
import 'baseProvider.dart';

class ReservationProvider extends BaseProvider<Reservation> {
  ReservationProvider() : super("Reservation");

  @override
  Reservation fromJson(data) {
    return Reservation.fromJson(data);
  }
}
