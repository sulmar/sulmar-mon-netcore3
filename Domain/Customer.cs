using System;

namespace Domain
{

    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public decimal? Salary { get; set; }
    }

    public enum Gender : byte
    {
        Man,
        Female
    }
}
