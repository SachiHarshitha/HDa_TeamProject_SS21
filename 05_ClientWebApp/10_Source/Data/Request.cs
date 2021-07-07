using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace INTRANAV_Client_Application.Data
{
    public class Request
    {

        public Request() { }
        public Request(string name, string email, string clientID, DateTime orderDate, uint quantity, uint level)
        {
            OrderDate = orderDate;
            Quantity = quantity;
            Level = level;
            ClientID = clientID;
            Name = name;
            Email = email;
        }
        public Request(string reqAddress, string relAddress, BigInteger tokenAmount, DateTime orderDate, uint quantity, uint level, string authCode, string clientID, string name, string email, byte status)
        {
            ReqAddress = reqAddress;
            RelAddress = relAddress;
            TokenAmount = tokenAmount;
            OrderDate = orderDate;
            Quantity = quantity;
            Level = level;
            AuthCode = authCode;
            ClientID = clientID;
            Name = name;
            Email = email;
            Status = status;
        }

        public virtual string ReqAddress { get; set; }
        public virtual string RelAddress { get; set; }
        public virtual BigInteger TokenAmount { get; set; }
        [Required]
        public virtual DateTime OrderDate { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public virtual uint Quantity { get; set; }
        [Required]
        [Range(1, 2, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public virtual uint Level { get; set; }
        public virtual string AuthCode { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Please enter the correct 10 digit Client ID")]
        public virtual string ClientID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name is too long.")]
        public virtual string Name { get; set; }
        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }
        public virtual byte Status { get; set; }

        public string get_StatusText()
        {
            switch (this.Status)
            {
                case 0:
                    return "Open";
                case 1:
                    return "Requested";
                case 2:
                    return "Acknowledged";
                case 3:
                    return "Paid";
                case 4:
                    return "Rejected";
                default:
                    return "UNKNOWN";
            }
        }
        public class CheckDateRangeAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime dt = (DateTime)value;
                if (dt >= DateTime.UtcNow)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult(ErrorMessage ?? "Make sure your date is >= than today");
            }
        }
    }
}
