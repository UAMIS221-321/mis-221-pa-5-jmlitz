namespace pa5_Booking
{
    public class BookingInfo
    {
        private int bookingID;
        private string custName;
        private string custEmail;
        private string sessionDate;
        private int trainerID;
        private string trainerName;
        private bool bookingTaken;
        static private int transactCount;

        public BookingInfo(int bookingID, string custName, string custEmail, string sessionDate, int trainerID, string trainerName, bool bookingTaken){
            this.bookingID = bookingID;
            this.custName = custName;
            this.custEmail = custEmail;
            this.sessionDate = sessionDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.bookingTaken = bookingTaken;
        }

        public BookingInfo(){
            //no arg
        }

        public void SetBookingID(int bookingID){
            this.bookingID = bookingID;
        }

        public int GetBookingID(){
            return bookingID;
        }

        public void SetCustName(string custName){
            this.custName = custName;
        }

        public string GetCustName(){
            return custName;
        }

        public void SetCustEmail(string custEmail){
            this.custEmail = custEmail;
        }

        public string GetCustEmail(){
            return custEmail;
        }

        public void SetSessionDate(string sessionDate){
            this.sessionDate = sessionDate;
        }

        public string GetSessionDate(){
            return sessionDate;
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

        public void SetBookingTaken(bool bookingTaken){
            this.bookingTaken = bookingTaken;
        }

        public bool GetBookingTaken(){
            return bookingTaken;
        }

        static public void SetTransactCount(int transactCount){
            BookingInfo.transactCount = transactCount;
        }

        static public int GetTransactCount(){
            return BookingInfo.transactCount;
        }

        static public void IncTransactCount(){
            BookingInfo.transactCount++;
        }

        static public void DecTransactCount(){
            BookingInfo.transactCount--;
        }

        public string ToTransactString(){
            return bookingID + "\t" + custName + "\t" + custEmail + "\t" + sessionDate + "\t" + trainerID + "\t" + trainerName + "\t" + bookingTaken;
        }

        public string ToTransactFile(){
            return bookingID + "#" + custName + "#" + custEmail + "#" + sessionDate + "#" + trainerID + "#" + trainerName + "#" + bookingTaken;
        }

        internal int CompareTo(BookingInfo bookingInfo) //have absolutely ZERO clue what this does, clicked "auto generate compareTo method" when i was getting an error.
        {
            throw new NotImplementedException();
        }
    }
}