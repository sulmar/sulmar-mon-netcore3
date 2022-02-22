using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SearchCriterias
{
    public abstract class SearchCriteria : Base
    {

    }

    public class CustomerSearchCriteria : SearchCriteria
    {
        // string country, string city, string street

        [Required]
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
