using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viatic.Web.Data.Entities
{
    public class ExpenseEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public double Value { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();

        public TripEntity Trip { get; set; }

        public ICollection<ExpenseTypeEntity> ExpensesType { get; set; }

    }
}
