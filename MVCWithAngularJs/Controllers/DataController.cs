using MVCWithAngularJs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCWithAngularJs.Controllers
{
    public class DataController : Controller
    {
        //
        // GET: /Data/
        //For fetch Last Contact
        public JsonResult GetLastContact()
        {
            Contact c = null;
            //here MyDatabaseEntities our DBContext
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                c = dc.Contacts.OrderByDescending(a => a.ContactID).Take(1).FirstOrDefault();
            }
            return new JsonResult { Data = c, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult UserLogin(LoginData d)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var user = dc.Users.Where(a => a.Username.Equals(d.Username) && a.Password.Equals(d.Password)).FirstOrDefault();
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetEmployeeList()
        {
            List<Employee> Employee = new List<Employee>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                Employee = dc.Employees.OrderBy(a => a.FirstName).ToList();
            }

            return new JsonResult { Data = Employee, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // Fetch Country
        public JsonResult GetCountries()
        {
            List<Country> allCountry = new List<Country>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                allCountry = dc.Countries.OrderBy(a => a.CountryName).ToList();
            }
            return new JsonResult { Data = allCountry, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        // Fetch State by Country ID

        public JsonResult GetStates(int countryID)
        {
            List<State> allState = new List<State>();
            using (MyDatabaseEntities dc  = new MyDatabaseEntities())
            {
                allState = dc.States.Where(a => a.CountryID.Equals(countryID)).OrderBy(a => a.StateName).ToList();
            }
            return new JsonResult { Data = allState, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
