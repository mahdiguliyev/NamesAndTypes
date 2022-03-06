using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NamesAndTypes.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string NameOfWorker { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
