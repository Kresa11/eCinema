import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class HeaderWidget extends StatelessWidget {
  final String title;

  HeaderWidget({required this.title});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.symmetric(vertical: 5),
      child: Text(title, style: Theme.of(context).textTheme.headline2),
      height: 60.0,
    );
  }
}
