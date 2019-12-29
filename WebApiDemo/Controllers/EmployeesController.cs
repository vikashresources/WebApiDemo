using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
//using System.Web.Mvc;

namespace WebApiDemo.Controllers
{
    public class EmployeesController : ApiController
    {
        public static IList<Employee> listEmp = new List<Employee>()
        {
            #region commented code
            //    new Employee()
            //    {
            //        ID =001, FirstName="Sachin", LastName="Kalia",Department="Engineering"
            //    },
            //     new Employee()
            //    {
            //        ID =002, FirstName="Dhnanjay" ,LastName="Kumar",Department="Engineering"
            //    },
            //    new Employee()
            //    {
            //        ID =003, FirstName="Ravish", LastName="Sindhwani",Department="Finance"
            //    },
            //     new Employee()
            //    {
            //        ID =004, FirstName="Amit" ,LastName="Chaudhary",Department="Architect"
            //    },
            //     new Employee()
            //    {
            //        ID =004, FirstName="Anshu" ,LastName="Aggarwal",Department="HR"
            //    },
            #endregion commented code

        };


        //public Employee GetEmployeeById(int id)
        //{
        //    return listEmp.First(e => e.ID == id);
        //}

        //[AcceptVerbs("GET")]
        //public Employee RPCStyleMethodFetchEmployee(int id)
        //{
        //    return listEmp.First(e => e.ID == id);
        //}

        [AcceptVerbs("GET")]
        public Employee RPCStyleMethodFetchFirstEmployees()
        {
            return listEmp.FirstOrDefault();
        }

        [HttpGet]
        [ActionName("GetEmployeeByID")]
        public Employee Get(int id)
        {
            //return listEmp.First(e => e.ID == id);
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SQLEXPRESS01;Database=DBCompany;Trusted_Connection=True;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from tblEmployee where EmployeeId=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Employee emp = null;
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader.GetValue(0));
                emp.Name = reader.GetValue(1).ToString();
                emp.ManagerId = Convert.ToInt32(reader.GetValue(2));
            }
            return emp;
            myConnection.Close();
        }


        [HttpPost]
        public void AddEmployee(Employee employee)
        {
            //int maxId = listEmp.Max(e => e.ID);
            //employee.ID = maxId + 1;
            //listEmp.Add(employee);


            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SQLSERVER2008R2;Database=DBCompany;User ID=sa;Password=Tpg@1234;";
            //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)";
            sqlCmd.Connection = myConnection;


            sqlCmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
            sqlCmd.Parameters.AddWithValue("@Name", employee.Name);
            sqlCmd.Parameters.AddWithValue("@ManagerId", employee.ManagerId);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }


        [ActionName("DeleteEmployee")]
        public void DeleteEmployeeByID(int id)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=.\SQLSERVER2008R2;Database=DBCompany;User ID=sa;Password=Tpg@1234;";
            // myConnection.ConnectionString = @"Server=NDI-LAP-274\SQLSERVER2008R2;Database=DBCompany;Trusted_Connection=True;";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from tblEmployee where EmployeeId=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
        //[HttpPatch]
        //public string UpdateDetailsViaPatch(int ID, [FromBody] string LastName)
        //{
        //    var emp = listEmp.FirstOrDefault(e => e.ID == ID);
        //    emp.LastName = LastName;
        //    return "Sucessfully Updated the LastName of" + emp.FirstName;

        //}


    }
}
