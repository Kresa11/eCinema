import 'package:flutter/material.dart';

class LogoTextWidget extends StatelessWidget {
  final bool login;
  const LogoTextWidget({
    required this.login,
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          padding: EdgeInsets.fromLTRB(0, 50.0, 0, 0),
          child: Icon(
            Icons.airplane_ticket,
            color: Colors.red[900],
            size: 100,
          ),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              "e",
              style: Theme.of(context).textTheme.headline2,
            ),
            Text(
              "Cinema",
              style: Theme.of(context).textTheme.headline3,
            ),
          ],
        ),
        Text(
          "ticket in your pocket",
          style: Theme.of(context).textTheme.bodyText2,
        ),
        SizedBox(
          height: 50,
        ),
        if (login)
          LoginText()
        else
          Text("Registracija", style: Theme.of(context).textTheme.headline2),
        SizedBox(
          height: 50,
        ),
      ],
    );
  }
}

class LoginText extends StatelessWidget {
  const LoginText({
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Text(
          "Log",
          style: Theme.of(context).textTheme.headline1,
        ),
        Text(
          "In",
          style: Theme.of(context).textTheme.headline4,
        ),
      ],
    );
  }
}
