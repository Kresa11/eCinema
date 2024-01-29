import 'package:ecinema_mobile/models/reservation.dart';

import '../models/movie.dart';
import '../models/seatxrefReservation.dart';
import 'baseProvider.dart';

class SeatReservationProvider extends BaseProvider<SeatxrefReservation> {
  SeatReservationProvider() : super("SeatReservation");

  @override
  SeatxrefReservation fromJson(data) {
    return SeatxrefReservation.fromJson(data);
  }
}
