import 'package:ecinema_mobile/providers/userProvider.dart';
import 'package:ecinema_mobile/screens/movieListScreen.dart';
import 'package:ecinema_mobile/wigdets/textInputWidget.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../models/user.dart';
import '../requests/userUpdateRequest.dart';
import '../utils/util.dart';
import '../wigdets/headerWidget.dart';
import '../wigdets/master_screen.dart';
import 'loadingScreen.dart';

class MyProfileScreen extends StatefulWidget {
  static const String routeName = "/profile";
  const MyProfileScreen({Key? key}) : super(key: key);
  @override
  State<MyProfileScreen> createState() => _MyProfileScreenState();
}

class _MyProfileScreenState extends State<MyProfileScreen> {
  UserProvider? _userProvider = null;
  User? user = null;
  UserUpdateRequest userUpdateRequest = new UserUpdateRequest();

  TextEditingController _firstNameController = new TextEditingController();
  TextEditingController _lastnameController = new TextEditingController();
  TextEditingController _emailController = new TextEditingController();
  TextEditingController _phoneController = new TextEditingController();
  TextEditingController _usernameController = new TextEditingController();

  final _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    super.initState();
    _userProvider = context.read<UserProvider>();
    loadData();
  }

  Future loadData() async {
    if (Authorization.id != null) {
      var tmpData = await _userProvider?.getById(Authorization.id!);

      setState(() {
        user = tmpData;
        _firstNameController.text = tmpData?.firstName ?? "";
        _lastnameController.text = tmpData?.lastName ?? "";
        _emailController.text = tmpData?.email ?? "";
        _phoneController.text = tmpData?.phoneNumber ?? "";
        _usernameController.text = tmpData?.username ?? "";
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    if (user == null) return LoadingScreen();
    return Form(
      key: _formKey,
      child: MasterScreenWidget(
        child: SingleChildScrollView(
          child: Column(
            children: [
              HeaderWidget(title: "Moj Profil"),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    setInput(context, "Ime", _firstNameController, 2),
                    setInput(context, "Prezime", _lastnameController, 2),
                    setInput(context, "Email", _emailController, 7),
                    setInput(context, "Broj telefona", _phoneController, 9),
                    setInput(context, "Korisničko ime", _usernameController, 6),
                  ],
                ),
              ),
              TextButton(
                onPressed: () async {
                  if (_formKey.currentState!.validate()) {
                    try {
                      userUpdateRequest.firstName = _firstNameController.text;
                      userUpdateRequest.lastName = _lastnameController.text;
                      userUpdateRequest.email = _emailController.text;
                      userUpdateRequest.phoneNumber = _phoneController.text;
                      userUpdateRequest.username = _usernameController.text;

                      await _userProvider?.update(user!.id, userUpdateRequest);
                      Navigator.pushNamed(context, MovieListScreen.routeName);
                    } catch (e) {
                      errorDialog(context, e);
                    }
                  }
                },
                child: Text('Sačuvaj'),
              )
            ],
          ),
        ),
      ),
    );
  }

  Container setInput(BuildContext context, String label,
      TextEditingController controller, int minLength) {
    var email = false;
    var phoneNumber = false;

    if (label == "Email") email = true;
    if (label == "Broj telefona") phoneNumber = true;

    return Container(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.fromLTRB(10, 5, 0, 0),
            child: Text(label, style: Theme.of(context).textTheme.bodyText2),
          ),
          TextInputWidget(
              labelText: label,
              controller: controller,
              minLength: minLength,
              isEmail: email,
              isPhoneNumber: phoneNumber),
        ],
      ),
    );
  }
}

Future<dynamic> errorDialog(BuildContext context, Object e) {
  return showDialog(
      context: context,
      builder: (BuildContext context) => AlertDialog(
            title: Text("Error"),
            content: Text(e.toString()),
            actions: [
              TextButton(
                child: Text("Ok"),
                onPressed: () => Navigator.pop(context),
              )
            ],
          ));
}
