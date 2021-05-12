
namespace Tasks.Pages
{
    class PersonInfo
    {
        public string firstName { get; }
        public string lastName { get; }
        public long mobileNumber { get; }
        public string sex { get; }
        public string emailAddress { get; }
        public PersonInfo(string firstName, string lastName, string sex, long mobileNumber, string emailAddress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            this.emailAddress = emailAddress;
            this.mobileNumber = mobileNumber;
        }

    }
}
