using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DB
{
    using System.Data.Entity;
    using Student.Model;

    public class StudentDBInit : DropCreateDatabaseAlways<StudentDB>
    {
        public StudentDBInit()
        {
            
        }

        protected override void Seed(StudentDB studentDB)
        {
            Student studentA = new Student() { FirstName = "Ivan", LastName = "Pidlypnyi", StudNum = "AA-00001" };
            Student studentB = new Student() { FirstName = "Taras", LastName = "Kopyto", StudNum = "BB-00002" };
            Student studentC = new Student() { FirstName = "Sergio", LastName = "Openok", StudNum = "CC-00003" };
            Student studentD = new Student() { FirstName = "Pavlo", LastName = "Lypa", StudNum = "DD-00004" };
            Student studentE = new Student() { FirstName = "Grygor", LastName = "Lapa", StudNum = "EE-00005" };
            Student studentF = new Student() { FirstName = "Fedot", LastName = "Krit", StudNum = "FF-00006" };
            Student studentG = new Student() { FirstName = "Tymur", LastName = "Cheerpak", StudNum = "GG-00007" };
            Student studentH = new Student() { FirstName = "Vasyl", LastName = "Mokryi", StudNum = "HH-00008" };

            List<Student> students = new List<Student> { studentA, studentB, studentC, studentD, studentE, studentF, studentG, studentH };


            Group groupA = new Group() { GroupNum = GroupNum.A };
            Group groupB = new Group() { GroupNum = GroupNum.B };
            Group groupC = new Group() { GroupNum = GroupNum.C };

            groupA.Student.Add(studentA);
            groupA.Student.Add(studentB);
            groupB.Student.Add(studentC);
            groupB.Student.Add(studentD);

            ((List<Student>)groupC.Student).AddRange(new List<Student> { studentE, studentF, studentG, studentH });

            List<Group> groups = new List<Group> { groupA, groupB, groupC };

            students.ForEach(p => studentDB.Students.Add(p));
            groups.ForEach(p => studentDB.Group.Add(p));
            studentDB.SaveChanges();
        }

    }
}
