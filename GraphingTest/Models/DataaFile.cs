using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphingTest.Models
{
    public class DataaFile
    {
        public int DataaFileID { get; set; }

        public DateTime EntryDate { get; set;}
        public int Value { get; set; }
    }
}