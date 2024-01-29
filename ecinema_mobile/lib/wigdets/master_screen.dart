import 'package:ecinema_mobile/screens/myProfileScreen.dart';
import 'package:ecinema_mobile/screens/notificationListScreen.dart';
import 'package:flutter/material.dart';

import '../screens/movieListScreen.dart';
import '../screens/reservationListScreen.dart';
import 'eCinema_drawer.dart';

class MasterScreenWidget extends StatefulWidget {
  Widget? child;
  MasterScreenWidget({this.child, Key? key}) : super(key: key);

  @override
  State<MasterScreenWidget> createState() => _MasterScreenWidgetState();
}

class _MasterScreenWidgetState extends State<MasterScreenWidget> {
  int _selectedIndex = 0;

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });

    if (_selectedIndex == 0) {
      Navigator.pushNamed(context, NotificationListScreen.routeName);
    } else if (_selectedIndex == 1) {
      Navigator.pushNamed(context, ReservationListScreen.routeName);
    } else if (_selectedIndex == 2) {
      Navigator.pushNamed(context, MyProfileScreen.routeName);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Padding(
          padding: const EdgeInsets.only(left: 20.0),
          child: Text(
            "eCinema",
            style: Theme.of(context).textTheme.headline6,
          ),
        ),
      ),
      drawer: eCinemaDrawer(),
      body: SafeArea(
        child: widget.child!,
      ),
      bottomNavigationBar: _buildBottomBar(),
    );
  }

  BottomNavigationBar _buildBottomBar() {
    return BottomNavigationBar(
      items: const <BottomNavigationBarItem>[
        BottomNavigationBarItem(
          icon: Icon(Icons.home),
          label: 'Home',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.movie),
          label: 'Rezervacije',
        ),
        BottomNavigationBarItem(
          icon: Icon(Icons.person),
          label: 'Moj profil',
        ),
      ],
      selectedItemColor: Colors.red[800],
      currentIndex: _selectedIndex,
      onTap: _onItemTapped,
    );
  }
}
