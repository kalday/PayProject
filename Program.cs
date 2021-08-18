using System;
using System.Collections.Generic;

namespace MyPayProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region TESTING
            // ==================== TaxCalculator ==================== //
            /*
            Console.WriteLine("Tax Calculator: $" + TaxCalculator.CalculateResidentialTax(652));
            Console.WriteLine("Working Holiday Tax: $" + TaxCalculator.CalculateWorkingHolidayTax(418, 47938));

            double[] hours = new double[2] { 2, 3 };
            double[] rate = new double[2] { 25, 25 };
            ResidentPayRecord newResident = new ResidentPayRecord(1, hours, rate);

            Console.WriteLine(newResident.GetDetails());
            
            foreach (PayRecord item in records)
            {
                Console.WriteLine(item.GetDetails());
            }
            // ==================== File IO ==================== //
            List<PayRecord> records = CsvImporter.ImportPayRecords("employee-payroll-data.csv");

            string file = (DateTime.Now.Ticks).ToString() + "-records.csv";

            PayRecordWriter.Write(file, records, true);
            */
            #endregion TESTING


        }
    }
}
