# Windows Universal App using the Omdb Api and MVVM
###### Martin Coleman, G00312351
Fourth Year Mobile Apps Project 

## Introduction
The idea for this project was to create a windows universal apps project that implements MVVM. I decided to use the OMDB Api to search for movies and display the information about the movies.
I also decided to use local storage to allow users to store movies.

## MVVM
Model-view View-model
MVVM separates the responsibility for the appearance and layout of the UI from the responsibility for the presentation logic.

###Model
The model represents the data we are dealing with.

###View 
The view is what the end user sees and interacts with.

##Viewmodel 
The Viewmodel connects the Model to the View.
It allows for loose coupling and binding of data.

## Api
The OMDb API is a free web service used to obtain movie information.

####OMDB API
API URL | HTTP Method | Response Data 
------------ | ----------- |-----------
"http://www.omdbapi.com/?t=NAME&plot=short&r=json" | GET | Returns Json with Information on Requested Movie given Name


Example of Json recieved from API
```json
{
  "Title": "Goodfellas",
  "Year": "1990",
  "Rated": "R",
  "Released": "21 Sep 1990",
  "Runtime": "146 min",
  "Genre": "Biography, Crime, Drama",
  "Director": "Martin Scorsese",
  "Writer": "Nicholas Pileggi (book), Nicholas Pileggi (screenplay), Martin Scorsese (screenplay)",
  "Actors": "Robert De Niro, Ray Liotta, Joe Pesci, Lorraine Bracco",
  "Plot": "Henry Hill and his friends work their way up through the mob hierarchy.",
  "Language": "English, Italian",
  "Country": "USA",
  "Awards": "Won 1 Oscar. Another 37 wins & 32 nominations.",
  "Poster": "https://images-na.ssl-images-amazon.com/images/M/MV5BNThjMzczMjctZmIwOC00NTQ4LWJhZWItZDdhNTk5ZTdiMWFlXkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_SX300.jpg",
  "Metascore": "89",
  "imdbRating": "8.7",
  "imdbVotes": "745,048",
  "imdbID": "tt0099685",
  "Type": "movie",
  "Response": "True"
}
```

## Local Storage
I used local storage to save movies in a Json Array.

Initialise and get a handle on File
```
StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
StorageFile movieFile;
```

Open File or create if doesnt exist
```
movieFile = await storageFolder.CreateFileAsync("MyMovies.txt", CreationCollisionOption.OpenIfExists);
string movieJson = await Windows.Storage.FileIO.ReadTextAsync(movieFile);
```

Example of Json Stored Object
```json
{
  "Title": "Goodfellas",
  "Year": "1990",
  "Rated": "R",
  "Released": "21 Sep 1990",
  "Runtime": "146 min",
  "Genre": "Biography, Crime, Drama",
  "Director": "Martin Scorsese",
  "Writer": "Nicholas Pileggi (book), Nicholas Pileggi (screenplay), Martin Scorsese (screenplay)",
  "Actors": "Robert De Niro, Ray Liotta, Joe Pesci, Lorraine Bracco",
  "Plot": "Henry Hill and his friends work their way up through the mob hierarchy.",
  "Language": "English, Italian",
  "Country": "USA",
  "Awards": "Won 1 Oscar. Another 37 wins & 32 nominations.",
  "Poster": "https://images-na.ssl-images-amazon.com/images/M/MV5BNThjMzczMjctZmIwOC00NTQ4LWJhZWItZDdhNTk5ZTdiMWFlXkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_SX300.jpg",
  "Metascore": "89",
  "imdbRating": "8.7",
  "imdbVotes": "745,048",
  "imdbID": "tt0099685",
  "Type": "movie",
  "Response": "True"
}
```

## Json.Net 
I used Json.Net by newtonsoft in this project as it handles serialisation and deserialisation very well.
I use it to convert my Movie model classes into Json Strings for saving to local to local storage.
<br>
http://www.newtonsoft.com/json

##Project Management
I used GitHub for managing the projects source control and issue tracking.
