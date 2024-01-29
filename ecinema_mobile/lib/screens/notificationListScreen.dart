import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/notification.dart' as notf;
import '../providers/notificationProvider.dart';
import '../utils/util.dart';
import '../wigdets/master_screen.dart';
import '../wigdets/movieCardLine.dart';
import '../wigdets/headerWidget.dart';
import 'movieListScreen.dart';

class NotificationListScreen extends StatefulWidget {
  static const String routeName = "/notification";

  const NotificationListScreen({Key? key}) : super(key: key);

  @override
  State<NotificationListScreen> createState() => _NotificationListScreenState();
}

class _NotificationListScreenState extends State<NotificationListScreen> {
  NotificationProvider? _notificationProvider = null;
  List<notf.Notification> data = [];
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _notificationProvider = context.read<NotificationProvider>();
    loadData();
  }

  Future loadData() async {
    List<notf.Notification>? tmpData = await _notificationProvider?.get(null);
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          HeaderWidget(title: "Novosti"),
          Container(
            height: 400,
            child: ListView.builder(
              itemCount: data.length,
              itemBuilder: (BuildContext context, int index) {
                return _buildNotificationCard(data![index]);
              },
            ),
          ),
          TextButton(
              onPressed: () {
                Navigator.pushNamed(context, MovieListScreen.routeName);
              },
              child: Text("Pogledaj ponudu"))
        ],
      ),
    );
  }

  Widget _buildNotificationCard(notf.Notification x) {
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: Card(
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
                Text("${x.title}",
                    style: Theme.of(context).textTheme.headline5),
                SizedBox(
                  height: 20,
                ),
                MovieCardLine(label: "Description:", text: x.description),
                MovieCardLine(label: "Datum:", text: getDate(x.date)),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
