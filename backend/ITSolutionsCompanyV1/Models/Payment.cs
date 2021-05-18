using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; } //TODO >0
        public string Currency { get; set; } //TODO: check whether the currency is in CurrencyType
        public bool Deleted { get; set; }
        public virtual Client Client { get; set; }
        public virtual Project Project { get; set; }

        public Payment(Guid id, DateTime date, decimal amount, string currency)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Currency = currency;
            //TODO:set client & project?
        }
    }
}
