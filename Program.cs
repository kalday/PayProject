using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;

namespace TestingCSVHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare variables
            List<Course> courseList;

            #region Reading File
            /* ======================== READING FILE ========================  */

            // instantiating 
            using (var reader = new StreamReader(@"../../../Import/courseList.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // read records from csv file
                var records = csv.GetRecords<Course>();

                // store records in course list
                courseList = new List<Course>(records);
            }

            // display to console
            foreach (Course item in courseList)
            {
                Console.WriteLine(item.Code + " " + item.Name + " " + item.Units);
            }


            /* ===============================================================  */
            #endregion Reading File


            #region Writing to File
            /* ======================== WRITING TO FILE ========================  */
            
            // print count 
            Console.WriteLine(courseList.Count);

            // add an extra course
            Course newCourse = new Course();
            newCourse.Code = "ICT60020";
            newCourse.Name = "Advanced diploma in IT";
            newCourse.Units = 20;
            courseList.Add(newCourse);

            // iterate through list 
            foreach (Course item in courseList)
            {
                Console.WriteLine(item.Code + " " + item.Name + " " + item.Units);
            }

            // new unique filename
            string filename = DateTime.Now.Ticks + "courseList.csv";

            using (var writer = new StreamWriter(@"../../../Export/" + filename))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(courseList);
            }
            
            /* ===============================================================  */
            #endregion Writing to File
        }
    }
}
