using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MyPayProject
{
    public abstract class PayRecord
    {
        #region Private Variable Fields
        // parallel arrays to store shift data, initialised by arguments passed in constructor
        protected double[] _hours;
        protected double[] _rates;
        #endregion Private Variable Fields

        #region Public Properties
        public int Id
        {
            get;
            private set;
        }
        public double Gross
        {
            // derived value from sum of hours * rate for all shifts 
            get
            {
                double totalGross = 0;  // total gross calculated

                for (int i = 0; i < _hours.Length; i++)
                {
                    totalGross += _hours[i] * _rates[i];
                }

                return totalGross;
            }
        }
        public abstract double Tax
        {
            // derived value from TaxCalculator 
            get;
        }
        public double Net
        {
            // derived value from Net = Gross - Tax
            get
            {
                return Gross - Tax;
            }
        }
        #endregion Public Properties 

        #region Constructors
        /// <summary>
        /// Constructor for the PayRecord class
        /// </summary>
        /// <param name="id">int: Person ID</param>
        /// <param name="hours">double: number of hours for the shift</param>
        /// <param name="rates">doublt: rate for each shift </param>
        public PayRecord(int id, double[] hours, double[] rates)
        {
            this.Id = id;
            this._hours = hours;
            this._rates = rates;
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Method to return the details of the employee
        /// </summary>
        /// <returns>string: Employee ID, gross, net, and tax amount </returns>
        public virtual string GetDetails()
        {
            string details;

            details = "---------- EMPLOYEE: " + Id + " ----------\n";
            details += "GROSS:\t" + Gross.ToString("C", CultureInfo.CurrentCulture) + "\n";
            details += "NET:\t" + Net.ToString("C", CultureInfo.CurrentCulture) + "\n";
            details += "TAX:\t" + Tax.ToString("C", CultureInfo.CurrentCulture) + "\n";

            return details;
        } 
        #endregion Methods
    }
}
