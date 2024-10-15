using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using insertstudentinMvc.Models;
using System.Data.SqlClient;
using System.Data;

namespace insertstudentinMvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String Index(StudentReg std)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-SS35PNP\\SQLEXPRESS;Initial Catalog=DBstudent;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            SqlDataAdapter adp = new SqlDataAdapter("Select * from tblstudent",con);
            SqlCommandBuilder cbd= new SqlCommandBuilder(adp);

            DataSet ds = new DataSet();
            adp.Fill(ds, "tblstudent");

            DataRow dr = ds.Tables["tblstudent"].NewRow();

            dr["Id"]=std.Id;
            dr["Name"]=std.Name;
            dr["Class"]=std.Class;

            ds.Tables["tblstudent"].Rows.Add(dr);

            int n = adp.Update(ds,"tblstudent");
            if(n> 0 )
            {
                return "record inserted";
            }
            else
            {
                return "record not inserted";
            }
            
        }
    }
}