using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTOs
{
    public abstract class BaseDTO
    {

    }


    public class CustomerDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
