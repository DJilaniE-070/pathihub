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
            Time = reservation1.Time,
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
            
            mailMessage.To.Add(reservation.Email);

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
        string htmlBody =
            "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n" +
            
                "<html>\n" +
                "\n" +
                "<head>\n" +
                "<!-- Compiled with Bootstrap Email version: 1.3.1 -->\n" +
                "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\n" +
                "<meta http-equiv=\"x-ua-compatible\" content=\"ie=edge\">\n" +
                "<meta name=\"x-apple-disable-message-reformatting\">\n" +
                "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n" + 
                "<meta name=\"format-detection\" content=\"telephone=no, date=no, address=no, email=no\">\n" +
                "<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">\n" + 
                "<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>\n"+
                "<link href=\"https://fonts.googleapis.com/css2?family=Poppins&display=swap\" rel=\"stylesheet\">\n" +
                "<style type=\"text/css\">\n"+
                "* { font-family: 'Calibri', monospace !important; }" + 
                "body,\n"+ 
                "table,\n"+
                "td {\n"+
                "font-family: 'Calibri', monospace\n"+
                "}\n"+
                "\n"+
                ".ExternalClass {\n"+ 
                "width: 100%\n"+ 
                "}\n"+ 
                "\n"+
                ".ExternalClass,\n"+
                ".ExternalClass p,\n"+
                ".ExternalClass span,\n"+
                ".ExternalClass font,\n"+
                ".ExternalClass td,\n"+
                ".ExternalClass div {\n"+
                "line-height: 150%\n"+
                "}\n"+
                "\n"+
                "a {\n"+
                "text-decoration: none\n"+
                "}\n"+
                "\n"+
                "* {\n"+
                "color: inherit\n"+
                "}\n"+
                "\n"+
                "a[x-apple-data-detectors],\n"+
                "u+#body a,\n"; 

        htmlBody += "#MessageViewBody a {\n";
        htmlBody += "color: inherit;\n";
        htmlBody += "text-decoration: none;\n";
        htmlBody += "font-size: inherit;\n";
        htmlBody += "font-family: inherit;\n";
        htmlBody += "font-weight: inherit;\n";
        htmlBody += "line-height: inherit\n";
        htmlBody += "}\n";
        htmlBody += "\n";
        htmlBody += "img {\n";
        htmlBody += "-ms-interpolation-mode: bicubic\n";
        htmlBody += "}\n";
        htmlBody += "\n";
        htmlBody += "table:not([class^=s-]) {\n";
        htmlBody += "font-family: 'Courier New', monospace;\n";
        htmlBody += "            mso-table-lspace: 0pt;\n";
        htmlBody += "            mso-table-rspace: 0pt;\n";
        htmlBody += "            border-spacing: 0px;\n";
        htmlBody += "            border-collapse: collapse\n";
        htmlBody += "        }\n";
        htmlBody += "\n";
        htmlBody += "        table:not([class^=s-]) td {\n";
        htmlBody += "            border-spacing: 0px;\n";
        htmlBody += "            border-collapse: collapse\n";
        htmlBody += "        }\n";
        htmlBody += "\n";
        htmlBody += "        @media screen and (max-width: 600px) {\n";
        htmlBody += "\n";
        htmlBody += "            .w-lg-48,\n";
        htmlBody += "            .w-lg-48>tbody>tr>td {\n";
        htmlBody += "                width: auto !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .w-full,\n";
        htmlBody += "            .w-full>tbody>tr>td {\n";
        htmlBody += "                width: 100% !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .w-16,\n";
        htmlBody += "            .w-16>tbody>tr>td {\n";
        htmlBody += "                width: 64px !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .p-lg-10:not(table),\n";
        htmlBody += "            .p-lg-10:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .p-lg-10.btn td a {\n";
        htmlBody += "                padding: 0 !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .p-2:not(table),\n";
        htmlBody += "            .p-2:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .p-2.btn td a {\n";
        htmlBody += "                padding: 8px !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .pr-4:not(table),\n";
        htmlBody += "            .pr-4:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .pr-4.btn td a,\n";
        htmlBody += "            .px-4:not(table),\n";
        htmlBody += "            .px-4:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .px-4.btn td a {\n";
        htmlBody += "                padding-right: 16px !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .pl-4:not(table),\n";
        htmlBody += "            .pl-4:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .pl-4.btn td a,\n";
        htmlBody += "            .px-4:not(table),\n";
        htmlBody += "            .px-4:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .px-4.btn td a {\n";
        htmlBody += "                padding-left: 16px !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .pr-6:not(table),\n";
        htmlBody += "            .pr-6:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .pr-6.btn td a,\n";
        htmlBody += "            .px-6:not(table),\n";
        htmlBody += "            .px-6:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .px-6.btn td a {\n";
        htmlBody += "                padding-right: 24px !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .pl-6:not(table),\n";
        htmlBody += "            .pl-6:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .pl-6.btn td a,\n";
        htmlBody += "            .px-6:not(table),\n";
        htmlBody += "            .px-6:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .px-6.btn td a {\n";
        htmlBody += "                padding-left: 24px !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .pt-8:not(table),\n";
        htmlBody += "            .pt-8:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .pt-8.btn td a,\n";
        htmlBody += "            .py-8:not(table),\n";
        htmlBody += "            .py-8:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .py-8.btn td a {\n";
        htmlBody += "                padding-top: 32px !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .pb-8:not(table),\n";
        htmlBody += "            .pb-8:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .pb-8.btn td a,\n";
        htmlBody += "            .py-8:not(table),\n";
        htmlBody += "            .py-8:not(.btn)>tbody>tr>td,\n";
        htmlBody += "            .py-8.btn td a {\n";
        htmlBody += "                padding-bottom: 32px !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            *[class*=s-lg-]>tbody>tr>td {\n";
        htmlBody += "                font-size: 0 !important;\n";
        htmlBody += "                line-height: 0 !important;\n";
        htmlBody += "                height: 0 !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .s-4>tbody>tr>td {\n";
        htmlBody += "                font-size: 16px !important;\n";
        htmlBody += "                line-height: 16px !important;\n";
        htmlBody += "                height: 16px !important\n";
        htmlBody += "            }\n";
        htmlBody += "\n";
        htmlBody += "            .s-6>tbody>tr>td {\n";
        htmlBody += "                font-size: 24px !important;\n";
        htmlBody += "                line-height: 24px !important;\n";
        htmlBody += "                height: 24px !important\n";
        htmlBody += "            }\n";
        htmlBody += "        }\n";
        htmlBody += "    </style>\n";
        htmlBody += "</head>\n";
        htmlBody += "\n";
        htmlBody += "<body class=\"bg-red-100\"\n";
        //important

        htmlBody +=
            "style=\"outline: 0; width: 100%; min-width: 100%; height: 100%; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; font-family: 'Courier New', monospace !important; line-height: 24px; font-weight: normal; font-size: 16px; -moz-box-sizing: border-box; -webkit-box-sizing: border-box; box-sizing: border-box; color: #000000; margin: 0; padding: 0; border-width: 0;\"\n";

        htmlBody += "bgcolor=\"#52676e\">\n";
        htmlBody +=
            "<table class=\"bg-red-100 body\" valign=\"top\" role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";
        htmlBody +=
            "        style=\"outline: 0; width: 100%; min-width: 100%; height: 100%; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; font-family: 'Courier New', monospace !important; line-height: 24px; font-weight: normal; font-size: 16px; -moz-box-sizing: border-box; -webkit-box-sizing: border-box; box-sizing: border-box; color: #000000; margin: 0; padding: 0; border-width: 0;\"\n";

        htmlBody += "        bgcolor=\"#b8cdd4\">\n";
        htmlBody += "        <tbody>\n";
        htmlBody += "            <tr>\n";
        htmlBody += // achtergrond kleur box
            "                <td valign=\"top\" style=\"line-height: 24px; font-size: 16px; margin: 0;\" align=\"left\" bgcolor=\"#fcfcfc\">\n";

        htmlBody +=
            "                    <table class=\"container\" role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";
        htmlBody += "                        style=\"width: 100%;\">\n";
        htmlBody += "                        <tbody>\n";
        htmlBody += "                            <tr>\n";
        htmlBody += "                                <td align=\"center\"\n";
        htmlBody +=
            "                                    style=\"line-height: 24px; font-size: 16px; margin: 0; padding: 0 16px;\">\n";
        htmlBody +=
            "                                    <table align=\"center\" role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";
        htmlBody +=
            "                                        style=\"width: 100%; max-width: 600px; margin: 0 auto;\">\n";
        htmlBody += "                                        <tbody>\n";
        htmlBody += "                                            <tr>\n";
        htmlBody +=
            "                                                <td style=\"line-height: 24px; font-size: 16px; margin: 0;\" align=\"left\">\n";

        htmlBody +=
            "                                                    <table class=\"s-6 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody +=
            "                                                        cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "                                                        width=\"100%\">\n";

        htmlBody += "                                                        <tbody>\n";

        htmlBody += "                                                            <tr>\n";

        htmlBody +=
            "                                                                <td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody +=
            "                                                                    align=\"left\" width=\"100%\" height=\"24\">\n";

        htmlBody += "                                                                    &#160;\n";

        htmlBody += "                                                                </td>\n";

        htmlBody += "                                                            </tr>\n";

        htmlBody += "                                                        </tbody>\n";

        htmlBody += "                                                    </table>\n";

        htmlBody +=
            "                                                    <table class=\"s-6 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody +=
            "                                                        cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "                                                        width=\"100%\">\n";

        htmlBody += "                                                        <tbody>\n";

        htmlBody += "                                                            <tr>\n";

        htmlBody +=
            "                                                                <td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody +=
            "                                                                    align=\"left\" width=\"100%\" height=\"24\">\n";

        htmlBody += "                                                                    &#160;\n";

        htmlBody += "                                                                </td>\n";

        htmlBody += "                                                            </tr>\n";

        htmlBody += "                                                        </tbody>\n";

        htmlBody += "                                                    </table>\n";

        htmlBody += "                                                    <div class=\"space-y-4\">\n";

        htmlBody += "                                                        <h1 class=\"text-4xl fw-800\"\n";

        htmlBody +=
            "                                                            style=\"padding-top: 0; padding-bottom: 0; font-weight: 800 !important; vertical-align: baseline; font-size: 36px; line-height: 43.2px; margin: 0;\"\n";

        htmlBody += 
            "                                                            align=\"center\">Bedankt voor het reserveren,\n";

        htmlBody += "                                                        </h1>\n";

        htmlBody +=
            "                                                        <table class=\"s-4 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody +=
            "                                                            cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "                                                            width=\"100%\">\n";

        htmlBody += "                                                            <tbody>\n";

        htmlBody += "                                                                <tr>\n";

        htmlBody +=
            "                                                                    <td style=\"line-height: 16px; font-size: 16px; width: 100%; height: 16px; margin: 0;\"\n";

        htmlBody +=
            "                                                                        align=\"left\" width=\"100%\" height=\"16\">\n";

        htmlBody += "                                                                        &#160;\n";

        htmlBody += "                                                                    </td>\n";

        htmlBody += "                                                                </tr>\n";

        htmlBody += "                                                            </tbody>\n";

        htmlBody += "                                                        </table>\n";

        htmlBody += "                                                        <p class=\"\"\n";

        htmlBody +=

            "                                                            style=\"line-height: 24px; font-size: 20px; width: 100%; margin: 0;\"\n";

        htmlBody +=
            $"                                                            align=\"center\">Bedankt {reservation.FullName} dat u heeft gereserveerd bij PathiHub ❤️\n";

        htmlBody += "                                                        </p>\n";

        htmlBody +=
            "                                                        <table class=\"s-4 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody +=
            "                                                            cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";
        htmlBody += "                                                            width=\"100%\">\n";

        htmlBody += "                                                            <tbody>\n";

        htmlBody += "                                                                <tr>\n";

        htmlBody +=
            "                                                                    <td style=\"line-height: 16px; font-size: 16px; width: 100%; height: 16px; margin: 0;\"\n";

        htmlBody +=
            "                                                                        align=\"left\" width=\"100%\" height=\"16\">\n";

        htmlBody += "                                                                        &#160;\n";

        htmlBody += "                                                                    </td>\n";

        htmlBody += "                                                                </tr>\n";

        htmlBody += "                                                            </tbody>\n";

        htmlBody += "                                                        </table>\n";

        htmlBody +=
            "                                                        <table class=\"btn btn-red-500 rounded-full px-6 w-full w-lg-48\"\n";

        htmlBody +=
            "                                                            role=\"presentation\" border=\"0\" cellpadding=\"0\"\n";

        htmlBody += "                                                            cellspacing=\"0\"\n";

        htmlBody +=
            "                                                            style=\"border-radius: 9999px; border-collapse: separate !important; width: 192px;\"\n";

        htmlBody += "                                                            width=\"192\">\n";

        htmlBody += "                                                        </table>\n";

        htmlBody += "                                                    </div>\n";

        htmlBody +=
            "                                                    <table class=\"s-6 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody +=
            "                                                        cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "                                                        width=\"100%\">\n";

        htmlBody += "                                                        <tbody>\n";

        htmlBody += "                                                            <tr>\n";

        htmlBody +=
            "                                                                <td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody +=
            "                                                                    align=\"left\" width=\"100%\" height=\"24\">\n";

        htmlBody += "                                                                    &#160;\n";

        htmlBody += "                                                                </td>\n";

        htmlBody += "                                                            </tr>\n";

        htmlBody += "                                                        </tbody>\n";

        htmlBody += "                                                    </table>\n";

        htmlBody +=
            "                                                    <table class=\"card rounded-3xl px-4 py-8 p-lg-10\"\n";

        htmlBody +=
            "                                                        role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody +=
            "                                                        style=\"border-radius: 24px; border-collapse: separate !important; width: 100%; overflow: hidden; border: 1px solid #e2e8f0;\"\n";

        htmlBody += "                                                        bgcolor=\"#b8cdd4\">\n";

        htmlBody += "                                                        <tbody>\n";

        htmlBody += "                                                            <tr>\n";

        htmlBody +=
            "                                                                <td style=\"line-height: 24px; font-size: 16px; width: 100%; border-radius: 24px; margin: 0; padding: 40px;\"\n";

        htmlBody += //main color for the body of the email
            "                                                                    align=\"left\" bgcolor=\"#b8cdd4\">\n";

        htmlBody += // Link voor foto
            $"                                                                    <img src=\"https://static.vecteezy.com/system/resources/previews/001/189/271/non_2x/tickets-png.png\" title =\"Bioscoopzaal\" alt=\"Bioscoop\" style=\"width: 100%;\">\n";

        htmlBody += "                                                                    <h3 class=\"text-center\"\n";

        htmlBody +=
            "                                                                        style=\"padding-top: 0; padding-bottom: 20px; font-weight: 500; vertical-align: baseline; font-size: 28px; line-height: 33.6px; margin: 0;\"\n";

        htmlBody +=
            "                                                                        align=\"center\">Uw Reservering:</h3>\n";
        htmlBody +=
            $"                                                                <h3 align=\"center\">Tickets voor de film: {reservation.Movie} </h3>\n";
        htmlBody +=
            "                                                                <h3 align=\"center\">-------------</h3>\n";
        htmlBody +=
            $"                                                                <h3 align=\"center\"> Start date of the movie: {reservation.Date} </h3>\n";
        htmlBody +=
            "                                                                <h3 align=\"center\">-------------</h3>\n";
        htmlBody +=
            $"                                                                <h3 align=\"center\">Start time of the movie: {reservation.Time}</h3>\n";
        htmlBody +=
            "                                                                <h3 align=\"center\"></h3>\n";
        htmlBody +=
            "                                                                <h3 align=\"center\">-------------</h3>\n";
        htmlBody +=
            $"                                                                <h3 align=\"center\">Total price: €{reservation.Price} </h3>\n";
        htmlBody +=
            "                                                                <h3 align=\"center\">-------------</h3>\n";
        htmlBody +=
            $"                                                                <h3 align=\"center\">Reservation Code: {reservation.ReservationCode}</h3>\n";



        htmlBody +=
            "                                                                    <h1 class=\"text-4xl fw-800\"\n";

        htmlBody +=
            "                                                                        style=\" padding-bottom: 0; font-weight: 600 !important; vertical-align: baseline; font-size: 3rem; line-height: 43.2px; margin: 0 auto;  letter-spacing: 5px;\"\n";

        htmlBody +=
            "                                                                        <!-- via c# naam meesturen -->\n";

        htmlBody += "                                                                    </h1>\n";

        htmlBody += "                                                                    <p class=\"text-center\"\n";

        htmlBody +=
            "                                                                        style=\"padding-top: 50px; color: darkgray; padding-bottom: 20px; font-weight: 400; vertical-align: baseline; font-size: 16px; line-height: 33.6px; margin: 0;\"\n";

        htmlBody +=
            "                                                                    <table class=\"s-6 w-full\" role=\"presentation\"\n";

        htmlBody +=
            "                                                                        border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody +=
            "                                                                        style=\"width: 100%;\" width=\"100%\">\n";

        htmlBody += "                                                                        <tbody>\n";

        htmlBody += "                                                                            <tr>\n";

        htmlBody +=
            "                                                                                <td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody +=
            "                                                                                    align=\"left\" width=\"100%\"\n";

        htmlBody +=
            "                                                                                    height=\"24\">\n";

        htmlBody += "                                                                                    &#160;\n";

        htmlBody += "                                                                                </td>\n";

        htmlBody += "                                                                            </tr>\n";

        htmlBody += "                                                                        </tbody>\n";

        htmlBody += "                                                                    </table>\n";

        htmlBody +=
            "                                                                    <table class=\"hr\" role=\"presentation\" border=\"0\"\n";

        htmlBody +=
            "                                                                        cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody += "                                                                        style=\"width: 100%;\">\n";

        htmlBody += "                                                                        <tbody>\n";

        htmlBody += "                                                                            <tr>\n";

        htmlBody +=
            "                                                                                <td style=\"line-height: 24px; font-size: 16px; border-top-width: 1px; border-top-color: #e2e8f0; border-top-style: solid; height: 1px; width: 100%; margin: 0;\"\n";

        htmlBody +=
            "                                                                                    align=\"left\">\n";

        htmlBody += "                                                                                </td>\n";

        htmlBody += "                                                                            </tr>\n";

        htmlBody += "                                                                        </tbody>\n";

        htmlBody += "                                                                    </table>\n";

        htmlBody +=
            "                                                                    <table class=\"s-6 w-full\" role=\"presentation\"\n";

        htmlBody +=
            "                                                                        border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody +=
            "                                                                        style=\"width: 100%;\" width=\"100%\">\n";

        htmlBody += "                                                                        <tbody>\n";

        htmlBody += "<tr>\n";

        htmlBody += "<td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody += "align=\"left\" width=\"100%\"\n";

        htmlBody += "height=\"24\">\n";


        //de bolletjes waar op ingedrukt kan worden
        htmlBody += "&#160;\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "<p style=\"line-height: 24px; font-size: 16px; color:black; width: 100%; margin: 0;\"\n";
        htmlBody += "align=\"left\">Voor vragen kunt u ons bellen\n";

        htmlBody += "bellen via: 06-12 34 56 78 \n";

        htmlBody += "</p>\n";

        htmlBody +=
            "<p style=\"line-height: 24px; font-size: 16px; color:black; color: red; width: 100%; margin: 0;\"\n";

        htmlBody += "align=\"left\">Vergeet niet te laat of helemaal niet te komen!\n";

        htmlBody += "Dit kan leiden tot een boete.\n";

        htmlBody += "</p>\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "<table class=\"s-6 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody += "cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "width=\"100%\">\n";

        htmlBody += "<tbody>\n";

        htmlBody += "<tr>\n";

        htmlBody += "<td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody += "align=\"left\" width=\"100%\" height=\"24\">\n";

        htmlBody += "&#160;\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody +=
            "<script data-cfasync=\"false\" src=\"/cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js\"></script>\n";

        htmlBody += "</body>\n";

        htmlBody += "\n";

        htmlBody += "</html>\n";
        

        return htmlBody;
    }
}