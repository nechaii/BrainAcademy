using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections;

    class WorkWithDB
    {
        SqlConnection _cn = null;

        public void SimpleWork()
        {
            using (_cn  = new SqlConnection())
            {
                try
                {
                    _cn.ConnectionString = "Data Source=DESKTOP-5IF7E5B;Initial Catalog=Northwind;Integrated Security=True; Connect timeout=10;";
                    _cn.Open();
                    ShowConnectionInfo();
                    GetCategories();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ShowConnectionInfo()
        {
            Console.WriteLine(_cn.State);
            Console.WriteLine(_cn.DataSource);
        }

        public void GetCategories()
        {
            string _categories = "select [CategoryName] from [dbo].[Categories]";

            SqlCommand _sqlCommand = new SqlCommand(_categories, this._cn);
            _sqlCommand.CommandType = CommandType.Text;
            SqlDataReader _sqlDataReader = _sqlCommand.ExecuteReader();

            while (_sqlDataReader.Read())
            {
                Console.WriteLine(_sqlDataReader["CategoryName"].ToString());
            }
        }
    }

    class WorkWithDBDataAdapter
    {
        SqlConnection _cn = null;

        public void SimpleWork()
        {
            using (_cn = new SqlConnection())
            {
                try
                {
                    _cn.ConnectionString = "Data Source=DESKTOP-5IF7E5B;Initial Catalog=Northwind;Integrated Security=True; Connect timeout=10;";
                    _cn.Open();
                    ShowConnectionInfo();
                    GetCategories();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void ShowConnectionInfo()
        {
            Console.WriteLine(_cn.State);
            Console.WriteLine(_cn.DataSource);
        }

        public void GetCategories()
        {
            string _categories = "select CategoryID, Description, CategoryName from Categories";

            SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(_categories, this._cn);
            DataSet _dataSet = new DataSet("ConsoleApplication1");

            //DataTable _dataTable = new DataTable("Categories");
            //_dataSet.Tables.Add(_dataTable);

            _sqlDataAdapter.Fill(_dataSet);
  
            //PrintDatSet(_dataSet);         
        }

        void  PrintDatSet(DataSet ds)
        {
            Console.WriteLine("Name DataSet is {0}: ", ds.DataSetName);
            foreach (DictionaryEntry de in ds.ExtendedProperties)
            {
                Console.WriteLine("Key: {0}, Value: {1}", de.Key, de.Value);
            }

            Console.WriteLine(new string('-',50));

            //Таблица
            Console.WriteLine("Table list: ");
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("Table: {0}", dt.TableName);

                //столбцы
                for (int i =0; i<= dt.Columns.Count; i++)
                    Console.Write(dt.Columns[i].ColumnName + '\t');
                Console.WriteLine(new string('-', 50));

                //строки
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                        Console.Write(dt.Rows[i][j].ToString() + '\t');
                }
                Console.WriteLine(new string('*', 50));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.UTF8Encoding.UTF8;

            /*
            WorkWithDB _workWithDB = new WorkWithDB();
            _workWithDB.SimpleWork();
            */

            WorkWithDBDataAdapter _workWithDBDataAdapter = new WorkWithDBDataAdapter();
            _workWithDBDataAdapter.SimpleWork();


            Console.ReadKey();
        }
    }
}
