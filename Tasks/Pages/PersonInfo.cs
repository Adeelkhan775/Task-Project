namespace Tasks.Pages
{
    class PersonInfo
    {
        public string firstName { get; }
        public string lastName { get; }
        public long mobileNumber { get; }
        public string gender { get; }
        public string emailAddress { get; }
        public PersonInfo(string firstName, string lastName, string gender, long mobileNumber, string emailAddress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.emailAddress = emailAddress;
            this.mobileNumber = mobileNumber;
        }

    }
}
