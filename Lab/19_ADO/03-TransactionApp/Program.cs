using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_TransactionApp
{
    using System.Data;
    using System.Data.SqlClient;

    class SimpleWorkTransaction
    {
        string _cn = "Data Source=DESKTOP-5IF7E5B;Initial Catalog=Northwind;Integrated Security=True; Connect timeout=10;";

        public void SimpleTran()
        {
            using (SqlConnection cn = new SqlConnection(_cn))
            {
                SqlCommand _sqlInsert = cn.CreateCommand();
                _sqlInsert.CommandType = CommandType.Text;
                _sqlInsert.CommandText = ("insert into Categories(CategoryName,Description) values ('Test','Test')");

                SqlTransaction _tran = null;
                _sqlInsert.Transaction = _tran;

                _sqlInsert.Connection = cn;
                _sqlInsert.Connection.Open();

                _tran = cn.BeginTransaction("insert tran");

                try
                {
                    Console.WriteLine("BeginTransaction! ");
                    _sqlInsert.Transaction = _tran;

                    int flag = _sqlInsert.ExecuteNonQuery();

                    throw new Exception(string.Format("Oops!, were updated {0}",flag));

                    _tran.Commit();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("RollbackTransaction! {0}", ex.Message);
                    _tran.Rollback();
                }

                finally
                {
                    Console.WriteLine("End working with DB");
                }
            }            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleWorkTransaction _my = new SimpleWorkTransaction();
            _my.SimpleTran();

            Console.ReadKey();
        }
    }
}
