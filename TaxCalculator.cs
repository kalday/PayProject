using System;
using System.Collections.Generic;
using System.Text;

namespace MyPayProject
{
    public class TaxCalculator
    {
        /// <summary>
        /// Calculates the resident's tax amount based on the value of gross pay.
        /// </summary>
        /// <param name="gross">double: Resident's gross pay</param>
        /// <returns>double: Total tax amount</returns>
        public static double CalculateResidentialTax(double gross)
        {
            // declare variables
            double residentialTax;

            if ((gross > -1) && (gross <= 72))
            {
                residentialTax = (0.19 * gross) - 0.19;
            }
            else if ((gross > 72) && (gross <= 361))
            {
                residentialTax = (0.2342 * gross) - 3.213;
            }
            else if ((gross > 361) && (gross <= 932))
            {
                residentialTax = (0.3477 * gross) - 44.2476;
            }
            else if ((gross > 932) && (gross <= 1380))
            {
                residentialTax = (0.345 * gross) - 41.7311;
            }
            else if ((gross > 1380) && (gross <= 3111))
            {
                residentialTax = (0.39 * gross) - 103.8657;
            }
            else
            {
                residentialTax = (0.47 * gross) - 352.7888;
            }

            return residentialTax;
        }
        
        /// <summary>
        /// Calculates the tax for a working holiday employee based on the tax scale.
        /// </summary>
        /// <param name="gross">double: Employee's gross pay</param>
        /// <param name="yearToDate">double: How much the employee was paid during the financial year</param>
        /// <returns>double: Total Working Holiday Tax</returns>
        public static double CalculateWorkingHolidayTax(double gross, double yearToDate)
        {
            // declare variables
            double workingHolTax;
            double newGross = gross + yearToDate;   // total gross amount to calculate tax

            if ((newGross > -1) && (newGross <= 37000))
            {
                workingHolTax = gross * 0.15;
            }
            else if ((newGross > 37000) && (newGross <= 90000))
            {
                workingHolTax = gross * 0.32;
            }
            else if ((gross > 90000) && (gross <= 180000))
            {
                workingHolTax = gross - 0.37;
            }
            else
            {
                workingHolTax = gross * 0.45;
            }

            return workingHolTax;
        }
    }
}
