import 'package:ecinema_mobile/models/projection.dart';
import 'package:ecinema_mobile/models/reservation.dart';

import '../models/movie.dart';
import 'baseProvider.dart';

class ProjectionProvider extends BaseProvider<Projection> {
  ProjectionProvider() : super("Projection");

  @override
  Projection fromJson(data) {
    return Projection.fromJson(data);
  }
}
