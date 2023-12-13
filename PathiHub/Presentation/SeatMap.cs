using System.Collections;
using System.Text;
using PathiHub.Presentation;

public class SeatMap
{    
    // lijst om reservaties op te slaan
    //public static List<List<string>> ReservedSeats = new List<List<string>>();
    //public static List<ReservedSeats> ReserveSeat = new List<ReservedSeats>()
    public List<Tuple<int, int>> yourseats = new List<Tuple<int, int>>();
    public static List<string> ReservedSeats = new List<string>();
    public static Hashtable ReservedSeat = new Hashtable();

    // auditorium 1 met 150 stoelen (14 rijen en 12 stoelen per rij)
    public List<List<string>> auditorium1 = new List<List<string>>
    {
        // seat                  1    2    3    4    5    6    7    8    9    10   11   12
        new List<string> { "3", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" },
        new List<string> { "2", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" },
        new List<string> { "2", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" },
        new List<string> { "2", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" },
        new List<string> { "2", "C", "C", "C", "C", "C", "B", "B", "C", "C", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "C", "B", "B", "B", "B", "C", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "B", "B", "A", "A", "B", "B", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "C", "B", "B", "B", "B", "C", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "C", "C", "B", "B", "C", "C", "C", "C", "C" },
        new List<string> { "2", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" },
        new List<string> { "2", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" },
        new List<string> { "2", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" }
    };
    // auditorium 2 met 300 stoelen (19 rijen en 18 stoelen per rij)
    public List<List<string>> auditorium2 = new List<List<string>>
    {
        // seat                  1    2    3    4    5    6    7    8    9    10   11   12   13   14   15   16   17   18
        new List<string> { "3", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" },
        new List<string> { "2", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X" },
        new List<string> { "2", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X" },
        new List<string> { "2", "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X" },
        new List<string> { "2", "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X" },
        new List<string> { "2", "X", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "X" },
        new List<string> { "2", "X", "C", "C", "C", "B", "B", "B", "B", "A", "A", "B", "B", "B", "B", "C", "C", "C", "X" },
        new List<string> { "2", "C", "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "C", "C", "C" },
        new List<string> { "2", "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C" },
        new List<string> { "2", "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C" },
        new List<string> { "2", "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C" },
        new List<string> { "2", "X", "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C", "X" },
        new List<string> { "2", "X", "C", "C", "C", "B", "B", "B", "B", "A", "A", "B", "B", "B", "B", "C", "C", "C", "X" },
        new List<string> { "2", "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X" },
        new List<string> { "2", "X", "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X", "X" },
        new List<string> { "2", "X", "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X", "X" },
        new List<string> { "2", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X" },
        new List<string> { "2", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X" },
        new List<string> { "2", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X" }
    };
    // auditorium 3 met 500 stoelen (20 rijen en 30 stoelen per rij)
    public List<List<string>> auditorium3 = new List<List<string>>
    {
        // seat                  1    2    3    4    5    6    7    8    9    10   11   12   13   14   15   16   17   18   19   20   21   22   23   24   25   26   27   28   29   30
        new List<string> { "3", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" },
        new List<string> { "2", "X", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X", "X" },
        new List<string> { "2", "X", "X", "X", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "X", "X", "X" },
        new List<string> { "2", "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
        new List<string> { "2", "X", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X", "X" },
        new List<string> { "2", "X", "X", "X", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "A", "A", "A", "A", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "X", "X", "X" },
        new List<string> { "2", "X", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X", "X" },
        new List<string> { "2", "X", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "X" },
        new List<string> { "2", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C" },
        new List<string> { "2", "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "A", "A", "A", "A", "A", "A", "A", "A", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C" },
        new List<string> { "2", "X", "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C", "X" },
        new List<string> { "2", "X", "X", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "X", "X" },
        new List<string> { "2", "X", "X", "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C", "X", "X" },
        new List<string> { "2", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X" },
        new List<string> { "2", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "B", "B", "B", "B", "B", "B", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X" },
        new List<string> { "2", "X", "X", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X", "X", "X" },
        new List<string> { "2", "X", "X", "X", "X", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X", "X", "X", "X", "X" },
        new List<string> { "2", "X", "X", "X", "X", "X", "X", "X", "X", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "C", "X", "X", "X", "X", "X", "X", "X", "X" }
    };
    public List<string> rows1 = new List<string> { "14", "13", "12", "11", "10", "9 ", "8 ", "7 ", "6 ", "5 ", "4 ", "3 ", "2 ", "1 " };
    public List<string> rows2 = new List<string> { "19", "18", "17", "16", "15", "14", "13", "12", "11", "10", "9 ", "8 ", "7 ", "6 ", "5 ", "4 ", "3 ", "2 ", "1 " };
    public List<string> rows3 = new List<string> { "20", "19", "18", "17", "16", "15", "14", "13", "12", "11", "10", "9 ", "8 ", "7 ", "6 ", "5 ", "4 ", "3 ", "2 ", "1 " };
    public List<string> rows = new();
    public List<List<string>> Auditorium = new();
    private double _priceA;
    private double _priceB;
    private double _priceC;
    public string Message = "";
    public int AuditoriumNumber;
    public int CursorRow = 1;
    public int CursorSeat = 1;
    public double PriceA 
    { 
        get
        {
            return _priceA;
        } 
        set
        {
            _priceA = value > 8 ? value : 8;
        }
    }
    public double PriceB 
    { 
        get
        {
            return _priceB;
        } 
        set
        {
            _priceB = value > 5 ? value : 5;
        }
    }
    public double PriceC
    { 
        get
        {
            return _priceC;
        } 
        set
        {
            _priceC = value > 3 ? value : 3;
        }
    }

    public SeatMap(int auditoriumnumber) : this(auditoriumnumber, 25, 20, 15) 
    {
        AuditoriumNumber = auditoriumnumber;
        PriceA = 25;
        PriceB = 20;
        PriceC = 15;
        rows = GetRows(auditoriumnumber);
        Auditorium = GetAuditorium(auditoriumnumber);
        Auditoriums();
    }

    public SeatMap(int auditoriumnumber, double astoelen, double bstoelen, double cstoelen)
    {
        AuditoriumNumber = auditoriumnumber;
        PriceA = astoelen;
        PriceB = bstoelen;
        PriceC = cstoelen;
        rows = GetRows(auditoriumnumber);
        Auditorium = GetAuditorium(auditoriumnumber);
        Auditoriums();
    }
    // Dit is voor de Stored Json seatmap te Displayen.
    public SeatMap(int auditoriumnumber, List<List<String>>StoredMap)
    {
        AuditoriumNumber = auditoriumnumber;
        PriceA = 25;
        PriceB = 20;
        PriceC = 15;
        rows = GetRows(auditoriumnumber);
        Auditorium = StoredMap;
        Auditoriums();
    }

    // Dit is voor de Stored Json seatmap te Displayen. en Prijzen changen.
    public SeatMap(int auditoriumnumber, List<List<string>>StoredMap , double astoelen, double bstoelen, double cstoelen)
    {
        AuditoriumNumber = auditoriumnumber;
        PriceA = astoelen;
        PriceB = bstoelen;
        PriceC = cstoelen;
        rows = GetRows(auditoriumnumber);
        Auditorium = StoredMap;
        Auditoriums();
    }

    private List<List<string>> GetAuditorium(int auditoriumNumber) 
    {
        switch (auditoriumNumber) 
        {
            case 1:
                return auditorium1;
            case 2:
                return auditorium2;
            case 3:
                return auditorium3;
            default:
                throw new ArgumentOutOfRangeException("Invalid auditorium number");
        }
    }

    private List<string> GetRows(int auditoriumNumber) 
    {
        switch (auditoriumNumber) 
        {
            case 1:
                return rows1;
            case 2:
                return rows2;
            case 3:
                return rows3;
            default:
                throw new ArgumentOutOfRangeException("Invalid auditorium number");
        }
    }

    public void ChangePrices(double stoel_a, double stoel_b, double stoel_c)
    {
        PriceA = stoel_a;
        PriceB = stoel_b;
        PriceC = stoel_c;
    }

    public void ReserveSeats()
    {
        Reservation newReservation = new();
    }

    // 3 auditoriums hardcoded en cursor logic
    public void Auditoriums()
    {
        // laat de hele auditorium zien
        DisplayAll();

        // cursor om te navigeren
        ConsoleKeyInfo key;
        Console.CursorVisible = true;
        do
        {
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (CursorRow > 1)
                    {
                        CursorRow--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CursorRow < Auditorium.Count - 1)
                    {
                        CursorRow++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (CursorSeat > 1)
                    {
                        CursorSeat--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (CursorSeat < Auditorium[CursorRow].Count - 1)
                    {
                        CursorSeat++;
                    }
                    break;
                // de geselecteerde stoel of stoelen reserveren
                case ConsoleKey.Enter:
                    Message = $"Weet je zeker dat je de volgende stoel of stoelen wilt reserveren?\nDruk op [enter] om verder te gaan\nDruk op [backspace] om terug te gaan";	
                    if (key.Key == ConsoleKey.Enter)
                    {
                        // SnacksMenu snack = new SnacksMenu();
                        // snack.Start();
                        // ReservationPresentation.AddReservation();
                        bool Loop1 = true;
                        bool Loop2 = true;
                        if( !SeatmapLogic.CheckCurrentUser())
                        {
                            while (Loop1)
                            {
                                Console.WriteLine("You are not logged in. Do you have a account? (yes or no)");
                                string HaveAcc = Helpers.Color("yellow").ToLower();
                                if (HaveAcc == "no")
                                {
                                    while (Loop2)
                                        {
                                        Console.WriteLine("Do you wish to make a new account to finish your reservation? (yes or no)");
                                        string MakeAcc = Helpers.Color("yellow").ToLower();
                                        if (MakeAcc == "yes")
                                        {
                                            // dit slaat de zaal op in json
                                            MovieSchedule.SaveAuditorium(Auditorium);
                                            UserRegistration.RegisterUser();
                                            break;
                                        }
                                        if (MakeAcc == "no")
                                        {
                                        Helpers.PrintStringToColor("You can't finish your reservation without making account\nYou will be redirected to the main page","Red");
                                        Thread.Sleep(1000);
                                        Menu.Start();
                                        Loop2 = false;
                                        Loop1 = false;
                                        Environment.Exit(0);
                                        }
                                        break;
                                        }

                                }
                                else if (HaveAcc == "yes")
                                {
                                    //  hierzo de code als je acc hebt dan alleen email password and then check in accountlogic als dat bestaat
                                    // Accountmodel.Checklogin(email, password)
                                    Loop1 = false;
                                    // this code under this saves the auditorium to its schedule
                                    MovieSchedule.SaveAuditorium(Auditorium);
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Helpers.PrintStringToColor("Incorrect input", "red");
                                }
                            }
                        break;
                        }
                        else
                        {
                            // dit slaat de zaal op in json als iemand klaar is met bestellen
                            MovieSchedule.SaveAuditorium(Auditorium);
                            Console.WriteLine("You are logged in");
                            Environment.Exit(0);
                            // Djilanie hier code voor als user is ingelogd. Dus geen inputs maar read from accountmodel user dan
                        }
                        break;
                    }
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        break;
                    }
                    break;
                // een stoel annuleren
                case ConsoleKey.Backspace:
                    if (yourseats.Contains(new Tuple<int, int>(CursorRow, CursorSeat)))
                    {
                        if (Auditorium[CursorRow][CursorSeat] == "AR")
                        {
                            yourseats.Remove(new Tuple<int, int>(CursorRow, CursorSeat));
                            Auditorium[CursorRow][CursorSeat] = "A";
                            Message = $"Seat {CursorSeat} in row {rows[CursorRow - 1].Replace(" ", "")} is canceled";
                            break;
                        }
                        if (Auditorium[CursorRow][CursorSeat] == "BR")
                        {
                            yourseats.Remove(new Tuple<int, int>(CursorRow, CursorSeat));
                            Auditorium[CursorRow][CursorSeat] = "B";
                            Message = $"Seat {CursorSeat} in row {rows[CursorRow - 1].Replace(" ", "")} is canceled";
                            break;
                        }
                        if (Auditorium[CursorRow][CursorSeat] == "CR")
                        {
                            yourseats.Remove(new Tuple<int, int>(CursorRow, CursorSeat));
                            Auditorium[CursorRow][CursorSeat] = "C";
                            Message = $"Seat {CursorSeat} in row {rows[CursorRow - 1].Replace(" ", "")} is canceled";
                            break;
                        }
                    }
                    else
                    {
                        Message = $"You cannot cancel a seat that you have not reserved";
                    }
                    break;
                // een stoel selecteren
                case ConsoleKey.Spacebar:
                    // Hierzo moet zijn een extra functie op de gebruiker die in dit gaat om jouw geselecteerde stoel op te slaan in een private field B.V
                    // Dus user 1 reserveert en kan alleen stoelen annuleren van hem
                    // als A, B of C is reserveer stoel en verander positie in list naar R
                    if (Auditorium[CursorRow][CursorSeat] == "A")
                    {
                        yourseats.Add(new Tuple<int, int>(CursorRow, CursorSeat));
                        Auditorium[CursorRow][CursorSeat] = "AR";
                        Message = $"Seat {CursorSeat} in row {rows[CursorRow - 1].Replace(" ", "")} is selected. Thank you for your reservation";
                        break;
                    }
                    if (Auditorium[CursorRow][CursorSeat] == "B")
                    {
                        yourseats.Add(new Tuple<int, int>(CursorRow, CursorSeat));
                        Auditorium[CursorRow][CursorSeat] = "BR";
                        Message = $"Seat {CursorSeat} in row {rows[CursorRow - 1].Replace(" ", "")} is selected. Thank you for your reservation";
                        break;
                    }
                    if (Auditorium[CursorRow][CursorSeat] == "C")
                    {
                        yourseats.Add(new Tuple<int, int>(CursorRow, CursorSeat));
                        Auditorium[CursorRow][CursorSeat] = "CR";
                        Message = $"Seat {CursorSeat} in row {rows[CursorRow - 1].Replace(" ", "")} is selected. Thank you for your reservation/nThis seat costs {PriceC}";
                        break;
                    }
                    // als X is print dat het geen stoel is en doet niks 
                    else if (Auditorium[CursorRow][CursorSeat] == "X")
                    {
                        Message = $"This is not a seat";
                    }
                    // als R is dan is het al gereserveerd en print dit, doet niks verder
                    else if (Auditorium[CursorRow][CursorSeat] == "AR" || Auditorium[CursorRow][CursorSeat] == "BR" || Auditorium[CursorRow][CursorSeat] == "CR")
                    {
                        Message = $"This is a reserved seat";
                    }
                    break;
                case ConsoleKey.Escape:
                    Menu.Start();
                    Environment.Exit(0);
                    break;

            }
            // laat de hele auditorium zien
            DisplayAll();
        // escape button om uit loop te gaan
        } while (true);
        // escape en je gaat terug naar menu.cs scherm
    }

    // print alles
    private void DisplayAll()
    {
        Console.Clear();
        DisplayTitle();
        DisplayAuditorium();
        DisplayScreen();
        DisplayCursorPosition();
        DisplayMessage();
        //DisplayReservedSeats();
        DisplayLegenda();
        DisplayOptions();
    }

    // auditorium printen
    private void DisplayAuditorium()
    {   
        Console.OutputEncoding = Encoding.UTF8;
        // auditorium printen loops
        for (int row = 0; row < Auditorium.Count; row++)
        {
            for (int seat = 0; seat < Auditorium[row].Count; seat++)
            {
                // als positie row en seat gelijk zijn aan cursorrow en cursorseat dan print symbool met kleur
                if (row == CursorRow && seat == CursorSeat)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" ∎ ");
                }
                // print wat in auditorium staat met kleur en symbool
                else
                {
                    switch (Auditorium[row][seat])
                    {
                        case "X":
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("   ");
                            break;
                        case "A":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" ❑ ");
                            break;
                        case "B":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" ❑ ");
                            break;
                        case "C":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(" ❑ ");
                            break;
                        case "AR":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" ▣ ");
                            break;
                        case "BR":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" ▣ ");
                            break;
                        case "CR":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" ▣ ");
                            break;

                        // print rij nummer en stoel nummer
                        case "1":
                            if (seat > 9)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write($"{seat} ");
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write($"{seat}  ");
                                break;
                            }
                        case "2":
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($"{rows[row - 1]} ");
                            break;
            
                        case "3":
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"    ");
                            break;
                    }
                }
                // reset kleur van symbool
                Console.ResetColor();
                }
            // nieuwe rij printen
            Console.WriteLine();
        }
    }

    // titel printen
    private void DisplayTitle()
    {
        if (AuditoriumNumber == 1)
        {
            Console.WriteLine("         Auditorium 1:");
        }
        if (AuditoriumNumber == 2)
        {
            Console.WriteLine("\t       Auditorium 2:");
        }
        if (AuditoriumNumber == 3)
        {
            Console.WriteLine("\t\t\t   Auditorium 3:");
        }
    }

    // scherm printen
    private void DisplayScreen()
    {
        if (AuditoriumNumber == 1)
        {
            Console.WriteLine();
            Console.WriteLine("                  Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (AuditoriumNumber == 2)
        {
            Console.WriteLine();
            Console.WriteLine("                  Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (AuditoriumNumber == 3)
        {
            Console.WriteLine();
            Console.WriteLine("                                      Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
    }

    // legenda printen
    private void DisplayLegenda()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❏ = {PriceA} euro");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"❏ = {PriceB} euro");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"❏ = {PriceC} euro");
        Console.ResetColor();
    }

    // cursor positie printen
    private void DisplayCursorPosition()
    {
        Console.Write("Row: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{rows[CursorRow - 1].Replace(" ", "")}]");
        Console.ResetColor();
        Console.Write(" Seat: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"[{CursorSeat}]\n\n");
        Console.ResetColor();
    }

    // message printen
    private void DisplayMessage()
    {
        Console.WriteLine(Message);
    }

    // description printen
    private void DisplayOptions()
    {
        Console.WriteLine();
        Console.WriteLine($"Use arrow keys to navigate.");
        Console.WriteLine($"Press [space] to reserve a seat.");
        Console.WriteLine($"Press [backspace] to cancel the seat.");
        Console.WriteLine($"Press [enter] to confirm your reservation.");
        Console.WriteLine($"Press [escape] to return to main menu.");
    }

    public List<Tuple<int, int>> GetYourSeat()
    {
        return yourseats;
    }

    private void DisplayReservedSeats()
    {
        foreach (List<string> row in Auditorium)
        {
            foreach (string seat in row)
            {
                if (Auditorium[CursorRow][CursorSeat] == "AR" || Auditorium[CursorRow][CursorSeat] == "BR" || Auditorium[CursorRow][CursorSeat] == "CR")
                {

                }
            }
        }
    }

    private bool IsReserved(string seat)
    {
        if (Auditorium[CursorRow][CursorSeat] == "AR" || Auditorium[CursorRow][CursorSeat] == "BR" || Auditorium[CursorRow][CursorSeat] == "CR")
        {
            Message = $"Stoel in rij {CursorRow} met nummer {rows[CursorSeat - 1]} is geannuleerd";
            return true;
        }
        else
        {
            return false;
        }
    }
}