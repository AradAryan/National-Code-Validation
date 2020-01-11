using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

namespace National_Code_Validation
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : WebService
    {
        #region Validate National Code
        [WebMethod]
        public bool ValidateNationalCode(string code)
        {
            /// input has 10 digits that all of them are not equal
            if (!Regex.IsMatch(code, @"^(?!(\d)\1{9})\d{10}$"))
                return false;

            var check = Convert.ToInt32(code.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(code.Substring(x, 1)) * (10 - x))
                .Sum() % 11;

            return sum < 2 && check == sum || sum >= 2 && check + sum == 11;
        }
        #endregion

        #region GetPerson Function
        /// <summary>
        /// Get Person National Code and Return The Informations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetPerson(string id)
        {
            string output;
            if (PersonInformation.GetPersonCounter < 2)
            {
                List<PersonInformation> persons = new List<PersonInformation>
            {
                new PersonInformation
                {
                    Name = "Arad",
                    LastName = "Aryan",
                    NationalID = "0410670030",
                    BirthDate = "25 Aban 1378",
                },
                new PersonInformation
                {
                    Name = "Mohammad Javad",
                    LastName = "ArabSalmany",
                    NationalID = "0410670031",
                    BirthDate = "25 Aban 78"
                },
                new PersonInformation
                {
                    Name = "Hamid Reza",
                    LastName = "Mola haji zade",
                    NationalID = "0410670040",
                    BirthDate = "17 Shahrivar 1372",
                },
            };

                var foundedPerson = persons.Where(person => person.NationalID == id).FirstOrDefault();
                output = $"Name: {foundedPerson.Name}, LastName: {foundedPerson.LastName}, ID: {foundedPerson.NationalID}";
                PersonInformation.GetPersonCounter++;
            }
            else
                output = "404 Not Person Found";
            return output;
        }
        #endregion
    }
}
