﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class Starter : Food
    {
        protected Starter(string name, decimal price, double grams)
            : base(name, price, grams)
        {
        }
    }
}
