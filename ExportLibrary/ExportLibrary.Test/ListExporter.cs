using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace ExportLibrary.Test
{
    [TestClass]
    public class ListExporter
    {
        [TestMethod]
        public void ExportToCsvDefaultHeadersAndColumns()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person(1, "sam"));
            people.Add(new Person(2, "john"));
            people.Add(new Person(3, "paul"));

            //Get it as a CSV file, using default Headers, and default Columns, 
            //and standard "," seperator
            using (StreamWriter writer = new StreamWriter(@"c:\temp\exportedWithDefaultHeadersAndDefaultColumns.csv"))
            {
                people.GetExporter()
                    .AddExportableColumn((x) => x.Age)
                    .AddExportableColumn((x) => x.Name)
                    .AsCSVString(writer);
            }
        }

        [TestMethod]
        public void ExportToCsvDefaultHeaderFormattedColumns()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person(1, "sam"));
            people.Add(new Person(2, "john"));
            people.Add(new Person(3, "paul"));

            //Get it as a CSV file, using automatic Headers, but formatted Columns, 
            //and standard "," seperator
            using (StreamWriter writer = new StreamWriter(@"c:\temp\exportedWithDefaultHeadersAndFormattedColumns.csv"))
            {
                people.GetExporter()
                    .AddExportableColumn((x) => x.Age, customFormatString: "The Person Age Is {0}")
                    .AddExportableColumn((x) => x.Name, customFormatString: "The Persons Name {0}")
                    .AsCSVString(writer);
            }
        }

        [TestMethod]
        public void ExportToCsvCustomHeadersAndDefaultColumns()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person(1, "sam"));
            people.Add(new Person(2, "john"));
            people.Add(new Person(3, "paul"));

            //Get it as a CSV file, using custom Headers, but default Columns
            //and standard "," seperator
            using (StreamWriter writer = new StreamWriter(@"c:\temp\exportedWithCustomHeadersAndDefaultColumns.csv"))
            {
                people.GetExporter()
                    .AddExportableColumn((x) => x.Age, headerString: "AgeColumn")
                    .AddExportableColumn((x) => x.Name, headerString: "NameColumn")
                    .AsCSVString(writer);
            }
        }
    }


    public class Person
    {
        public int Age { get; set; }
        public String Name { get; set; }

        public Person(int age, String name)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}
