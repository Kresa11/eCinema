// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'movie.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Movie _$MovieFromJson(Map<String, dynamic> json) => Movie(
      json['id'] as String,
      json['name'] as String?,
      json['description'] as String?,
      json['duration'] as int?,
      json['releaseYear'] as int?,
      json['country'] as String?,
      json['actors'] as String?,
      json['director'] as String?,
      json['picture'] as String?,
      json['genres'] as String?,
    );

Map<String, dynamic> _$MovieToJson(Movie instance) => <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
      'duration': instance.duration,
      'releaseYear': instance.releaseYear,
      'country': instance.country,
      'actors': instance.actors,
      'director': instance.director,
      'picture': instance.picture,
      'genres': instance.genres,
    };
