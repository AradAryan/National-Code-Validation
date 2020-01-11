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
    public class Inquiry : WebService
    {

        [WebMethod]
        public bool ValidateNationalCode(string code)
        {
            int validatingCode = int.Parse(code[9].ToString());
            int x = 0;
            int i = 10;
            bool result = false;

            Regex reg = new Regex(@"\d{10}");
            var isDigit = reg.IsMatch(code);

            if (code.Length == 10 && isDigit)
            {
                do
                {
                    int y = int.Parse(code[10 - i].ToString()) * i;
                    x += y;
                    i--;
                } while (i >= 2);

                var c = x % 11;
                if (c >= 2)
                {
                    if (validatingCode == 11 - c)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        [WebMethod]
        public string GetPerson(int id)
        {
            List<PersonInformation> persons = new List<PersonInformation>
            {
                new PersonInformation
                {
                    Name="Arad",
                    LastName = "Aryan",
                    NationalID = 0410670030,
                    BirthDate = "25 Aban 1378",
                },
                new PersonInformation
                {
                    Name = "Mohamad Javad",
                    LastName = "ArabSalmany",
                    NationalID = 0410670031,
                    BirthDate = "25 Aban 78"
                },
                new PersonInformation
                {
                    Name = "Hamid Reza",
                    LastName = "Molahajizade",
                    NationalID = 0410670040,
                    BirthDate = "17 Shahrivar 1372",
                },
            };

            var foundedPerson = persons.Where(person => person.NationalID == id).FirstOrDefault();
            string output = $"Name: {foundedPerson.Name}, Lastname: {foundedPerson.LastName}, ID: {foundedPerson.NationalID}";
            return output;
        }
    }
}
