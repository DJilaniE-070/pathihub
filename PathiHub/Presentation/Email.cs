using System;
using System.Net;
using System.Net.Mail;

public static class Email
{
    public static void start(Reservation reservation1, AccountModel Currentuser)
    {
        string formattedseats = FormatSeatList(reservation1.SeatNames);
        var reservation = new
        {
            FullName = Currentuser.FullName,
            Email = Currentuser.EmailAddress,
            Auditorium = reservation1.Auditorium,
            SeatName = formattedseats,
            Movie = reservation1.movie,
            Date = reservation1.Date,
            Time = reservation1.Time,
            ticketPrice = reservation1.Price,
            ReservationCode = reservation1.ReservationCode,
            CinemaLocation = reservation1.CinemaLocation
        };
        // Set up the SMTP client with Gmail's SMTP server
        using (var client = new SmtpClient("smtp.gmail.com"))
        {
            // Set the port and enable SSL
            client.Port = 587;
            client.EnableSsl = true;

            // Specify your Gmail credentials
            client.Credentials = new NetworkCredential("rotterdampathihub@gmail.com", "uigx rxrw tgxn oifd");

            // Create the HTML-formatted mail message
            var mailMessage = new MailMessage
            {
                From = new MailAddress("rotterdampathihub@gmail.com"),
                Subject = "Your reservation",
                IsBodyHtml = true,
                Body = GetHtmlBody(reservation)
            };

            // Add recipient email address
            try
            {
                // Send the email
                mailMessage.To.Add(reservation.Email);
                client.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception)
            {
                Helpers.PrintStringToColor($"Error sending email the given mail is not correct","red");
            }
        }
    }
    public static void manualstart(Reservation reservation1, string FullName, string EmailAddress)
        {
            string formattedseats = FormatSeatList(reservation1.SeatNames);
            var reservation = new
            {
                FullName = FullName,
                Email = EmailAddress,
                Auditorium = reservation1.Auditorium,
                SeatName = formattedseats,
                Movie = reservation1.movie,
                Date = reservation1.Date,
                Time = reservation1.Time,
                ticketPrice = reservation1.Price,
                ReservationCode = reservation1.ReservationCode,
                CinemaLocation = reservation1.CinemaLocation
            };
            // Set up the SMTP client with Gmail's SMTP server
            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                // Set the port and enable SSL
                client.Port = 587;
                client.EnableSsl = true;

                // Specify your Gmail credentials
                client.Credentials = new NetworkCredential("rotterdampathihub@gmail.com", "uigx rxrw tgxn oifd");

                // Create the HTML-formatted mail message
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("rotterdampathihub@gmail.com"),
                    Subject = "Your reservation",
                    IsBodyHtml = true,
                    Body = GetHtmlBody(reservation)
                };

                

                try
                {
                    // Add user email address
                    mailMessage.To.Add(reservation.Email);
                    // Send the email
                    client.Send(mailMessage);
                    Console.WriteLine("Email sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email the given mail is not correct");
                }
            }
    }
    static string FormatSeatList(List<string> seatList)
    {
        string formattedString = "";

        foreach (string seat in seatList)
        {
            // Split the string into row and seat
            string[] parts = seat.Split(' ');
            string row = parts[0];
            string seatNumber = parts[1];

            // Format the output
            formattedString += $"Row: {row} Seat: {seatNumber}, ";
            formattedString+= "\n";
        }

        // Remove the trailing comma and space
        formattedString = formattedString.TrimEnd(',', ' ');

        return formattedString;
    }
    // Helper method to generate HTML-formatted email body
    static string GetHtmlBody(dynamic reservation)
    {
        string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataModels/email.html"));

            // Read the HTML file content into a string
            string htmlContent = File.ReadAllText(path);

            // Replace placeholders with actual data
            string dynamicHtml = htmlContent
                .Replace("{Current user}", (string)reservation.FullName)
                .Replace("{Movietitle}", (string)reservation.Movie)
                .Replace("{dag datum}", (string)reservation.Date)
                .Replace("{tijdsduur}", (string)reservation.Time)
                .Replace("{totale kosten}", Convert.ToString(reservation.ticketPrice))
                .Replace("{stoelen}", (string)reservation.SeatName)
                .Replace("{Reserverings code}", (string)reservation.ReservationCode);

            // Now you can use the 'dynamicHtml' string in your code
           return (dynamicHtml);
    }
}