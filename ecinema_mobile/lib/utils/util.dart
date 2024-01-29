import 'dart:convert';
import 'dart:typed_data';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:intl/intl.dart';

class Authorization {
  static String? id;
  static String? username;
  static String? password;
}

Image imageFromBase64String(String base64String) {
  return Image.memory(
    base64Decode(base64String),
    fit: BoxFit.fill,
  );
}

Uint8List dataFromBase64String(String base64String) {
  return base64Decode(base64String);
}

String base64String(Uint8List data) {
  return base64Encode(data);
}

String formatNumber(dynamic) {
  var f = NumberFormat('###,00');
  if (dynamic == null) {
    return "";
  }

  return f.format(dynamic);
}

String getDate(DateTime? dateTime) {
  if (dateTime == null) return "Invalid format";
  return DateFormat("yyyy-MM-dd").format(dateTime);
}

String getTime(DateTime? dateTime) {
  if (dateTime == null) return "Invalid format";
  return DateFormat('HH:mm').format(dateTime);
}
