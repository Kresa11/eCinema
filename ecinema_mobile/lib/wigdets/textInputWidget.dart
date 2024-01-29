import 'package:email_validator/email_validator.dart';
import 'package:flutter/material.dart';

class TextInputWidget extends StatelessWidget {
  const TextInputWidget(
      {Key? key,
      required this.controller,
      required this.labelText,
      required this.minLength,
      required this.isEmail,
      required this.isPhoneNumber})
      : super(key: key);

  final TextEditingController controller;
  final String? labelText;
  final int minLength;
  final bool isEmail;
  final bool isPhoneNumber;

  @override
  Widget build(BuildContext context) {
    bool password = labelText == "Lozinka" || labelText == "Potvrdi lozinku";
    RegExp phoneNumberRegex = RegExp(r'^\d{3}[\s-]\d{3}[\s-]\d{3,4}$');

    return Container(
        margin: EdgeInsets.all(8),
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.circular(10),
        ),
        child: TextFormField(
            validator: (value) {
              if (value!.isEmpty) {
                return '$labelText ne smije biti prazno!';
              } else if (minLength > 0 && value.length < minLength) {
                return '$labelText mora imat minimalno $minLength karaktera!';
              } else if (isEmail && !EmailValidator.validate(value)) {
                return '$labelText mora biti u tačnom formatu!';
              } else if (isPhoneNumber && !phoneNumberRegex.hasMatch(value)) {
                return '$labelText mora biti u formatu kao npr 061 111 111';
              }
              return null;
            },
            style: Theme.of(context).textTheme.bodyText1,
            obscureText: password,
            controller: controller,
            decoration: InputDecoration(
              hintText: this.labelText ?? "",
              hintStyle:
                  TextStyle(fontSize: 18.0, color: Colors.red.withOpacity(0.6)),
            )));
  }
}
