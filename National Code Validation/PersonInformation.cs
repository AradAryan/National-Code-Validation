using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace National_Code_Validation
{
    public class PersonInformation
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string NationalID { get; set; }

        /// <summary>
        /// Using This Property for Counting Get Person Function Run Counts
        /// </summary>
        public static int GetPersonCounter { get; set; }
    }
}