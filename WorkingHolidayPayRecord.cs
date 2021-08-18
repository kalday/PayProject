using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MyPayProject
{
    public class WorkingHolidayPayRecord : PayRecord
    {
        #region Public Properties
        public int Visa
        {
            get;
            private set;
        }
        public int YearToDate
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Constructors
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base (id, hours, rates)
        {
            this.Visa = visa;
            this.YearToDate = yearToDate;
        }
        #endregion Constructors

        #region Overrides
        public override double Tax
        {
            get
            {
                return TaxCalculator.CalculateWorkingHolidayTax(Gross, YearToDate);
            }      
        }

        public override string GetDetails()
        {
            string details = base.GetDetails();

            details += "VISA:\t" + Visa + "\n";
            details += "YTD:\t" + (YearToDate + Gross).ToString("C", CultureInfo.CurrentCulture) + "\n";

            return details;
        }
        #endregion Overrides 
    }
}
