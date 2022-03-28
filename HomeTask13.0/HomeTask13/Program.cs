using System;

namespace HomeTask13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Grupun adini daxil edin : ");
            string groupNo = Console.ReadLine();
            while (!CheckGroupNo(groupNo))
            {
                Console.WriteLine("Groupun adi 2 boyuk herfle baslamali ve sonrasinda 3 reqem olmalidir. Adi duzgundaxil edin : ");
                groupNo = Console.ReadLine();
            }

            Console.WriteLine("Groupdaki telebelerin limit sayini daxil edin : ");
            int studentLimit = Convert.ToInt32(Console.ReadLine());
            while (studentLimit < 0 || studentLimit > 20)
            {
                Console.WriteLine("Telebelerin limit say  0-dan kicik və 20-den boyuk ola bilmez. Limit sayini duzgun daxil edin :  ");
                studentLimit = Convert.ToInt32(Console.ReadLine());
            }

            Group group1 = new Group();
            group1.No = groupNo;
            group1.StudentLimit = studentLimit;
            group1.Students = new Student[0];
            int answer;
            do
            {
                Console.WriteLine("=========MENU========");
                Console.WriteLine("1. Telebe daxil edin");
                Console.WriteLine("2. Butun telebelere bax");
                Console.WriteLine("3. Telebeler uzre axtaris et");
                Console.WriteLine("0. Programi bitir");

                string fullName = "";
                double avgPoint = 0;
                do
                {
                    Console.WriteLine("Seciminizi daxil edin: ");
                    answer = Convert.ToInt32(Console.ReadLine());

                } while (answer < 0 || answer > 3);

                if (answer == 1)
                {
                    if (group1.Students.Length >= studentLimit)
                    {
                        Console.WriteLine("telebe limiti dolub!");
                    }
                    else
                    {
                        Console.WriteLine("Telebe adini daxil edin");
                        string fullname = Console.ReadLine();
                        Console.WriteLine("Telebenin orta qiymetini daxil edin: ");
                        avgPoint = Convert.ToDouble(Console.ReadLine());
                        while (avgPoint < 0 || avgPoint > 100)
                        {
                            Console.WriteLine("orta qiymet 0dan kicik 100den boyuk ola bilmez! Duzgun daxil edin : ");
                            avgPoint = Convert.ToDouble(Console.ReadLine());
                        }
                        Student student = new Student(fullName)
                        {
                            FullName = fullName,
                            AvgPoint = avgPoint,
                            GroupNo = groupNo
                        };                       
                        group1.AddStudent(student);
                    }
                }
                else if (answer == 2)
                {
                    foreach (var item in group1.Students)
                    {
                        Console.WriteLine($"telebenin adi soyadi : {item.FullName} - qrup adi : {item.GroupNo} - orta qiymeti : {item.AvgPoint}");
                    }
                }
                else if (answer == 3)
                {
                    Console.WriteLine("axtaris deyerini daxil edin: ");
                    string answer2 = Console.ReadLine();
                    bool check = false;
                    foreach (var item in group1.Students)
                    {
                        if (item.FullName == answer2)
                        {
                            Console.WriteLine($"telebenin adi soyadi: {item.FullName} - qrup adi: {item.GroupNo} - orta bali: {item.AvgPoint}");
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        Console.WriteLine("Bu adda telebe yoxdur. ");
                    }
                }
                else if (answer == 0)
                {
                    Console.WriteLine("proqram dayandirildi");
                    break;
                }
            } while (answer != 0);

        }

        static bool CheckGroupNo(string groupNo)
        {
            if (groupNo.Length == 5)
            {
                if (char.IsUpper(groupNo[0]) && char.IsUpper(groupNo[1]))
                {
                    if (char.IsDigit(groupNo[2]) && char.IsDigit(groupNo[3]) && char.IsDigit(groupNo[4]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
