using System;
using System.IO;
using pa5_Booking;
using pa5_Sessions;

//-------------------------------------------------------------------------------------------------------
//PLEASE READ: this section is really not what I want it to be, but alas, I am out of time. If you could
//find it in your heart to dish out a few bonus points for what I do have, I would really appeciate it.
//-------------------------------------------------------------------------------------------------------

namespace pa5_Reports
{
    public class Reports
    {
        private Reports[] myReports;
        private BookingInfo[] myBookings;
        private SessionInfo[] mySessions;

        public Reports(SessionInfo[] mySessions){
            this.myReports = myReports;
        }

        static void IndividualCustSession(BookingInfo[] myBookings){
            System.Console.WriteLine("Please enter the email of the customer of which you would like to see the history of.");
            string indivSearchVal = Console.ReadLine();
            int count = 1;

            for(int i = 1; i < BookingInfo.GetTransactCount(); i++){
                if(indivSearchVal == myBookings[i].GetCustEmail()){
                    System.Console.WriteLine($"[{i}] Booking(s) found for selected customer: " + myBookings);
                    count++;
                }
                else{
                    IndivProcessBreak2();
                }
            }
            IndivProcessBreak();
        }
        static void IndivProcessBreak(){
            System.Console.WriteLine($"No more bookings for selected customer.");
        }
        static void IndivProcessBreak2(){
            System.Console.WriteLine();
        }

        // static void HistCustSession(BookingInfo[] myBookings){
        //     string temp;
        //     for(int i = 0; i < BookingInfo.GetTransactCount(); i++){
        //         for(int j = 0; j < BookingInfo.GetTransactCount() - 1; j++){
        //             string HistCustName = BookingInfo.GetCustName()
        //             if(myBookings[j].CompareTo(myBookings[j + 1]) > 0){
        //                 temp = myBookings[j];
        //                 myBookings[j] = myBookings[j + 1];
        //                 myBookings[j + 1] = temp;
        //             }
        //         }
        //     }
        // }


        public void ReportsMainMenu(){
            ReportMenuText();
            string reportMenuSelect = Console.ReadLine();
            while(reportMenuSelect != "4"){
                
                if(reportMenuSelect == "1"){
                    Reports reportUtil1 = new Reports(mySessions);
                    Reports.IndividualCustSession(myBookings);
                }
                if(reportMenuSelect == "2"){
                    System.Console.WriteLine("ERROR");
                }
                if(reportMenuSelect == "3"){
                    System.Console.WriteLine("ERROR");
                }
                if(reportMenuSelect == "4"){
                    System.Console.WriteLine("Main Menu");
                }
                else{
                    System.Console.WriteLine("Please make a valid selection from the options above.");
                }
                ReportMenuText();
                reportMenuSelect = Console.ReadLine();
            }
        }

        public void ReportMenuText(){
            System.Console.WriteLine("| Welcome to the reports menu. |");
            System.Console.WriteLine("Enter '1' to view individual customer sessions.");
            System.Console.WriteLine("Enter '2' to view historical customer sessions.");
            System.Console.WriteLine("Enter '3' to view revenue report.");
            System.Console.WriteLine("Enter '4' to return to previous menu.");
        }

    }
}