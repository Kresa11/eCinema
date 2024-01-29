import 'dart:convert';
import 'dart:io';

import 'package:ecinema_mobile/wigdets/headerWidget.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/movie.dart';
import '../providers/movieProvider.dart';
import '../utils/util.dart';
import '../wigdets/master_screen.dart';
import '../wigdets/movieCardLine.dart';
import 'movieDetailsScreen.dart';

class MovieListScreen extends StatefulWidget {
  static const String routeName = "/movie";

  const MovieListScreen({Key? key}) : super(key: key);

  @override
  State<MovieListScreen> createState() => _MovieListScreenState();
}

class _MovieListScreenState extends State<MovieListScreen> {
  MovieProvider? _movieProvider = null;
  List<Movie>? data = [];
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _movieProvider = context.read<MovieProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData =
        await _movieProvider?.get({'IsActive': true, 'HasProjection': true});
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        child: Column(
      children: [
        HeaderWidget(title: "Filmovi"),
        Container(
          margin: EdgeInsets.all(8),
          height: 50,
          child: TextField(
              controller: _searchController,
              decoration: const InputDecoration(
                  labelText: "Naziv",
                  hintStyle:
                      TextStyle(fontSize: 20.0, fontWeight: FontWeight.bold)),
              onSubmitted: (value) async {
                var tmpData = await _movieProvider?.get({'Name': value});
                setState(() {
                  data = tmpData!;
                });
              }),
        ),
        Expanded(
          child: ListView.builder(
            itemCount: data?.length,
            itemBuilder: (BuildContext context, int index) {
              return _buildMovieCard(data![index]);
            },
          ),
        ),
      ],
    ));
  }

  Widget _buildMovieCard(Movie x) {
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: Card(
        child: InkWell(
          onTap: () {
            Navigator.pushNamed(
                context, "${MovieDetailsScreen.routeName}/${x.id}");
          },
          child: Row(
            children: [
              Container(
                height: 150,
                width: 150,
                child: imageFromBase64String(x.picture!),
                margin: EdgeInsets.only(right: 10.0),
              ),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text("${x.name}",
                      style: Theme.of(context).textTheme.headline5),
                  SizedBox(
                    height: 20,
                  ),
                  MovieCardLine(
                      label: "Trajanje:", text: x.duration.toString()),
                  MovieCardLine(label: "Glumci:", text: x.actors),
                  MovieCardLine(label: "Režiser:", text: x.director),
                  MovieCardLine(label: "Žanrovi:", text: x.genres),
                  MovieCardLine(label: "Država:", text: x.country),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
