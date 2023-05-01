using System;
using System.IO;

namespace pa5_Trainers
{
    public class TrainerUtil
    {
        private TrainerInfo[] myTrainers;

        public TrainerUtil(TrainerInfo[] myTrainers){
            this.myTrainers = myTrainers;
        }

        //read in all trainers from file
        public void GetAllTrainers(){
            TrainerInfo.SetTrainerCount(0);
            StreamReader inFile = new StreamReader("trainers.txt"); //open the file
            string line = inFile.ReadLine();

            while(line != null){
                string[] temp = line.Split("#");
                myTrainers[TrainerInfo.GetTrainerCount()] = new TrainerInfo(int.Parse(temp[0]), temp[1], temp[2], temp[3], bool.Parse(temp[4]));

                TrainerInfo.IncTrainerCount();
                line = inFile.ReadLine(); //update read
            }
            inFile.Close(); //close the file
        }

        public void ListAllTrainers(ref TrainerInfo[] myTrainers){//lists all trainers, even deleted ones
            for(int t = 0; t < TrainerInfo.GetTrainerCount(); t++){
                System.Console.WriteLine(myTrainers[t]);
            }
            System.Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        //saves changes to file
        public void SaveInfo(){
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for(int i = 0; i < TrainerInfo.GetTrainerCount(); i++){
                outFile.WriteLine(myTrainers[i].ToFile());
            }
            outFile.Close();
        }

        //add a new trainer
        public void AddTrainer(){
            TrainerInfo addTrainer = new TrainerInfo();

            System.Console.WriteLine();
            System.Console.WriteLine("Employee ID will be automatically generated.");
            int generatedID = TrainerInfo.GetTrainerCount() + 1;
            addTrainer.SetTrainerID(generatedID);

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the new trainer's first and last name.");
            addTrainer.SetTrainerName(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the new trainer's mailing address.");
            addTrainer.SetMailingAddress(Console.ReadLine());

            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the new trainer's email address.");
            addTrainer.SetTrainerEmail(Console.ReadLine());

            addTrainer.SetDeleted(false);

            myTrainers[TrainerInfo.GetTrainerCount()] = addTrainer;
            TrainerInfo.IncTrainerCount();


            SaveInfo();
        }


        public void EditTrainer(){

            //int searchValueID;
            System.Console.WriteLine("Please enter the trainer ID of the trainer you would like to edit.");
            int searchValueID = int.Parse(Console.ReadLine());

            int indexID = SearchByID(searchValueID, myTrainers);
            if(indexID < 0){
                System.Console.WriteLine("Employee ID was not found.");
                return;
            }

            //display selected trainer's current info
            //string temp = myTrainers[indexID];
            System.Console.WriteLine("Trainer ID cannot be edited.");
            System.Console.WriteLine("Current trainer name: " + myTrainers[indexID].GetTrainerName());
            System.Console.WriteLine("Current trainer mailing address: " + myTrainers[indexID].GetMailingAddress());
            System.Console.WriteLine("Current trainer email: " + myTrainers[indexID].GetTrainerEmail());
            System.Console.WriteLine("Is the trainer currently deleted: " + myTrainers[indexID].GetDeleted());

            //make changes to certain parts of the trainer's info and stores them in a new variable
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the trainer's new name: (press 'enter' to make no change.)");
            string newName = Console.ReadLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the trainer's new mailing address: (press 'enter' to make no change.)");
            string newMailingAddress = Console.ReadLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Please enter the trainer's new email: (press 'enter' to make no change.)");
            string newEmail = Console.ReadLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Do you wish to delete this trainer? Please enter 'y' for yes, and 'n' for no.");
            string deleteTrainerYN = Console.ReadLine();

            //edits trainer info using new variables
            if(newName != null && newName != ""){
                myTrainers[indexID].SetTrainerName(newName);
                SaveInfo();
            }
            if(newMailingAddress != null && newMailingAddress != ""){
                myTrainers[indexID].SetMailingAddress(newMailingAddress);
                SaveInfo();
            }
            if(newEmail != null && newEmail != ""){
                myTrainers[indexID].SetTrainerEmail(newEmail);
                SaveInfo();
            }
            if(deleteTrainerYN == "y"){
                myTrainers[indexID].SetDeleted(true);
                SaveInfo();
            }
            else{
                return;
            }

            //stores info 
            SaveInfo();
        }

        public int SearchByID(int searchValueID, TrainerInfo[] myTrainers){

            int foundIndexID = -1;
            int firstID = 0;
            int lastID = TrainerInfo.GetTrainerCount() - 1;

            while(foundIndexID == -1 && lastID >= firstID){
                int middleID = ((firstID + lastID) / 2);
                if(searchValueID == myTrainers[middleID].GetTrainerID()){
                    foundIndexID = middleID;
                }
                else if(0 > myTrainers[middleID].GetTrainerID().CompareTo(searchValueID)){
                    firstID = middleID + 1;
                }
                else{
                    lastID = middleID - 1;
                }
            }
            return foundIndexID;
        }

        public void TrainerMainMenu(){//code for the trainer menu
            TrainerMenuText();
            string trainerMenuSelect = Console.ReadLine();
            while(trainerMenuSelect != "4"){
                
                if(trainerMenuSelect == "1"){
                    ListAllTrainers(ref myTrainers);
                }
                if(trainerMenuSelect == "2"){
                    AddTrainer();
                }
                if(trainerMenuSelect == "3"){
                    EditTrainer();
                }
                if(trainerMenuSelect == "4"){
                    System.Console.WriteLine("ADD MAIN MENU");
                }
                else{
                    System.Console.WriteLine("Please make a valid selection from the options above.");
                }
                TrainerMenuText();
                trainerMenuSelect = Console.ReadLine();
            }
        }

        public void TrainerMenuText(){//text for the menu
            Console.Clear();
            System.Console.WriteLine("| Welcome to the Trainer Menu. Please Select an option below. |");
            System.Console.WriteLine("Enter '1' to view a list of all trainers and their info.");
            System.Console.WriteLine("Enter '2' to add a new trainer.");
            System.Console.WriteLine("Enter '3' to edit or delete a current trainer.");
            System.Console.WriteLine("Enter '4' to return to the previous menu.");
        }
    }
}