import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'movie.g.dart';

@JsonSerializable()
class Movie {
  String id;
  String? name;
  String? description;
  int? duration;
  int? releaseYear;
  String? country;
  String? actors;
  String? director;
  String? picture;
  String? genres;

  Movie(this.id, this.name, this.description, this.duration, this.releaseYear,
      this.country, this.actors, this.director, this.picture, this.genres) {}

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory Movie.fromJson(Map<String, dynamic> json) => _$MovieFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$MovieToJson(this);
}
