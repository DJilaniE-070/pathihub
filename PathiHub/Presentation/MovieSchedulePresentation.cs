using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
public static class MovieSchedule
{
    public static Movie SelectedMovie;
    public static string Date;

    public static void DisplaySchedule()
    {
    // "Monday/12:00-14.30","Thursday/18:00-20:30"
    List<string> Scheduled = SelectedMovie.Scheduled;
    }
}