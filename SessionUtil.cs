using System;
using System.IO;

namespace pa5_Sessions
{
    public class SessionUtil
    {
        private SessionInfo[] mySessions;
        
        public SessionUtil(SessionInfo[] mySessions){
            this.mySessions = mySessions;
        }

        //read in all sessions from file
        public SessionInfo[] GetAllSessions(SessionInfo[] mySessions){
            SessionInfo.SetSessionCount(0);
            StreamReader inFile = new StreamReader("sessions.txt"); //open the file
            string line = inFile.ReadLine();

            while(line != null){
                string[] temp = line.Split("#");
                mySessions[SessionInfo.GetSessionCount()] = new SessionInfo(int.Parse(temp[0]), temp[1], temp[2], temp[3], double.Parse(temp[4]), bool.Parse(temp[5]));
                // System.Console.WriteLine(int.Parse(temp[0]) + temp[1] + temp[2] + temp[3] + double.Parse(temp[4]) + bool.Parse(temp[5]));
                SessionInfo.IncSessionCount();
                line = inFile.ReadLine(); //update read
            }

            inFile.Close(); //close the file
            return mySessions;

        }

        public void ListAvailableSessions(SessionInfo[] mySessions){

            // System.Console.WriteLine(mySessions[0].GetTrainerName());
            // Console.ReadKey();
            GetAllSessions(mySessions);

            for(int i = 0; i < SessionInfo.GetSessionCount(); i++){
                if(mySessions[i].GetSessionTaken() != true){
                    System.Console.WriteLine(mySessions[i].ToSessionString());
                }

            }
            System.Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public void SaveSessionInfo(){
            StreamWriter outFile = new StreamWriter("sessions.txt");
            for(int i = 0; i < SessionInfo.GetSessionCount(); i++){
                outFile.WriteLine(mySessions[i].ToSessionFile());
            }
            outFile.Close();
        }

        // public string GenerateSessionID(int generatedSessionID){
        //     int generatedSessionID = 0;
        //     generatedSessionID++;
        // }

        public void AddSession(){
            SessionInfo addSession = new SessionInfo();

            System.Console.WriteLine();
            System.Console.WriteLine("Session ID will be automatically generated.");
            int generatedSessionID = SessionInfo.GetSessionCount() + 1;
            addSession.SetSessionID(generatedSessionID);

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the trainer's name:");
            addSession.SetTrainerName(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the session date, in YYYY/MM/DD format.");
            addSession.SetSessionDate(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the session time, in HH:MM format.");
            addSession.SetSessionTime(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the session cost, in DD.CC format.");
            addSession.SetSessionCost(double.Parse(Console.ReadLine()));

            addSession.SetSessionTaken(false);

            mySessions[SessionInfo.GetSessionCount()] = addSession;
            SessionInfo.IncSessionCount();

            SaveSessionInfo();
        }

        public void EditSession(){
            SessionInfo[] mySessions = new SessionInfo[100];

            System.Console.WriteLine("Please enter the session ID of the session you would like to edit.");
            int searchValueSession = int.Parse(Console.ReadLine());

            int indexSession = SearchBySession(mySessions, ref searchValueSession);
            if(indexSession < 0){
                System.Console.WriteLine("Session ID was not found.");
                return;
            }

            //display selected trainer's current info
            //string temp = mySessions[indexSession];
            System.Console.WriteLine("Session ID cannot be edited.");
            System.Console.WriteLine("Current trainer name: " + mySessions[indexSession].GetTrainerName());
            System.Console.WriteLine("Current session date: " + mySessions[indexSession].GetSessionDate());
            System.Console.WriteLine("Current session time: " + mySessions[indexSession].GetSessionTime());
            System.Console.WriteLine("Current session cost: " + mySessions[indexSession].GetSessionCost());
            System.Console.WriteLine("Is the session currently taken:" + mySessions[indexSession].GetSessionTaken());

            //make changes to certain parts of the trainer's info and stores them in a new variable
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the trainer's new name: (press 'enter' to make no change.)");
            string newTName = Console.ReadLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the new session date: (press 'enter' to make no change.)");
            string newSessionDate = Console.ReadLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the new session time: (press 'enter' to make no change.)");
            string newSessionTime = Console.ReadLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the new session cost: (press 'enter' to make no change.)");
            string newSessionCost = Console.ReadLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Do you want to set this session to 'Taken'? Please enter 'y' for yes, and 'n' for no.");
            string setTakenYN = Console.ReadLine();

            //edits trainer info using new variables
            if(newTName != null && newTName != ""){
                mySessions[indexSession].SetTrainerName(newTName);
                SaveSessionInfo();
            }
            if(newSessionDate != null && newSessionDate != ""){
                mySessions[indexSession].SetSessionDate(newSessionDate);
                SaveSessionInfo();
            }
            if(newSessionTime != null && newSessionTime != ""){
                mySessions[indexSession].SetSessionTime(newSessionTime);
                SaveSessionInfo();
            }
            if(newSessionCost != null && newSessionCost != ""){
                mySessions[indexSession].SetSessionCost(double.Parse(newSessionCost));
                SaveSessionInfo();
            }
            if(setTakenYN == "y"){
                mySessions[indexSession].SetSessionTaken(true);
                SaveSessionInfo();
            }
            else{
                return;
            }

            //stores info 
            SaveSessionInfo();
        }

        public int SearchBySession(SessionInfo[] mySessions, ref int searchValueSession){

            int foundIndexSession = -1;
            int firstSession = 0;
            int lastSession = SessionInfo.GetSessionCount() - 1;

            while(foundIndexSession == -1 && lastSession >= firstSession){
                int middleSession = ((firstSession + lastSession) / 2);
                if(searchValueSession == mySessions[middleSession].GetSessionID()){
                    foundIndexSession = middleSession;
                }
                else if(0 > mySessions[middleSession].GetSessionID().CompareTo(searchValueSession)){
                    firstSession = middleSession + 1;
                }
                else{
                    lastSession = middleSession - 1;
                }
            }
            return foundIndexSession;
        }

        public void SessionMainMenu(){
            SessionMenuText();
            string sessionMenuSelect = Console.ReadLine();
            while(sessionMenuSelect != "3"){
                
                if(sessionMenuSelect == "1"){
                    AddSession();
                }
                if(sessionMenuSelect == "2"){
                    EditSession();
                }
                if(sessionMenuSelect == "3"){
                    System.Console.WriteLine("ADD MAIN MENU");
                }
                else{
                    System.Console.WriteLine("Please make a valid selection from the options above.");
                }
                SessionMenuText();
                sessionMenuSelect = Console.ReadLine();
            }
        }

        public void SessionMenuText(){
            System.Console.WriteLine("| Welcome to the Sessions Menu. Please Select an option below. |");
            System.Console.WriteLine("Enter '1' to add a new session.");
            System.Console.WriteLine("Enter '2' to edit or delete a current session.");
            System.Console.WriteLine("Enter '3' to return to the previous menu.");
        }
    }
}