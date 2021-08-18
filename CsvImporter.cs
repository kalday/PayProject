using System;
using System.Collections.Generic;
using System.Text;

// additional libraries
using System.IO;

namespace MyPayProject
{
    public class CsvImporter
    {
        #region Methods
        /// <summary>
        /// Method to import all pay records from the supplied file 
        /// </summary>
        /// <param name="file">string: file name to write to</param>
        /// <returns></returns>
        public static List<PayRecord> ImportPayRecords(string file)
        {
            #region Variables
            // instantiate and declare variables
            List<PayRecord> payRecords = new List<PayRecord>();

            string line;
            string[] recordLine;
            int previousId = -1;
            int currentId;

            List<double> hours = new List<double>();    // list to hold hours
            List<double> rate = new List<double>();     // list to hold rate
            
            string yearToDate = "";
            string visa = "";
            #endregion Variables

            // open file for reading 
            StreamReader inputFile = new StreamReader(@"..\..\..\Import\" + file);

            // read first line of headings 
            line = inputFile.ReadLine();
            recordLine = line.Split(',');

            line = inputFile.ReadLine();    // read next line

            // iterate through all lines in the file
            while (line != null)
            {
                recordLine = line.Split(',');

                currentId = int.Parse(recordLine[0]);    // read employee ID

                if (previousId != currentId && previousId != -1)
                {
                    // create new record
                    payRecords.Add(CreatePayRecord(previousId, hours.ToArray(), rate.ToArray(), visa, yearToDate));
                    
                    // clear all lists for new employee
                    hours.Clear();
                    rate.Clear();

                    // start new employee
                    previousId = int.Parse(recordLine[0]);
                }

                if (previousId == -1)
                {
                    // start new employee id
                    previousId = int.Parse(recordLine[0]);
                }

                visa = recordLine[3];    // get visa code 

                // input into arrays
                hours.Add(double.Parse(recordLine[1])); // add hours
                rate.Add(double.Parse(recordLine[2]));  // add rate 

                if (visa != "" && visa != null)
                {
                    yearToDate = recordLine[4];
                }

                line = inputFile.ReadLine();    // read next line

            }

            // create pay record
            if (previousId != -1)
            {
                // create new record
                payRecords.Add(CreatePayRecord(previousId, hours.ToArray(), rate.ToArray(), visa, yearToDate));
            }
         
            // close input file
            inputFile.Close();

            return payRecords;
        }

        /// <summary>
        /// Method to create a new pay record for an employee. It creates either Resident Pay Record or Working Holiday Pay Record depending on the input values.
        /// </summary>
        /// <param name="id">int: Employee ID</param>
        /// <param name="hours">double[]: array of hours worked</param>
        /// <param name="rates">double[]: array of rates for hours worked</param>
        /// <param name="visa">string: employee visa details</param>
        /// <param name="yearToDate">string: yearToDate</param>
        /// <returns></returns>
        public static PayRecord CreatePayRecord(int id, double[] hours, double[] rates, string visa, string yearToDate)
        {
            if (visa == "" || visa == null)
            {
                // create resident pay record
                ResidentPayRecord residentRecord = new ResidentPayRecord(id, hours, rates);

                return residentRecord;
            }
            else
            {
                // create working holiday pay record 
                WorkingHolidayPayRecord holidayRecord = new WorkingHolidayPayRecord(id, hours, rates, int.Parse(visa), int.Parse(yearToDate));

                return holidayRecord;
            }
        }
        #endregion Methods
    }
}
