import 'package:ecinema_mobile/main.dart';
import 'package:ecinema_mobile/screens/movieListScreen.dart';
import 'package:ecinema_mobile/screens/myProfileScreen.dart';
import 'package:ecinema_mobile/screens/reservationListScreen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import '../screens/notificationListScreen.dart';

class eCinemaDrawer extends StatelessWidget {
  eCinemaDrawer({Key? key}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Drawer(
        child: ListView(
          padding: EdgeInsets.all(10),
          children: [
            ListTile(
              title: Text('Home'),
              onTap: () {
                Navigator.pushNamed(context, NotificationListScreen.routeName);
              },
            ),
            ListTile(
              title: Text('Filmovi'),
              onTap: () {
                Navigator.pushNamed(context, MovieListScreen.routeName);
              },
            ),
            ListTile(
              title: Text('Rezervacije'),
              onTap: () {
                Navigator.pushNamed(context, ReservationListScreen.routeName);
              },
            ),
            ListTile(
              title: Text('Profil'),
              onTap: () {
                Navigator.pushNamed(context, MyProfileScreen.routeName);
              },
            ),
            ListTile(
              title: Text('Logout'),
              onTap: () {
                Navigator.pushNamedAndRemoveUntil(context, MovieList.routeName,
                    (Route<dynamic> route) => false);
              },
            ),
          ],
        ),
      ),
    );
  }
}
