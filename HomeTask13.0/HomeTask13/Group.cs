using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTask13
{
    internal class Group
    {

        public string No;
        public Student[] Students;
        public int StudentLimit;
       
        public void AddStudent(Student student)
        {
            if (Students.Length < StudentLimit)
            {
                Array.Resize(ref Students, Students.Length+1 );
                Students[Students.Length - 1] = student;
            }
                
            else
                Console.WriteLine("telebe limiti dolub!");
        }
    }
}
