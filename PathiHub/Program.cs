﻿// See https://aka.ms/new-console-template for more information
using PathiHub.Presentation;

Console.Clear();
Console.WriteLine("Welcome to this amazing program");

// // Dit is om de schedules te clearen nodig voor elke week
// MovieToAuditoriumLogic logic = new();
// ReservationAccess access1 = new();
// MoviesAccess access = new();
// if (access.LoadFromJson())
//     {
//         logic.ClearSchedules();
//         // List<Movie> movies = access.GetItemList(); dit is alle movies
//         List<Movie> Movies = access.GetItemList();
//         List<Movie> movies = MovieOptionsLogic.FilterMovies(Movies);
//         List<Reservation> reservations = access1.GetItemList();
//         reservations.Clear();
//         // de bovenstaande 3 regels zijn om de movies te sorteren
//         // hieronder is voor de schedule json correct afgesteld te zijn op de films
//         logic.initializerAuditorium(movies);
//         access1.SaveToJson();
//         }
Menu.Start();
