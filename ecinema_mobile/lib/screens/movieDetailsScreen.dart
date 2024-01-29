import 'package:ecinema_mobile/models/projection.dart';
import 'package:ecinema_mobile/providers/projectionProvider.dart';
import 'package:ecinema_mobile/screens/seatSelectionScreen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/rendering.dart';
import 'package:provider/provider.dart';
import '../models/movie.dart';
import '../providers/movieProvider.dart';
import '../utils/util.dart';
import '../wigdets/master_screen.dart';
import '../wigdets/movieCardLine.dart';
import 'loadingScreen.dart';

class MovieDetailsScreen extends StatefulWidget {
  static const String routeName = "/movie_details";
  String id;

  MovieDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<MovieDetailsScreen> createState() => _MovieDetailsScreenState();
}

class _MovieDetailsScreenState extends State<MovieDetailsScreen> {
  MovieProvider? _movieProvider = null;
  ProjectionProvider? _projectionProvider = null;

  Movie? movie = null;
  List<Projection>? movieProjection = null;
  List<String>? movieProjectionDates = null;
  List<Movie>? _recommendList = null;

  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _movieProvider = context.read<MovieProvider>();
    _projectionProvider = context.read<ProjectionProvider>();

    loadData();
    loadRecommendedList(this.widget.id);
  }

  Future loadData() async {
    var movie = await _movieProvider?.getById(this.widget.id);
    setState(() {
      this.movie = movie;
      loadProjections(movie?.name);
    });
  }

  Future loadProjections(String? name) async {
    var searchRequest = {'Name': name, 'StateMachine': 'Active'};
    var movieProjection = await _projectionProvider?.get(searchRequest);
    setState(() {
      this.movieProjection = movieProjection;
      loadProjectionsDates(movieProjection);
    });
  }

  Future loadProjectionsDates(List<Projection>? movieProjection) async {
    List<String>? movieProjectionDates =
        movieProjection?.map((x) => getDate(x.startTime!)).toSet().toList();
    setState(() {
      this.movieProjectionDates = movieProjectionDates;
    });
  }

  Future loadRecommendedList(String id) async {
    var tempRecommendList = await _movieProvider?.recommend(id);
    setState(() {
      _recommendList = tempRecommendList;
    });
  }

  @override
  Widget build(BuildContext context) {
    if (movie == null ||
        movieProjection == null ||
        movieProjectionDates == null ||
        _recommendList == null) {
      loadData();
      return LoadingScreen();
    } else {
      return MasterScreenWidget(
          child: SingleChildScrollView(
        scrollDirection: Axis.vertical,
        child: Column(
          children: [
            Container(
              margin: EdgeInsets.symmetric(vertical: 10),
              height: 210,
              child: Row(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(
                    margin: EdgeInsets.symmetric(horizontal: 10),
                    height: 200,
                    child: imageFromBase64String(movie!.picture!),
                  ),
                  Expanded(
                    child: ListView(
                      children: [
                        Text(movie!.name!,
                            style: Theme.of(context).textTheme.headline6),
                        MovieCardLine(
                          label: 'Trajanje',
                          text: movie!.duration.toString(),
                          padding: 2,
                          white: true,
                        ),
                        MovieCardLine(
                          label: 'Glumci',
                          text: movie!.actors,
                          padding: 2,
                          white: true,
                        ),
                        MovieCardLine(
                          label: 'Režiser',
                          text: movie!.director,
                          padding: 2,
                          white: true,
                        ),
                        MovieCardLine(
                          label: 'Trajanje',
                          text: movie!.genres,
                          padding: 2,
                          white: true,
                        ),
                        MovieCardLine(
                          label: 'Država',
                          text: movie!.country,
                          padding: 2,
                          white: true,
                        ),
                        MovieCardLine(
                            label: 'Opis',
                            text: movie!.description,
                            white: true),
                      ],
                    ),
                  )
                ],
              ),
            ),
            Text("Projekcije ", style: Theme.of(context).textTheme.headline6),
            Container(
              height: 250,
              child: ListView.builder(
                  itemCount: movieProjectionDates?.length,
                  itemBuilder: (BuildContext context, int index) {
                    return _buildProjectionCard(movieProjectionDates![index]);
                  }),
            ),
            Text("Preporučeno ", style: Theme.of(context).textTheme.headline6),
            Container(
              margin: EdgeInsets.only(top: 10),
              height: 200,
              child: GridView(
                gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: 1,
                    childAspectRatio: 1.5 / 1,
                    crossAxisSpacing: 10,
                    mainAxisSpacing: 20),
                scrollDirection: Axis.horizontal,
                children: _buildMovieCardList(),
              ),
            ),
          ],
        ),
      ));
    }
  }

  List<Widget> _buildMovieCardList() {
    if (_recommendList?.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget> list = _recommendList!
        .map((x) => Container(
              child: InkWell(
                onTap: () {
                  Navigator.pushNamed(
                      context, "${MovieDetailsScreen.routeName}/${x.id}");
                },
                child: Container(
                  // height: 100,
                  // width: 100,
                  child: imageFromBase64String(x.picture!),
                ),
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }

  Widget _buildProjectionCard(String date) {
    return Card(
        child: Container(
            height: 100,
            child: Column(
              children: [
                Text(
                  date,
                  style: Theme.of(context).textTheme.bodyText1,
                ),
                Row(
                  children: _createTimeButtonsList(date),
                )
              ],
            )));
  }

  List<Widget> _createTimeButtonsList(String date) {
    List<Projection?>? list =
        movieProjection?.where((x) => getDate(x.startTime) == date).toList();

    if (list == null) {
      Text text = Text("No available projections",
          style: Theme.of(context).textTheme.headline2);
      List<Text> list = List.empty();
      list.add(text);
      return list;
    }

    List<Widget> newList = list
        .map((x) => Container(
              padding: EdgeInsets.all(8.0),
              child: InkWell(
                onTap: () {
                  Navigator.pushNamed(
                      context, "${SeatSelectionScreen.routeName}/${x?.id}");
                },
                child: Text(
                  getTime(x?.startTime),
                  style: Theme.of(context).textTheme.bodyText1,
                ),
              ),
            ))
        .cast<Widget>()
        .toList();

    return newList;
  }
}
