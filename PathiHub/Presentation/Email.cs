using System;
using System.Net;
using System.Net.Mail;

class Email
{
    static void start(Reservation reservation1, AccountModel Currentuser)
    {
        var reservation = new
        {
            FullName = "test",
            Email = "123@test.nl",
            Auditorium = "2",
            SeatName = "5",
            Movie = "Jaws",
            Date = "12/12/2023",
            Price = 12,
            ReservationCode = "klajd1",
            CinemaLocation = "Rotterdam"
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
                Subject = "HTML Email Example",
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
                    <p><strong>Seat:</strong> {reservation.SeatName}</p>
                    <p><strong>Movie:</strong> {reservation.Movie}</p>
                    <p><strong>Date:</strong> {reservation.Date}</p>
                    <p><strong>Price:</strong> {reservation.Price:C}</p>
                    <p><strong>Reservation Code:</strong> {reservation.ReservationCode}</p>
                    <p><strong>Location:</strong> {reservation.CinemaLocation}</p>
                </body>
            </html>";
    }
}