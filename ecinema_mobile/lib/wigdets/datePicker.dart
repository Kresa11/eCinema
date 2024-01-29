import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

Future<DateTime?> datePicker(BuildContext context) {
  return showDatePicker(
      context: context,
      initialDate: DateTime.now(),
      firstDate: DateTime(2015, 8),
      lastDate: DateTime(2101),
      builder: (context, child) {
        return Theme(
          data: Theme.of(context).copyWith(
            dialogBackgroundColor: Colors.grey[800], // days/years gridview
            textTheme: TextTheme(
              headline6: GoogleFonts.roboto(), // Selected Date portrait
            ),
            colorScheme: Theme.of(context).colorScheme.copyWith(
                // Title, selected date and day selection background (dark and light mode)
                surface: Colors.red,
                primary: Colors.red,
                // Title, selected date and month/year picker color (dark and light mode)
                onSurface: Colors.white,
                onPrimary: Colors.white),
            textButtonTheme: TextButtonThemeData(
              style: TextButton.styleFrom(
                foregroundColor: Colors.white,
                textStyle: GoogleFonts.roboto(),
              ),
            ),
          ),
          child: child!,
        );
      });
}
