using System.ComponentModel.DataAnnotations;

namespace INTRANAV_Client_Application
{
    public class User
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        private string firstName;
        [Required]
        [StringLength(20, ErrorMessage = "Name is too long.")]
        private string lastName;
        [Required]
        [EmailAddress]
        private string email;

        private string fullName;

        [Required]
        [StringLength(10, ErrorMessage = "Please enter the correct 10 digit Client ID")]
        public virtual string ClientID { get; set; }

        private string privateKey;

        private string authcode;

        public User() { }
        public User(string firstName, string lastName, string email, string privateKey, string clientID)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PrivateKey = privateKey;
            this.ClientID = clientID;
        }

        public User(string firstName, string lastName, string email, string clientID)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.ClientID = clientID;
        }

        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string FullName { get => lastName + "," + firstName; set => fullName = lastName + "," + firstName; }
        public string Email { get => email; set => email = value; }
        public string PrivateKey { get => privateKey; set => privateKey = value; }
        public string Authcode { get => authcode; set => authcode = value; }
    }
}
