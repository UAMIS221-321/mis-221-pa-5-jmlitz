using System;
using System.IO;
using pa5_Trainers;
using pa5_Sessions;
using pa5_Booking;
using pa5_Reports;

TrainerInfo[] myTrainers = new TrainerInfo[100];
TrainerUtil trainerUtil = new TrainerUtil(myTrainers);
trainerUtil.GetAllTrainers();

SessionInfo[] mySessions = new SessionInfo[100];
SessionUtil sessionUtil = new SessionUtil(mySessions);
sessionUtil.GetAllSessions(mySessions);
mySessions = sessionUtil.GetAllSessions(mySessions);
//sessionUtil.ListAvailableSessions(mySessions);


BookingInfo[] myBookings = new BookingInfo[100];
BookingUtil bookingUtil = new BookingUtil(myBookings, mySessions);
bookingUtil.GetAllTransact();

Reports[] myReports = new Reports[100];





Console.Clear();
MainMenu();

void MainMenu(){
    MainMenuText();
    string mainMenuSelect = Console.ReadLine();
    while(mainMenuSelect != "5"){
        if(mainMenuSelect == "1"){
            trainerUtil.TrainerMainMenu();
        }
        if(mainMenuSelect == "2"){
            sessionUtil.SessionMainMenu();
        }
        if(mainMenuSelect == "3"){
            bookingUtil.BookingMainMenu();
        }
        if(mainMenuSelect == "4"){
            System.Console.WriteLine("ADD REPORTS MENU");
        }
        if(mainMenuSelect == "5"){
            System.Console.WriteLine("Thank you for using the fitness program.");
        }
        else{
            System.Console.WriteLine("Please enter a valid selection from the options above.");
        }
        MainMenuText();
        mainMenuSelect = Console.ReadLine();
    }
}

static void MainMenuText(){
    System.Console.WriteLine();
    System.Console.WriteLine("|| Welcome to the fitness program! ||");
    System.Console.WriteLine("| Please select an option below. |");
    System.Console.WriteLine();
    System.Console.WriteLine("Enter '1' to access the trainer menu.");
    System.Console.WriteLine("Enter '2' to access the session menu.");
    System.Console.WriteLine("Enter '3' to access the booking menu.");
    System.Console.WriteLine("Enter '4' to access the reports menu.");
    System.Console.WriteLine("Enter '5' to exit the program.");
}

