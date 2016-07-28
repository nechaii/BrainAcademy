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
        string _cn = @"Data Source=.\SQLEXPRESSDEV01;Initial Catalog=BAStudent;Integrated Security=True; Connect timeout=10; pooling=true";
        //DESKTOP-5IF7E5B

        public List<Student> _studentList = null;
        public Dictionary<string,string> _student = null;

        public MyFrameWorkDB()
        {
            GetStudent();
            SelectStudent(3);
            //UpdateStudent(3);
            //InsertStudent();
            //DeleteStudent(7);
        }

        public SqlConnection CreateConnection()
        {
            SqlConnection cn = new SqlConnection(_cn);
            return cn;
        }

        public void GetStudent()
        {
            this._studentList = null;

            using (SqlConnection cn = this.CreateConnection())
            {
                SqlCommand _sqlSelect = cn.CreateCommand();
                _sqlSelect.CommandType = CommandType.Text;
                _sqlSelect.CommandText = "select * from Student";

                SqlTransaction _tran = null;
                _sqlSelect.Transaction = _tran;

                _sqlSelect.Connection = cn;

                _sqlSelect.Connection.Open();

                //_tran = cn.BeginTransaction(IsolationLevel.ReadUncommitted);
                try
                {
                    Console.WriteLine("Begin select in transaction!");

                    using (SqlDataReader _dr = _sqlSelect.ExecuteReader())
                    {
                        DataTable _dt = new DataTable();
                        _dt.Load(_dr);
                        //_dr.GetFieldValue<int>(1);
                        //_dr.GetString(1);
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
        }

        public void SelectStudent(int Id)
        {
            using (SqlConnection _cn = this.CreateConnection())
            {
                SqlCommand _sqlGetStudentProc = new SqlCommand("GetStudentProc");
                _sqlGetStudentProc.CommandType = CommandType.StoredProcedure;
                _sqlGetStudentProc.Parameters.AddWithValue("@pId",Id);
                _sqlGetStudentProc.Connection = _cn;

                try
                {
                    _sqlGetStudentProc.Connection.Open();
                    _sqlGetStudentProc.Transaction = _cn.BeginTransaction(IsolationLevel.ReadUncommitted);

                    using (SqlDataReader _dr = _sqlGetStudentProc.ExecuteReader())
                    {
                        _student = new Dictionary<string, string>();

                        while (_dr.Read())
                        for (int i=0; i< _dr.FieldCount;i++)
                        {
                            _student.Add(_dr.GetName(i), _dr[i].ToString());
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Some error! {0}", ex.Message);
                }
            }
        }

        public void UpdateStudent(int Id)
        {
            using (SqlConnection _cn = this.CreateConnection())
            {
                SqlCommand _sqlUpdateStudentProc = new SqlCommand("UpdateStudentProc");
                _sqlUpdateStudentProc.CommandType = CommandType.StoredProcedure;
                _sqlUpdateStudentProc.Parameters.AddWithValue("@pId", Id);
                _sqlUpdateStudentProc.Parameters.AddWithValue("@pFirstName", "Ivan");
                _sqlUpdateStudentProc.Parameters.AddWithValue("@pLastName", "Dulya");
                _sqlUpdateStudentProc.Connection = _cn;

                try
                {
                    _sqlUpdateStudentProc.Connection.Open();
                    _sqlUpdateStudentProc.Transaction = _cn.BeginTransaction("Begin update");

                    using (SqlDataReader _dr = _sqlUpdateStudentProc.ExecuteReader())
                    {
                        _student = new Dictionary<string, string>();

                        while (_dr.Read())
                            for (int i = 0; i < _dr.FieldCount; i++)
                            {
                                _student.Add(_dr.GetName(i), _dr[i].ToString());
                            }
                    }
                    _sqlUpdateStudentProc.Transaction.Commit();
                }

                catch (Exception ex)
                {
                    _sqlUpdateStudentProc.Transaction.Rollback();
                    Console.WriteLine("Some error! {0}", ex.Message);
                }
            }
        }

        public void InsertStudent()
        {
            using (SqlConnection _cn = this.CreateConnection())
            {
                SqlCommand _sqlInsertStudentProc = new SqlCommand("InsertStudentProc");
                _sqlInsertStudentProc.CommandType = CommandType.StoredProcedure;

                _sqlInsertStudentProc.Parameters.AddWithValue("@pFirstName", "Stepan");
                _sqlInsertStudentProc.Parameters.AddWithValue("@pLastName", "Bandera");
                _sqlInsertStudentProc.Parameters.AddWithValue("@pGrade", "8");
                _sqlInsertStudentProc.Parameters.AddWithValue("@pAvgGrade", "45");
                _sqlInsertStudentProc.Connection = _cn;

                try
                {
                    _sqlInsertStudentProc.Connection.Open();
                    _sqlInsertStudentProc.Transaction = _cn.BeginTransaction("Begin insert");

                    using (SqlDataReader _dr = _sqlInsertStudentProc.ExecuteReader())
                    {
                        _student = new Dictionary<string, string>();

                        while (_dr.Read())
                            for (int i = 0; i < _dr.FieldCount; i++)
                            {
                                _student.Add(_dr.GetName(i), _dr[i].ToString());
                            }
                    }
                    _sqlInsertStudentProc.Transaction.Commit();
                }

                catch (Exception ex)
                {
                    _sqlInsertStudentProc.Transaction.Rollback();
                    Console.WriteLine("Some error! {0}", ex.Message);
                }
            }
        }

        public void DeleteStudent(int Id)
        {
            using (SqlConnection _cn = this.CreateConnection())
            {
                SqlCommand _sqlGetStudentProc = new SqlCommand("deete from student where Id=@pId");
                _sqlGetStudentProc.CommandType = CommandType.Text;
                _sqlGetStudentProc.Parameters.AddWithValue("@pId", Id);
                _sqlGetStudentProc.Connection = _cn;

                try
                {
                    _sqlGetStudentProc.Connection.Open();
                    _sqlGetStudentProc.Transaction = _cn.BeginTransaction(IsolationLevel.ReadUncommitted);

                    var t = _sqlGetStudentProc.ExecuteNonQuery();                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Some error! {0}", ex.Message);
                }
            }
        }

    }
}
