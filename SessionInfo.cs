namespace pa5_Sessions
{
    public class SessionInfo
    {
        private int sessionID;
        private string trainerName;
        private string sessionDate;
        private string sessionTime;
        private double sessionCost;
        private bool sessionTaken;

        static private int sessionCount;

    public SessionInfo(int sessionID, string trainerName, string sessionDate, string sessionTime, double sessionCost, bool sessionTaken){
        this.sessionID = sessionID;
        this.trainerName = trainerName;
        this.sessionDate = sessionDate;
        this.sessionTime = sessionTime;
        this.sessionCost = sessionCost;
        this.sessionTaken = sessionTaken;
    }

    public SessionInfo(){
        //no arg
    }

    public void SetSessionID(int sessionID){
        this.sessionID = sessionID;
    }

    public int GetSessionID(){
        return sessionID;
    }

    public void SetTrainerName(string trainerName){
        this.trainerName = trainerName;
    }

    public string GetTrainerName(){
        return trainerName;
    }

    public void SetSessionDate(string sessionDate){
        this.sessionDate = sessionDate;
    }

    public string GetSessionDate(){
        return sessionDate;
    }

    public void SetSessionTime(string sessionTime){
        this.sessionTime = sessionTime;
    }

    public string GetSessionTime(){
        return sessionTime;
    }

    public void SetSessionCost(double sessionCost){
        this.sessionCost = sessionCost;
    }

    public double GetSessionCost(){
        return sessionCost;
    }

    public void SetSessionTaken(bool sessionTaken){
        this.sessionTaken = sessionTaken;
    }

    public bool GetSessionTaken(){
        return sessionTaken;
    }

    static public void SetSessionCount(int sessionCount){
        SessionInfo.sessionCount = sessionCount;
    }

    static public int GetSessionCount(){
        return SessionInfo.sessionCount;
    }

    static public void IncSessionCount(){
        SessionInfo.sessionCount++;
    }

    static public void DecSessionCount(){
        SessionInfo.sessionCount--;
    }

    public int CompareSession(int i, int sessionID){
        if(i == sessionID) return 0;
        if(i < sessionID) return -1;
        return 1;
    }

    public string ToSessionString(){
         return sessionID + "\t" + trainerName + "\t" + sessionDate + "\t" + sessionTime + "\t" + sessionCost + "\t" + sessionTaken;
     }
    public string ToSessionFile(){
        return sessionID + "#" + trainerName + "#" + sessionDate + "#" + sessionTime + "#" + sessionCost + "#" + sessionTaken;
    }

    }
}