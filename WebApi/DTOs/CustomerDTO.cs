using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTOs
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }
    }


    public class CustomerDTO : BaseDTO
    {
        public string FullName { get; set; }        
        public Gender Sex { get; set; }

    }
}
