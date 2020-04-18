using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viatic.Web.Data.Entities
{
    public class ExpenseTypeEntity
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public ExpenseEntity Expense { get; set; }

    }
}
