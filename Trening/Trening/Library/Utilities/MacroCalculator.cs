using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trening.Models;

namespace Trening.Library.Utilities
{
    public class MacroCalculator
    {
        public double activity;
        public double height;
        public double age;
        public double weight;
        public MacroCalculator(CalcData cd)
        {
            activity = double.Parse(cd.Activityfactor.ToString());
            height = double.Parse(cd.Height.ToString());
            age = double.Parse(cd.Age.ToString());
            weight = double.Parse(cd.Weight.ToString());
        }

        public decimal calculateMacros()
        {
            double bEE = 66.5 + (13.75 * this.weight) + (5.003 * this.height) - (6.775 * this.age);
            double activityAndBEE = bEE + this.activity;
            decimal activ_bee = decimal.Parse(activityAndBEE.ToString());
            return activ_bee;

        }
    }
}