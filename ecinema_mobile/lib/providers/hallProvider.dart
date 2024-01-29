import 'package:ecinema_mobile/models/reservation.dart';

import '../models/hall.dart';
import '../models/movie.dart';
import '../models/seat.dart';
import '../models/seatxrefReservation.dart';
import 'baseProvider.dart';

class HallProvider extends BaseProvider<Hall> {
  HallProvider() : super("Hall");

  @override
  Hall fromJson(data) {
    return Hall.fromJson(data);
  }
}
