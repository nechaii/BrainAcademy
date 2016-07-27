using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SimpleADO
{
    using System.Data;
    using System.Data.SqlClient;

    class MyFrameWorkDB
    {
        string _cn = "Data Source=DESKTOP-5IF7E5B;Initial Catalog=BAStudent;Integrated Security=True; Connect timeout=10;";

        public SqlConnection CreateConnection()
        {
            SqlConnection cn = new SqlConnection(_cn);
            return cn;
        }

        public List<Student> GetStudent()
        {
            List<Student> _studentList = null;

            using (SqlConnection cn = this.CreateConnection())
            {
                SqlCommand _sqlSelect = cn.CreateCommand();
                _sqlSelect.CommandType = CommandType.Text;
                _sqlSelect.CommandText = "select * from Student";

                SqlTransaction _tran = null;
                _sqlSelect.Transaction = _tran;

                _sqlSelect.Connection = cn;
                _sqlSelect.Connection.Open();

                //_tran = cn.BeginTransaction("select student");
                try
                {
                    Console.WriteLine("Begin select in transaction!");

                    using (SqlDataReader _dr = _sqlSelect.ExecuteReader())
                    {
                        DataTable _dt = new DataTable();
                        _dt.Load(_dr);
                        //int count = _dt.Select().Count();
                        _studentList = new List<Student>();

                        foreach (DataRow _row in _dt.Rows)
                        {
                            _studentList.Add(new Student
                            {
                                ID = int.Parse(_row["Id"].ToString()),
                                FirstName = _row["FirstName"].ToString(),
                                LastName = _row["LastName"].ToString(),
                                Grade = _row["Grade"].ToString(),
                                AvgGrade = _row["AvgGrade"].ToString(),
                                Birthdate = DateTime.Parse(_row["Birthdate"].ToString())
                            });
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("RollbackTransaction! {0}", ex.Message);
                    //_tran.Rollback();
                }
            }

            return _studentList;
        }

        public void AddStudent()
        {

        }
        
    }
}
