﻿using System.Text;

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
        new List<string> { "3", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1"},
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

    public List<string> rows = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "BB", "CC", "DD"};
    private double Astoelen;
    private double Bstoelen;
    private double Cstoelen;
    public string Message = "";
    public int AuditoriumNumber;
    public int CursorRow = 1;
    public int CursorSeat = 1;
    public List<List<string>> Auditorium = new();
    public double ASTOEL 
    { 
        get
        {
            return Astoelen;
        } 
        set
        {
            Astoelen = value > 8 ? value : 8;
        }
    }
    public double BSTOEL 
    { 
        get
        {
            return Bstoelen;
        } 
        set
        {
            Bstoelen = value > 5 ? value : 5;
        }
    }
    public double CSTOEL 
    { 
        get
        {
            return Cstoelen;
        } 
        set
        {
            Cstoelen = value > 3 ? value : 3;
        }
    }

    public SeatMap(int auditoriumnumber)
    {
        ASTOEL = 25;
        BSTOEL = 20;
        CSTOEL = 15;
        AuditoriumNumber = auditoriumnumber;
        if (AuditoriumNumber == 1)
        {
            Auditorium = auditorium1;
        }
        if (AuditoriumNumber == 2)
        {
            Auditorium = auditorium2;
        }
        if (AuditoriumNumber == 3)
        {
            Auditorium = auditorium3;
        }
        Auditoriums();
    }

    public void ChangePrices(double stoel_a, double stoel_b, double stoel_c)
    {
        ASTOEL = stoel_a;
        BSTOEL = stoel_b;
        CSTOEL = stoel_c;
    }

    // 3 auditoriums hardcoded en cursor logic
    public void Auditoriums()
    {
        // auditorium kiezen, maakt een kopie van de auditorium 1 tot en met 3 en zet in Auditorium
        //List<List<string>> Auditorium = new();
        

        // cursor positie voor rij en stoel
        //int CursorRow = 0;
        //int CursorSeat = 0;

        // message wordt altijd geprint, maar is default op leeg en print normaal niks totdat je op enter klikt
        //string message = "";

        // laat de auditorium eerst zien samen met titel, scherm, legenda en cursor
        /* ben van plan om een DisplayAll() te maken om alles aan te roepen, zodat minder code hoeft te worden uitgevoerd
        DisplayTitle(AuditoriumNumber);
        DisplayAuditorium(Auditorium, CursorRow, CursorSeat);
        DisplayScreen(AuditoriumNumber);
        DisplayCursorPosition(CursorRow, CursorSeat);
        DisplayLegenda();
        */

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
                // stoel annuleren
                case ConsoleKey.Backspace:
                    if (Auditorium[CursorRow][CursorSeat] == "AR")
                    {
                        Auditorium[CursorRow][CursorSeat] = "A";
                        Message = $"Stoel in rij {CursorRow} met nummer {rows[CursorSeat - 1]} is geannuleerd";
                        break;
                    }
                    if (Auditorium[CursorRow][CursorSeat] == "BR")
                    {
                        Auditorium[CursorRow][CursorSeat] = "B";
                        Message = $"Stoel in rij {CursorRow} met nummer {rows[CursorSeat - 1]} is geannuleerd";
                        break;
                    }
                    if (Auditorium[CursorRow][CursorSeat] == "CR")
                    {
                        Auditorium[CursorRow][CursorSeat] = "C";
                        Message = $"Stoel in rij {CursorRow} met nummer {rows[CursorSeat - 1]} is geannuleerd";
                        break;

                    }
                    else
                    {
                        Message = $"Je kan deze stoel niet annuleren";
                    }
                    break;
                // Reserveer een stoel in de auditorium
                case ConsoleKey.Enter:
                    // als A, B of C is reserveer stoel en verander positie in list naar R
                    if (Auditorium[CursorRow][CursorSeat] == "A")
                    {
                        Auditorium[CursorRow][CursorSeat] = "AR";
                        Message = $"Stoel in rij {CursorRow} met nummer {rows[CursorSeat - 1]} is gereserveerd, Dank u wel voor het reserveren";
                        break;
                    }
                    if (Auditorium[CursorRow][CursorSeat] == "B")
                    {
                        Auditorium[CursorRow][CursorSeat] = "BR";
                        Message = $"Stoel in rij {CursorRow} met nummer {rows[CursorSeat - 1]} is gereserveerd, Dank u wel voor het reserveren";
                        break;
                    }
                    if (Auditorium[CursorRow][CursorSeat] == "C")
                    {
                        Auditorium[CursorRow][CursorSeat] = "CR";
                        Message = $"Stoel in rij {CursorRow} met nummer {rows[CursorSeat - 1]} is gereserveerd, Dank u wel voor het reserveren";
                        break;
                    }
                    // als X is print dat het geen stoel is en doet niks 
                    else if (Auditorium[CursorRow][CursorSeat] == "X")
                    {
                        Message = $"Dit is geen stoel";
                    }
                    // als R is dan is het al gereserveerd en print dit, doet niks verder
                    else if (Auditorium[CursorRow][CursorSeat] == "AR" || Auditorium[CursorRow][CursorSeat] == "BR" || Auditorium[CursorRow][CursorSeat] == "CR")
                    {
                        Message = $"Dit is een gereserveerde stoel, kies een andere stoel";
                    }
                    break;
            }
            // laat de hele auditorium zien
            DisplayAll();
            
            /* clear het scherm en laat auditorium weer zien samen met titel, scherm, legenda en cursor
            Console.Clear();
            DisplayTitle(AuditoriumNumber);
            DisplayAuditorium(Auditorium, CursorRow, CursorSeat);
            DisplayScreen(AuditoriumNumber);
            DisplayCursorPosition(CursorRow, CursorSeat);
            Console.WriteLine(message);
            DisplayLegenda();*/

        // escape button om uit loop te gaan
        } while (key.Key != ConsoleKey.Escape);
        // escape en je gaat terug naar menu.cs scherm
        Menu.Start();
    }

    // print alles
    public void DisplayAll()
    {
        Console.Clear();
        DisplayTitle();
        DisplayAuditorium();
        DisplayScreen();
        DisplayCursorPosition();
        DisplayMessage();
        DisplayLegenda();
        DisplayOptions();
    }

    // auditorium printen
    public void DisplayAuditorium()
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
    public void DisplayTitle()
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
    public void DisplayScreen()
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
    public void DisplayLegenda()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❏ = {Astoelen} euro");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"❏ = {Bstoelen} euro");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"❏ = {Cstoelen} euro");
        Console.ResetColor();
    }

    // cursor positie printen
    public void DisplayCursorPosition()
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
    public void DisplayMessage()
    {
        Console.WriteLine(Message);
    }

    // description printen
    public void DisplayDescription()
    {
        Console.WriteLine($"\nUse arrow keys to move the cursor.\nPress [enter] to select a seat. Press [backspace] to cancel the seat.\nPress [escape] to return to main menu.");
    }

    // description printen
    public void DisplayOptions()
    {
        Console.WriteLine($"\nUse arrow keys to move the cursor.\nPress [enter] to select a seat. Press [backspace] to cancel the seat.\nPress [escape] to return to main menu.");
    }
}