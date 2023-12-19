using System;
using System.Net;
using System.Net.Mail;

public static class Email
{
    public static void start(Reservation reservation1, AccountModel Currentuser)
    {
        var reservation = new
        {
            FullName = Currentuser.FullName,
            Email = Currentuser.EmailAddress,
            Auditorium = reservation1.Auditorium,
            SeatName = string.Join(", ", reservation1.SeatNames),
            Movie = reservation1.movie,
            Date = reservation1.Date,
            Price = reservation1.Price,
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
            mailMessage.To.Add("pathihubtestrotterdam@gmail.com");

            try
            {
                // Send the email
                client.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }

    // Helper method to generate HTML-formatted email body
     static string GetHtmlBody(dynamic reservation)
    {
        return $@"
            <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            background-color: #f4f4f4;
                            color: #333;
                            padding: 20px;
                        }}
                        h2 {{
                            color: #0073e6;
                        }}
                        p {{
                            margin-bottom: 10px;
                        }}
                    </style>
                </head>
                <body>
                    <h2>Reservation Details</h2>
                    <p><strong>Name:</strong> {reservation.FullName}</p>
                    <p><strong>Email:</strong> {reservation.Email}</p>
                    <p><strong>Auditorium:</strong> {reservation.Auditorium}</p>
                    <p><strong>Seat(s):</strong> {reservation.SeatName}</p>
                    <p><strong>Movie:</strong> {reservation.Movie}</p>
                    <p><strong>Date:</strong> {reservation.Date}</p>
                    <p><strong>Price:</strong> {reservation.Price:C}</p>
                    <p><strong>Reservation Code:</strong> {reservation.ReservationCode}</p>
                    <p><strong>Location:</strong> {reservation.CinemaLocation}</p>
                </body>
            </html>";
    }
}