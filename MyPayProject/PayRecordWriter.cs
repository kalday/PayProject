using System;
using System.Collections.Generic;
using System.Text;

// additional libraries 
using CsvHelper;
using System.IO;
using System.Globalization;

namespace MyPayProject
{
    public class PayRecordWriter
    {
        #region Methods
        public static void Write(string file, List<PayRecord> records, bool writeToConsole)
        {
            StreamWriter outputFile = new StreamWriter(@"..\..\..\Export\" + file);

            CsvWriter csv = new CsvWriter(outputFile, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);

            csv.Dispose();

            // write to console if TRUE
            if (writeToConsole == true)
            {
                foreach(PayRecord record in records)
                {
                    Console.WriteLine(record.GetDetails());
                }
            }
        }
        #endregion Methods
    }
}
