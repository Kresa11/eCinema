import 'package:ecinema_mobile/models/reservation.dart';
import 'package:ecinema_mobile/providers/reservationProvider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../utils/util.dart';
import '../wigdets/headerWidget.dart';
import '../wigdets/master_screen.dart';
import '../wigdets/movieCardLine.dart';
import 'loadingScreen.dart';
import 'reservationDetailsScreen.dart';

class ReservationListScreen extends StatefulWidget {
  static const String routeName = "/reservation";
  const ReservationListScreen({Key? key}) : super(key: key);
  @override
  State<ReservationListScreen> createState() => _ReservationListScreenState();
}

class _ReservationListScreenState extends State<ReservationListScreen> {
  ReservationProvider? _reservationProvider = null;

  List<Reservation>? data = null;
  TextEditingController _searchController = TextEditingController();
  @override
  void initState() {
    super.initState();
    _reservationProvider = context.read<ReservationProvider>();
    loadData();
  }

  Future loadData() async {
    if (Authorization.id != null) {
      //var searchRequest = {'User': Authorization.username};
      var tmpData = await _reservationProvider!.get({
        'IncludeUsers': true,
        'IncludeProjection': true,
        'IncludeMovies': true,
        'UserId': Authorization.id
      });
      //var tmpData = await _reservationProvider?.get(searchRequest);
      setState(() {
        data = tmpData;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    if (data == null) {
      return LoadingScreen();
    }
    return MasterScreenWidget(
      child: Column(
        children: [
          HeaderWidget(title: "Rezervacije"),
          if (data!.isEmpty)
            Text("Trenutno nema dostupnih rezervacija.",
                style: Theme.of(context).textTheme.headline6),
          Expanded(
            child: ListView.builder(
              itemCount: data?.length,
              itemBuilder: (BuildContext context, int index) {
                return _buildResevationCard(data![index]);
              },
            ),
          )
        ],
      ),
    );
  }

  Widget _buildResevationCard(Reservation x) {
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: InkWell(
        onTap: () {
          Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => ReservationDetailsScreen(id: x.id!),
            ),
          );
          // Navigator.pushNamed(
          //     context, "${ReservationDetailsScreen.routeName}/${x.id}");
        },
        child: Card(
          child: Row(
            children: [
              Container(
                height: 150,
                width: 150,
                child: imageFromBase64String(x.projection!.movie!.picture!),
              ),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text("${x.projection?.movie?.name}",
                      style: Theme.of(context).textTheme.headline5),
                  SizedBox(
                    height: 10,
                  ),
                  MovieCardLine(
                      label: "Režiser :",
                      text: "${x.projection?.movie?.director ?? "Movie name"}",
                      font: 14),
                  MovieCardLine(
                      label: "Žanrovi :",
                      text: "${x.projection?.movie?.genres ?? "Movie genres"}",
                      font: 14),
                  MovieCardLine(
                      label: "Datum projekcije :",
                      text:
                          "${getDate(x.projection?.startTime) ?? "Projection date"}",
                      font: 14),
                  MovieCardLine(
                      label: "Vrijeme projekcije :",
                      text:
                          "${getTime(x.projection?.startTime) ?? "Projection start time"}",
                      font: 14),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
