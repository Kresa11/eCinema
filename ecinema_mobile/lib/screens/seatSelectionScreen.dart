import 'package:ecinema_mobile/models/projection.dart';
import 'package:ecinema_mobile/models/seat.dart';
import 'package:ecinema_mobile/providers/projectionProvider.dart';
import 'package:ecinema_mobile/requests/reservationUpsertRequest.dart';
import 'package:ecinema_mobile/screens/reservationDetailsScreen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../models/seatxrefReservation.dart';
import '../providers/hallProvider.dart';
import '../providers/seatReservationProvider.dart';
import '../utils/util.dart';
import '../wigdets/master_screen.dart';
import 'loadingScreen.dart';

class SeatSelectionScreen extends StatefulWidget {
  static const String routeName = "/seat_selection";
  String id;

  SeatSelectionScreen(this.id, {Key? key}) : super(key: key);
  @override
  State<SeatSelectionScreen> createState() => _SeatSelectionScreenState();
}

class _SeatSelectionScreenState extends State<SeatSelectionScreen> {
  List<SeatxrefReservation>? _reservedSeats = null;
  List<Seat>? _allSeats = null;
  Projection? _projection = null;

  late SeatReservationProvider? _seatReservationProvider;
  HallProvider? _hallProvider = null;
  ProjectionProvider? _projectionProvider = null;

  late List<MaterialColor>? _colors;
  List<int>? _selectedIndexes = [];
  List<Seat>? _selectedSeats = [];

  MaterialColor? _buttonColor;

  ReservationUpsertRequest? insert = ReservationUpsertRequest();

  bool _isButtonEnabled = true;

  void _changeButtonColor(int index) {
    bool _isTaken = _reservedSeats!
        .any((element) => element.seatId == _allSeats![index].id);
    if (_isTaken) {
      _buttonColor = Colors.red;
    } else if (_selectedIndexes?.any((element) => element == index) == true &&
        !_isTaken) {
      _buttonColor = Colors.amber;
    } else {
      _buttonColor = Colors.grey;
    }

    _colors?[index] = _buttonColor!;
  }

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
    _seatReservationProvider = context.watch<SeatReservationProvider>();
  }

  @override
  void initState() {
    super.initState();
    _hallProvider = context.read<HallProvider>();
    _projectionProvider = context.read<ProjectionProvider>();
    loadData();
  }

  Future loadData() async {
    var projection = await _projectionProvider?.getById(this.widget.id);

    if (projection != null) {
      setState(() {
        _projection = projection;
        loadAllSeats(_projection!.hallId!);
        load_ReservedSeats(_projection!.id!);
      });
    }
  }

  Future loadAllSeats(String hallId) async {
    var hall = await _hallProvider?.getById(hallId);
    if (hall != null) {
      setState(() {
        _allSeats = hall.seat;
        _colors = List.generate(_allSeats?.length ?? 0, (_) => Colors.grey);
      });
    }
  }

  Future load_ReservedSeats(String projectionId) async {
    var searchRequest = {'ProjectionId': projectionId};
    var tmp_ReservedSeats = await _seatReservationProvider?.get(searchRequest);
    if (tmp_ReservedSeats != null) {
      setState(() {
        _reservedSeats = tmp_ReservedSeats;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    final screenWidth = MediaQuery.of(context).size.width;
    if (_reservedSeats == null || _allSeats == null) {
      loadData();
      return LoadingScreen();
    } else {
      return MasterScreenWidget(
          child: Column(
        children: [
          Stack(children: [
            Container(
              height: 200,
              width: screenWidth * 0.7,
              child: imageFromBase64String(_projection!.movie!.picture!),
            ),
            Positioned(
              left: 10,
              bottom: 10,
              child: Text(
                _projection?.movie?.name ?? "",
                style: Theme.of(context).textTheme.headline3,
              ),
            )
          ]),
          Expanded(
            child: Container(
              margin: EdgeInsets.symmetric(vertical: 20, horizontal: 10),
              color: Colors.white,
              height: 500,
              child: Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Container(
                        padding: const EdgeInsets.all(8.0),
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                          children: [
                            Text(
                              "*za odabir sjedišta duže držite ikonicu*",
                              style:
                                  TextStyle(color: Colors.black, fontSize: 11),
                            ),
                            Text(
                              "${getDate(_projection?.startTime)} ${getTime(_projection?.startTime)}",
                              style:
                                  TextStyle(color: Colors.black, fontSize: 16),
                            ),
                          ],
                        ),
                      ),
                      Container(
                          margin: EdgeInsets.fromLTRB(0, 10, 10, 0),
                          padding: EdgeInsets.all(5),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Row(
                                children: [
                                  Icon(Icons.square, color: Colors.grey),
                                  Text(
                                    " - slobodno",
                                    style: TextStyle(color: Colors.black),
                                  )
                                ],
                              ),
                              Row(
                                children: [
                                  Icon(Icons.square, color: Colors.amber),
                                  Text(" - odabrano",
                                      style: TextStyle(color: Colors.black))
                                ],
                              ),
                              Row(
                                children: [
                                  Icon(Icons.square, color: Colors.red),
                                  Text(" - zauzeto",
                                      style: TextStyle(color: Colors.black))
                                ],
                              )
                            ],
                          )),
                    ],
                  ),
                  Center(
                    child: Container(
                      margin: EdgeInsets.only(bottom: 10),
                      child: Text(
                        "Odaberi sjedišta:",
                        style: TextStyle(
                            color: Colors.black,
                            fontSize: 14,
                            fontWeight: FontWeight.bold),
                      ),
                    ),
                  ),
                  Expanded(
                    child: GridView.count(
                        crossAxisCount: 5,
                        children:
                            List.generate(_allSeats?.length ?? 0, (index) {
                          _changeButtonColor(index);
                          return InkWell(
                            onLongPress: _isButtonEnabled
                                ? () {
                                    if (_colors?[index] != Colors.red) {
                                      setState(() {
                                        if (_selectedIndexes!.any(
                                            (element) => element == index)) {
                                          _selectedIndexes?.remove(index);
                                          _selectedSeats
                                              ?.remove(_allSeats![index]);
                                        } else {
                                          _selectedIndexes?.add(index);
                                          _selectedSeats
                                              ?.add(_allSeats![index]);
                                        }
                                      });
                                    }
                                  }
                                : null,
                            child: Icon(Icons.square, color: _colors![index]),
                          );
                        })),
                  ),
                  availableSeatsLeft(context)
                ],
              ),
            ),
          ),
        ],
      ));
    }
  }

  Widget availableSeatsLeft(BuildContext context) {
    var freeSeats = _colors!.any((x) => x == Colors.grey || x == Colors.amber);
    if (!freeSeats) {
      setState(() {
        _isButtonEnabled = freeSeats;
      });
    }
    if (freeSeats) {
      return TextButton(
        onPressed: () {
          if (_selectedSeats!.isNotEmpty) {
            insert?.projectionId = widget.id;
            insert?.seats = _selectedSeats;

            Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) =>
                    ReservationDetailsScreen(reservationInsertRequest: insert!),
              ),
            );
          }
        },
        child: Text(
          "Potvrdi rezervaciju",
          style: TextStyle(fontSize: 18),
        ),
      );
    }
    return Center(
        child: Text(
      "Nažalost nema slobodnih mjesta!",
      style: Theme.of(context).textTheme.headline2,
    ));
  }
}
