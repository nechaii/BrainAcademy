using System;

namespace _01_Serializable
{
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    using System.Xml.Serialization;
    using System.Runtime.Serialization.Formatters.Soap;

    [Serializable]
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumetNum { get; set; }
    }

    static public class SimpleSerialize
    {
        static public void StudentSerialize()
        {
            Student _student = new Student { ID = 1, FirstName = "Ivan", LastName = "Franko", DocumetNum = "AA-12345" };
            BinarSerialize(_student);
            XMLSerialize(_student);
            SOAPSerialize(_student);
        }

        static void BinarSerialize(Student _student)
        {
            IFormatter _format = new BinaryFormatter();
            using (FileStream _file = File.Open("Binary.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                _format.Serialize(_file, _student);
            }
        }

        static void XMLSerialize(Student _student)
        {
            XmlSerializer _xMLSerialize = new XmlSerializer(_student.GetType());

            using (FileStream _file = File.Open("Xml.xml", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                _xMLSerialize.Serialize(_file, _student);
            }
        }

        static void SOAPSerialize(Student _student)
        {
            SoapFormatter _soapFormatter = new SoapFormatter();

            using (FileStream _file = File.Open("SOAP.xml", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                _soapFormatter.Serialize(_file, _student);
            }
        }
    }
}
