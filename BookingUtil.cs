using System;
using System.IO;
using pa5_Sessions;

namespace pa5_Booking
{
    public class BookingUtil
    {
        private BookingInfo[] myBookings;
        private SessionInfo[] mySessions;
        
        public BookingUtil(BookingInfo[] myBookings, SessionInfo[] mySessions){
            this.myBookings = myBookings;
        }

        // LIST ALL SESSIONS LOCATED IN SESSIONS UTIL

        public void GetAllTransact(){
            BookingInfo.SetTransactCount(0);
            StreamReader inFile = new StreamReader("transactions.txt"); //open the file
            string line = inFile.ReadLine();

            while(line != null){
                string[] temp = line.Split("#");
                myBookings[BookingInfo.GetTransactCount()] = new BookingInfo(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], bool.Parse(temp[6]));

                BookingInfo.IncTransactCount();
                line = inFile.ReadLine(); //update read
            }
            inFile.Close(); //close the file
        }

        public void SaveBookingInfo(){
            StreamWriter outFile = new StreamWriter("transactions.txt");
            for(int i = 0; i < BookingInfo.GetTransactCount(); i++){
                outFile.WriteLine(myBookings[i].ToTransactFile());
            }
            outFile.Close();
        }

        // public void ListAvailableSessions(SessionInfo[] mySessions){
        //     System.Console.WriteLine(SessionInfo.GetSessionCount());
        //     System.Console.WriteLine(mySessions[0].GetSessionTaken());
        //     for(int i = 0; i < SessionInfo.GetSessionCount(); i++){
        //         if(mySessions[i].GetSessionTaken() != true){
        //             System.Console.WriteLine(mySessions[i].ToSessionString());
        //         }
        //     }
        // }

        public void AddBooking(){
            BookingInfo newBooking = new BookingInfo();
            //bookingID, custName, custEmail, sessionDate, trainerID, trainerName, sessionTaken

            System.Console.WriteLine();
            System.Console.WriteLine("Booking ID will be automatically generated.");
            int generatedBookingID = BookingInfo.GetTransactCount() + 1;
            newBooking.SetBookingID(generatedBookingID);

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the customer's name:");
            newBooking.SetCustName(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the customer's email:");
            newBooking.SetCustEmail(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the session date, in YYYY/MM/DD format.");
            newBooking.SetSessionDate(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the trainer's ID:");
            newBooking.SetTrainerID(int.Parse(Console.ReadLine()));

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the trainer's name:");
            newBooking.SetTrainerName(Console.ReadLine());

            newBooking.SetBookingTaken(true);

            myBookings[BookingInfo.GetTransactCount()] = newBooking;
            BookingInfo.IncTransactCount();

            SaveBookingInfo();
        }

        public void EditBooking(){
            // SessionInfo[] mySessions = new SessionInfo[100];
            //BookingInfo[] bookEdit = new BookingInfo[100];

            //searchValueSession;
            System.Console.WriteLine("Please enter the session ID of the session you would like to edit.");
            int searchValueBooking = int.Parse(Console.ReadLine());

            int indexBooking = SearchByBooking(myBookings, ref searchValueBooking);
            if(indexBooking < 0){
                System.Console.WriteLine("Session ID was not found.");
                return;
            }

            //display selected trainer's current info
            //sessionID, custName, custEmail, sessionDate, trainerID, trainerName, sessionTaken
            //string temp = myBookings[indexSession];
            System.Console.WriteLine("Booking ID cannot be edited.");
            System.Console.WriteLine("Current customer name: " + myBookings[indexBooking].GetCustName());
            System.Console.WriteLine("Current customer email: " + myBookings[indexBooking].GetCustEmail());
            System.Console.WriteLine("Current session date: " + myBookings[indexBooking].GetSessionDate());
            System.Console.WriteLine("Current trainer ID: " + myBookings[indexBooking].GetTrainerID());
            System.Console.WriteLine("Current trainer name: " + myBookings[indexBooking].GetTrainerName());
            System.Console.WriteLine("Is this booking taken: " + myBookings[indexBooking].GetBookingTaken());

            //make changes to certain parts of the trainer's info and stores them in a new variable
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the customer's new name: (press 'enter' to make no change.)");
            string newCName = Console.ReadLine();
            //myBookings.SetCustName(Console.ReadLine());
            
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the customer's new email: (press 'enter' to make no change.)");
            string newCustEmail = Console.ReadLine();
            //myBookings.SetCustEmail(Console.ReadLine());

            
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the new session date: (press 'enter' to make no change.)");
            string newSessionDate = Console.ReadLine();
            //myBookings.SetSessionDate(Console.ReadLine());
            
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the new trainer ID: (press 'enter' to make no change.)");
            string newTrainerID = Console.ReadLine();
            //myBookings.SetTrainerID(int.Parse(Console.ReadLine()));

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the new trainer name: (press 'enter' to make no change.)");
            string newTrainerName = Console.ReadLine();
            ///myBookings.SetTrainerName(Console.ReadLine());
            
            System.Console.WriteLine();
            System.Console.WriteLine("Do you want to set this session to 'Taken'? Please enter 'y' for yes, and 'n' for no.");
            string setTakenYN = Console.ReadLine();
            //myBookings.SetBookingTaken(Console.ReadLine());

            //edits trainer info using new variables
            if(newCName != null && newCName != ""){
                myBookings[indexBooking].SetCustName(newCName);
                SaveBookingInfo();
            }
            if(newCustEmail != null && newCustEmail != ""){
                myBookings[indexBooking].SetCustEmail(newCustEmail);
                SaveBookingInfo();
            }
            if(newSessionDate != null && newSessionDate != ""){
                myBookings[indexBooking].SetSessionDate(newSessionDate);
                SaveBookingInfo();
            }
            if(newTrainerID != null && newTrainerID != ""){
                myBookings[indexBooking].SetTrainerID(int.Parse(newTrainerID));
                SaveBookingInfo();
            }
            if(newTrainerName != null && newTrainerName != ""){
                myBookings[indexBooking].SetTrainerName(newTrainerName);
                SaveBookingInfo();
            }
            if(setTakenYN == "y"){
                myBookings[indexBooking].SetBookingTaken(true);
                SaveBookingInfo();
            }
            else{
                return;
            }

            //stores info 
            SaveBookingInfo();
        }

        public int SearchByBooking(BookingInfo[] myBookings, ref int searchValueBooking){

            int foundIndexBooking = -1;
            int firstBooking = 0;
            int lastBooking = BookingInfo.GetTransactCount() - 1;

            while(foundIndexBooking == -1 && lastBooking >= firstBooking){
                int middleBooking = ((firstBooking + lastBooking) / 2);
                if(searchValueBooking == myBookings[middleBooking].GetBookingID()){
                    foundIndexBooking = middleBooking;
                }
                else if(0 > myBookings[middleBooking].GetBookingID().CompareTo(searchValueBooking)){
                    firstBooking = middleBooking + 1;
                }
                else{
                    lastBooking = middleBooking - 1;
                }
            }
            return foundIndexBooking;
        }

        public void BookingMainMenu(){
            BookingMenuText();
            SessionInfo[] mySessions = new SessionInfo[100];
            SessionUtil sessionUtil = new SessionUtil(mySessions);
            mySessions = sessionUtil.GetAllSessions(mySessions);

            string BookingMenuSelect = Console.ReadLine();
            while(BookingMenuSelect != "4"){
                
                if(BookingMenuSelect == "1"){
                    SessionUtil sessionUtil1 = new SessionUtil(mySessions);
                    sessionUtil1.ListAvailableSessions(mySessions);
                }
                if(BookingMenuSelect == "2"){
                    AddBooking();
                }
                if(BookingMenuSelect == "3"){
                    EditBooking();
                }
                if(BookingMenuSelect == "4"){
                    System.Console.WriteLine("ADD MAIN MENU");
                }
                else{
                    System.Console.WriteLine("Please make a valid selection from the options above.");
                }
                BookingMenuText();
                BookingMenuSelect = Console.ReadLine();
            }
        }

        public void BookingMenuText(){
            Console.Clear();
            System.Console.WriteLine("| Welcome to the Bookings Menu. Please Select an option below. |");
            System.Console.WriteLine("Enter '1' to view all available sessions.");
            System.Console.WriteLine("Enter '2' to add a new booking.");
            System.Console.WriteLine("Enter '3' to edit or delete a current booking.");
            System.Console.WriteLine("Enter '4' to return to the previous menu.");
        }
    }
}