import 'package:flutter/material.dart';

class MovieCardLine extends StatelessWidget {
  const MovieCardLine({
    Key? key,
    required this.label,
    required this.text,
    this.font = 14,
    this.padding = 0,
    this.white = false,
  }) : super(key: key);

  final String label;
  final String? text;
  final double? font;
  final double? padding;
  final bool? white;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.only(top: padding!),
      child: RichText(
        overflow: TextOverflow.clip,
        text: TextSpan(
          text: label + " ",
          style: TextStyle(
              color: Colors.red[900],
              fontWeight: FontWeight.bold,
              fontSize: font),
          children: <TextSpan>[
            TextSpan(
              text: '$text' ?? "",
              style: TextStyle(
                  color: white == true ? Colors.white : Colors.black,
                  fontSize: font,
                  fontWeight: FontWeight.normal),
            ),
          ],
        ),
      ),
    );
  }
}
