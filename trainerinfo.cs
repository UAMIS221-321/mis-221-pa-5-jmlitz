namespace pa5_Trainers
{
    public class TrainerInfo
    {
        private int trainerID;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmail;
        private bool isDeleted;

        static private int trainerCount;

    public TrainerInfo(int trainerID, string trainerName, string mailingAddress, string trainerEmail, bool isDeleted){
        this.trainerID = trainerID;
        this.trainerName = trainerName;
        this.mailingAddress = mailingAddress;
        this.trainerEmail = trainerEmail;
        this.isDeleted = isDeleted;
        }
    
    public TrainerInfo(){
        //no arg
    }

    public void SetTrainerID(int trainerID){
        this.trainerID = trainerID;
    }

    public int GetTrainerID(){
        return trainerID;
    }

    public void SetTrainerName(string trainerName){
        this.trainerName = trainerName;
    }

    public string GetTrainerName(){
        return trainerName;
    }

    public void SetMailingAddress(string mailingAddress){
        this.mailingAddress = mailingAddress;
    }

    public string GetMailingAddress(){
        return mailingAddress;
    }

    public void SetTrainerEmail(string trainerEmail){
        this.trainerEmail = trainerEmail;
    }

    public string GetTrainerEmail(){
        return trainerEmail;
    }

    static public void SetTrainerCount(int trainerCount){
        TrainerInfo.trainerCount = trainerCount;
    }

    static public int GetTrainerCount(){
        return TrainerInfo.trainerCount;
    }

    static public void IncTrainerCount(){
        TrainerInfo.trainerCount++;
    }

    static public void DecTrainerCount(){
        TrainerInfo.trainerCount--;
    }

    public void SetDeleted(bool isDeleted){
        this.isDeleted = isDeleted;
    }

    public bool GetDeleted(){
        return isDeleted;
    }

    public int CompareTo(int i, int trainerID){
        if(i == trainerID) return 0;
        if(i < trainerID) return -1;
        return 1;
    }

    public override string ToString(){
        return trainerID + "\t" + trainerName + "\t" + mailingAddress + "\t" + trainerEmail + "\t" + isDeleted;
    }
    public string ToFile(){
        return trainerID + "#" + trainerName + "#" + mailingAddress + "#" + trainerEmail + "#" + isDeleted;
    }

    }
}