using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{

    public class Customer : BaseEntity
    {
        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public decimal? Salary { get; set; }
        public string Pesel { get; set; }
        public Address InvoiceAddress { get; set; }
        public Address ShipAddress { get; set; }
        public Coordinate Location { get; set; }

        public static decimal SalaryOverLimit = 1000;
        public bool IsSalaryOverLimit => Salary > SalaryOverLimit;
        public string HashedPassword { get; set; }
        public bool IsRemoved { get; set; }

        public Customer()
        {
            InvoiceAddress = new Address();
            ShipAddress = new Address();
        }
    }

    public struct Coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
    }

    public class Address : Base
    {
        public string City { get; set; }
        public string Street { get; set; }
    }

    public enum Gender : byte
    {
        Man,
        Female
    }
}
