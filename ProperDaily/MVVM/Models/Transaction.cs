﻿using Humanizer;
using ProperDaily.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDaily.MVVM.Models
{
    public class Transaction : TableData
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public DateTime OperationDate { get; set; } = DateTime.Now;
        public string HumanDate
        {
            get
            {
                return OperationDate.Humanize();
            }
        }
    }
}
