using System;
using System.Collections.Generic;
using System.Text;

namespace MyPayProject
{
    public class ResidentPayRecord : PayRecord
    {
        #region Constructors
        /// <summary>
        /// Default constructor for ResidentPayRecord
        /// </summary>
        /// <param name="id">int: Employee ID</param>
        /// <param name="hours">double: array of shift hours</param>
        /// <param name="rates">double: array of shift rate</param>
        public ResidentPayRecord(int id, double[] hours, double[] rates) : base (id, hours, rates)
        {

        }
        #endregion Constructors

        #region Overrides
        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateResidentialTax(Gross);
            }
        }
        #endregion Overrides 
    }
}
