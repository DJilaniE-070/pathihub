// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
//
// public class Moviemaker
// {
//     static void MovieCreater()
//     {
//         List<MovieLogic> movies = new List<MovieLogic>
//         {
//             new MovieLogic
//             {
//                 MovieTitle = "The Adventure Begins",
//                 ReleaseYear = 2023,
//                 Genre = new List<string> { "Action", "Adventure", "Sci-Fi" },
//                 Director = "John Directorson",
//                 Writers = new List<string> { "Jane Writerly", "Michael Scriptson" },
//                 Plot = "In a futuristic world, Alice, a skilled adventurer, and her loyal sidekick Bob, embark on a thrilling journey to save their city from the evil plans of Eve, a cunning antagonist. With high-tech gadgets and unyielding determination, they must overcome various challenges and foes to restore peace to their homeland.",
//                 Rating = 8.5,
//                 RuntimeMinutes = 120,
//                 Language = "English",
//                 Country = "United States"   
//             },
//         };
//
//         string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
//     }
// }
