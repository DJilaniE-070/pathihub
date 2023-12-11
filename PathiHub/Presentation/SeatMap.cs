using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class SeatMap
{    
    // lijst om reservaties op te slaan
    //public static List<List<string>> ReservedSeats = new List<List<string>>();
    //public static List<ReservedSeats> ReserveSeat = new List<ReservedSeats>();

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
    // rows lijst voor de auditorium, vertaling van 1
    private List<string> rows = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "BB", "CC", "DD"};
    // auditorium opslaan in lijst
    private List<List<string>> Auditorium = new();
    // lijst van reservaties
    private List<ReservedSeats> Reservations = new List<ReservedSeats>();
    // belangrijke informaties
    private Dictionary<string, double> SeatPrices;
    //private SeatMapInfo Info = new SeatMapInfo();
    // stoel prijzen backing field
    private double _priceA;
    private double _priceB;
    private double _priceC;
    // voor nu handigheidje om een message te veranderen heletijd en te printen voor de cursor
    public string Message = "";
    // auditorium zaal nummer
    private int AuditoriumNumber;
    // cursor positie
    private int CursorRow = 1;
    private int CursorSeat = 1;
    // totale prijzen
    public double TotalPrice = 0;
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
    private string FilePath = @"C:\Users\31685\Documents\GitHub\pathihub\PathiHub\DataSources\reservedseats.json";
    public List<Tuple<int, int>> ListTupleSeats = new List<Tuple<int, int>>();
    public static int TotalReservations;
    public static double TotalRevenue;

    // 2 constructor voor overloading
    public SeatMap(int auditoriumnumber)
    {
        AuditoriumNumber = auditoriumnumber;     
        LoadPricesFromJson();
        
        Auditorium = GetAuditorium(auditoriumnumber);
        Auditoriums();
    }

    public SeatMap(int auditoriumnumber, double astoelen, double bstoelen, double cstoelen)
    {
        AuditoriumNumber = auditoriumnumber;
        PriceA = astoelen;
        PriceB = bstoelen;
        PriceC = cstoelen;
        Auditorium = GetAuditorium(auditoriumnumber);
        Auditoriums();
    }

    // andere manier om programma te runnen
    public void Start(int auditoriumnumber)
    {
        AuditoriumNumber = auditoriumnumber;
        PriceA = 25;
        PriceB = 20;
        PriceC = 15;
        SavePrices();
        Auditorium = GetAuditorium(auditoriumnumber);
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

    public void ChangePrices(double stoel_a, double stoel_b, double stoel_c)
    {
        PriceA = stoel_a;
        PriceB = stoel_b;
        PriceC = stoel_c;
    }

    public void SavePrices()
    {
        SeatPrices = new Dictionary<string, double>
        {
            { "PriceA", PriceA },
            { "PriceB", PriceB },
            { "PriceC", PriceC }
        };
        SavePricesToJson();
    }

    public void CalculateTotalPrice(double prices)
    {
        TotalPrice += prices;
    }

    public string ShowTotalPrice()
    {
        return TotalPrice.ToString();
    }

    public string ShowTotalRevenue()
    {
        return TotalRevenue.ToString();
    }

    public string ShowTotalReservations()
    {
        return TotalReservations.ToString();
    }
    
    // werkt nog niet
    public void ReserveSeats()
    {
        Reservation newReservation = new();
    }

    // 3 auditoriums hardcoded en cursor logic
    public void Auditoriums()
    {   
        bool exit = false;
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
                // escape om terug naar main menu
                case ConsoleKey.Enter:
                    RunReservationMenu();
                    break;
                // een stoel annuleren
                case ConsoleKey.Backspace:
                    switch (Auditorium[CursorRow][CursorSeat])
                    {
                        case "AR":
                            Auditorium[CursorRow][CursorSeat] = "A";
                            Message = $"Seat {rows[CursorSeat - 1]} in row {CursorRow} is canceled";
                            break;
                        case "BR":
                            Auditorium[CursorRow][CursorSeat] = "B";
                            Message = $"Seat {rows[CursorSeat - 1]} in row {CursorRow} is canceled";
                            break;
                        case "CR":
                            Auditorium[CursorRow][CursorSeat] = "C";
                            Message = $"Seat {rows[CursorSeat - 1]} in row {CursorRow} is canceled";
                            break;
                        default:
                            Message = $"You cannot cancel this seat";
                            break;
                    }
                    break;
                // een stoel selecteren
                case ConsoleKey.Spacebar:
                    // als A, B of C is reserveer stoel en verander positie in list naar R
                    if (Auditorium[CursorRow][CursorSeat] == "A")
                    {
                        Auditorium[CursorRow][CursorSeat] = "AR";
                        Message = $"Seat {rows[CursorSeat - 1]} in row {CursorRow} is selected. Thank you";
                        break;
                    }
                    if (Auditorium[CursorRow][CursorSeat] == "B")
                    {
                        Auditorium[CursorRow][CursorSeat] = "BR";
                        Message = $"Seat {rows[CursorSeat - 1]} in row {CursorRow} is selected. Thank you";
                        break;
                    }
                    if (Auditorium[CursorRow][CursorSeat] == "C")
                    {
                        Auditorium[CursorRow][CursorSeat] = "CR";
                        Message = $"Seat {rows[CursorSeat - 1]} in row {CursorRow} is selected. Thank you";
                        break;
                    }
                    // als X is print dat het geen stoel is en doet niks 
                    else if (Auditorium[CursorRow][CursorSeat] == "X")
                    {
                        Message = $"This is not a valid seat";
                    }
                    // als R is dan is het al gereserveerd en print dit, doet niks verder
                    else if (Auditorium[CursorRow][CursorSeat] == "AR" || Auditorium[CursorRow][CursorSeat] == "BR" || Auditorium[CursorRow][CursorSeat] == "CR")
                    {
                        Message = $"This is a reserved seat";
                    }
                    break;
            }
            // laat de hele auditorium zien
            DisplayAll();
        // escape button om uit loop te gaan
        } while (key.Key != ConsoleKey.Escape);
        Menu.Start();
        //RunReservation();

        //List<Tuple<int, int>> ListTupleSeats = GetReservedSeats();
                    //DisplayReservedSeats(ListTupleSeats);


                    //exit = true;
                    /*
                    foreach (List<string> row in Auditorium)
                    {
                        foreach (string seat in row)
                        {
                            if (seat == "AR" || seat == "BR" || seat == "CR")
                            {

                            }
                        }
                    }
                    Reservations.Add(new ReservedSeats(rows[CursorRow], CursorSeat, AuditoriumNumber));
                    */
    }

    // mini menu als enter is geklikt voor reserveren 
    private void RunReservationMenu()
    {
        Console.Clear();
        ListTupleSeats = GetReservedSeats();
        DisplayReservedSeats(ListTupleSeats);

        ConsoleKeyInfo key;
        key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.Backspace:
                Auditoriums();
                break;

            case ConsoleKey.Escape:
                Menu.Start();
                break;

            case ConsoleKey.Enter:
                ReservingSeats();
                break;
        }
    }

    public void ReservingSeats()
    {
        foreach (var seat in ListTupleSeats)
        {
            if (Auditorium[seat.Item1][seat.Item2] == "AR")
            {
                TotalPrice += PriceA;
                TotalRevenue += PriceA;
            }
            if (Auditorium[seat.Item1][seat.Item2] == "BR")
            {
                TotalPrice += PriceB;
                TotalRevenue += PriceB;
            }
            if (Auditorium[seat.Item1][seat.Item2] == "CR")
            {
                TotalPrice += PriceC;
                TotalRevenue += PriceC;
            }
            TotalReservations++;
            Reservations.Add(new ReservedSeats(seat.Item1, rows[seat.Item2 - 1], AuditoriumNumber));
        }
        SaveReservedSeatsToJson();
    }

    // slaat reservations op in json
    private void SaveReservedSeatsToJson()
    {
        List<ReservedSeats> ExistingReservedSeats = new List<ReservedSeats>();

        // kijkt of de json bestaat
        if (File.Exists(FilePath))
        {
            // leest de json bestand
            string ExistingJson = File.ReadAllText(FilePath);
            ExistingReservedSeats = JsonConvert.DeserializeObject<List<ReservedSeats>>(ExistingJson);
        }
        ExistingReservedSeats.AddRange(Reservations);

        string UpdatedJson = JsonConvert.SerializeObject(ExistingReservedSeats, Formatting.Indented);
        File.WriteAllText(FilePath, UpdatedJson);

        Console.WriteLine("Reservations saved to: " + FilePath);
    }

    public void SavePricesToJson()
    {
        string FolderPath = @"C:\Users\31685\Documents\GitHub\pathihub\PathiHub\DataSources\seatprices.json";

        string json = JsonConvert.SerializeObject(SeatPrices, Formatting.Indented);
        File.WriteAllText(FolderPath, json);

        Console.WriteLine("Seat prices saved to: " + FolderPath);
    }

    private void LoadPricesFromJson()
    {
        string FolderPath = @"C:\Users\31685\Documents\GitHub\pathihub\PathiHub\DataSources\seatprices.json";

        if (File.Exists(FolderPath))
        {
            string json = File.ReadAllText(FolderPath);
            SeatPrices = JsonConvert.DeserializeObject<Dictionary<string, double>>(json);
            Console.WriteLine("Seat prices loaded from: " + FolderPath);
        }
        else
        {
            Console.WriteLine("No seat prices file found. Using default prices.");
        }
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
                    Console.Write("∎ ");
                }
                // print wat in auditorium staat met kleur en symbool
                else
                {
                    switch (Auditorium[row][seat])
                    {
                        case "X":
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  ");
                            break;
                        case "A":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("❑ ");
                            break;
                        case "B":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("❑ ");
                            break;
                        case "C":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("❑ ");
                            break;
                        case "AR":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("▣ ");
                            break;
                        case "BR":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("▣ ");
                            break;
                        case "CR":
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("▣ ");
                            break;

                        // print rij nummer en stoel nummer
                        case "1":
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write($"{rows[seat - 1]} ");
                            break;
                        case "2":
                            if (row > 9)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write($"{row} ");
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write($"{row}  ");
                                break;
                            } 
                        case "3":
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"   ");
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
            Console.WriteLine("           Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (AuditoriumNumber == 2)
        {
            Console.WriteLine();
            Console.WriteLine("                 Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
        }
        if (AuditoriumNumber == 3)
        {
            Console.WriteLine();
            Console.WriteLine("                              Screen");
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
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
        Console.Write("Rij: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{CursorRow}]");
        Console.ResetColor();
        Console.Write(" Stoel: ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"[{rows[CursorSeat - 1]}]\n\n");
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

    private void DisplayReservedSeats(List<Tuple<int, int>> ListTupleSeats)
    {
        if (ListTupleSeats != null)
        {
            Console.WriteLine("You have selected the following seats:");
            foreach (var seat in ListTupleSeats)
            {
                Console.WriteLine($"Seat at Row {seat.Item1}, Seat {rows[seat.Item2 - 1]}");
            }
        }
        else
        {
            Console.WriteLine("There are no selected seats.");
            return;
        }
    }

    private List<Tuple<int, int>> GetReservedSeats()
    {
        List<Tuple<int, int>> ListTupleSeats = new List<Tuple<int, int>>();

        for (int row = 1; row < Auditorium.Count; row++)
        {
            for (int seat = 1; seat < Auditorium[row].Count; seat++)
            {
                if (Auditorium[row][seat] == "AR" || Auditorium[row][seat] == "BR" || Auditorium[row][seat] == "CR") 
                {
                    ListTupleSeats.Add(Tuple.Create(row, seat));
                }
            }
        }

        if (ListTupleSeats.Count > 0)
        {
            return ListTupleSeats;
        }
        else
        {
            return null;
        }
    }
}