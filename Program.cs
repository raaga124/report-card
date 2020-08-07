using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Report_Card
{
    

    public interface Icommon
    {
        public int course_id { get; set; }
    }

    public class student
    {
        public int student_id { get; set; }
        public string student_name { get; set; }
        public int TotalScore { get; set; }
        public string test_id { get; set; }
       // public int mark { get; set; }

        public Dictionary<string, float> marks = new Dictionary<string, float>();


    }
    /*
    public class weight: Icommon
    {
        
       
        public int course_id { get; set; }
    }*/

    public class coursedata: Icommon
    {
        public int course_id { get; set; }
        public string course_name { get; set; }
        public string course_Teacher { get; set; }
    }


    public class Program
    {
        private static List<student> stu = new List<student>();

        public static Dictionary<string, int> dict = new Dictionary<string, int>();

        private static string input2, input, input1, input3 = "";
        public static void Main(string[] args)
        {
           // string input2 = "";
            using (StreamReader file = new StreamReader(@"C:\Users\Sricharan\Downloads\Example1\Example1\students.csv"))
            {
                string line;
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    string[] arr = line.Trim().Split(';');
                    foreach (string item in arr)
                    {
                        //Console.WriteLine(item);
                        input2 += item + '\n';
                    }
                }
            }
           

           // string input = "";
            using (StreamReader file = new StreamReader(@"C:\Users\Sricharan\Downloads\Example1\Example1\marks.csv"))
            {
                string line;
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    string[] arr = line.Trim().Split(';');
                    foreach (string item in arr)
                    {
                        //Console.WriteLine(item);
                        input += item + '\n';
                    }
                }
            }
            //Console.WriteLine(input);

            //stu.ForEach(Console.WriteLine);
            //stu.ForEach(item => Console.WriteLine(item));
            //string input1 = "";
            using (StreamReader file = new StreamReader(@"C:\Users\Sricharan\Downloads\Example1\Example1\tests.csv"))
            {
                string line;
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    string[] arr = line.Trim().Split(';');
                    foreach (string item in arr)
                    {
                        //Console.WriteLine(item);
                        input1 += item + '\n';
                    }
                }
            }

            using (StreamReader file = new StreamReader(@"C:\Users\Sricharan\Downloads\Example1\Example1\courses.csv"))
            {
                string line;
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    string[] arr = line.Trim().Split(';');
                    foreach (string item in arr)
                    {
                        //Console.WriteLine(item);
                        input3 += item + '\n';
                    }
                }
            }

            SaveCourses(input3);
            Savetests(input1);


            SaveNames(input2);

            //Savemarks(input);

            

            /*
            foreach (student o in stu)
            {
                Console.WriteLine("stu id  " + o.student_id);

                //Console.WriteLine("marks  " + o.mark);

                Console.WriteLine("test id  " + o.test_id );
            }*/
        }

        public static void SaveNames(String input2)
        {
            student Student = new student();
            //read each line for operands
            foreach (string dat in input2.Split('\n'))
            {

                // Console.WriteLine(dat);
                if (dat != "")
                {
                    string[] datSplit = dat.Split(',');
                    string studentID = datSplit[0];
                    int ID;
                    Int32.TryParse(studentID, out ID);
                    //Console.WriteLine(ID);
                    Student.student_id = ID;
                    Student.student_name = datSplit[1];
                    Savemarks(Student);
                    //return Student;
                }

            }
           // return Student;
        }

        public static void Savemarks(student stmarks)
        {
            //read each line for operands
            foreach (string dat in input.Split('\n'))
            {
               // Console.WriteLine(dat);
                if (dat != "")
                {
                    string[] datSplit = dat.Split(',');
                    string studentID = datSplit[1];
                    int ID;
                    Int32.TryParse(studentID, out ID);
                    //Console.WriteLine(ID);
                    if (stmarks.student_id == ID  && !stmarks.test_id.Contains(datSplit[0]))
                    {
                        stmarks.marks.Add(datSplit[0], Int32.Parse(datSplit[2]));
                       // stmarks.mark += Int32.Parse(datSplit[2]);
                       // stmarks.test_id +=  datSplit[0] + ",";
                        // Console.WriteLine("new");
                        // stu.Add(NewStudent(datSplit));
                        //Console.WriteLine("neW");
                    }
                    /*else if(stu.Any(x => x.student_id.Equals(ID)))
                    {
                       // Console.WriteLine("UP");
                       // stu.Add(UpdateMarks(datSplit));
                        //Console.WriteLine("up");
                    }*/

                }
            }
            PrintAnswer(stmarks);
        }
        public static void PrintAnswer(student stm)
        {
            Console.WriteLine("id: {0},  Name: {1},  ", stm.student_id, stm.student_name);
            double course1marks = 0, course2marks = 0, course3marks = 0, total = 0 ;
            foreach (KeyValuePair<string, float> kvp in stm.marks)
            {
                if (kvp.Key == "1")
                {
                    course1marks += kvp.Value*0.1;
                    
                }
                else if(kvp.Key == "2")
                {
                    course1marks += kvp.Value*0.4;
                }
                else if (kvp.Key == "3")
                {
                    course1marks += kvp.Value*0.5;
                }
                else if (kvp.Key == "4")
                {
                    course2marks += kvp.Value*0.4;
                }
                else if (kvp.Key == "5")
                {
                    course2marks += kvp.Value*0.6;
                }
                else if (kvp.Key == "6")
                {
                    course3marks += kvp.Value*0.9;
                }
                else if (kvp.Key == "7")
                {
                    course3marks += kvp.Value*0.1;
                }
                
            }
            total = (course1marks + course2marks + course3marks) / 3;
            Console.WriteLine("total average:{0}", total);

           Console.WriteLine("Course average:{0} {1} {2} ", course1marks, course2marks, course3marks);
            //Console.WriteLine("id:{0}  name:{1} Teacher:{2} course Average:{3}   ", );
        }
        /*
        public static student NewStudent(string[] marks)
        {
            foreach (string dat in marks)
            {
                Console.WriteLine(dat);
            }
            return new student()
            {
                test_id = marks[0],
                student_id = Int32.Parse(marks[1]),
                mark = Int32.Parse(marks[2])

            };
            
        }

        public static student UpdateMarks( string[] newmarks)
        {
            
            return new student()
            {
                test_id =  newmarks[0],
                student_id = Int32.Parse(newmarks[1]),
                mark = Int32.Parse(newmarks[2])
            };
        }*/

        public static void Savetests(String input1)
        {
           //weight testweight = new weight();
            //read each line for operands
            foreach (string dat in input1.Split('\n'))
            {
                // Console.WriteLine(dat);
                if (dat != "")
                {
                    string[] datSplit = dat.Split(',');
                    string weightage = datSplit[2];
                    int ID;
                    Int32.TryParse(weightage, out ID);

                  //  testweight.
                    dict.Add(datSplit[0], ID);
                    
                    //testweight.course_id = Int32.Parse(datSplit[1]);
                    /*Console.WriteLine(ID);
                    if (!stu.Any(x => x.test_id == datSplit[0] && x.test_weight == ID))
                    {
                        // Console.WriteLine("new");
                        stu.Add(NewWeight(datSplit));
                        //Console.WriteLine("neW");
                    }
                    else if (stu.Any(x => x.test_id.Equals(datSplit[0])))
                    {
                        // Console.WriteLine("UP");
                        stu.Add(UpdateWeight(datSplit));
                        //Console.WriteLine("up");
                    }*/
                }
            }
        }
        /*
        public static student NewWeight(string[] weight)
        {
            return new student()
            {
                test_weight = Int32.Parse(weight[2]),
                course_id = Int32.Parse(weight[1]),
                test_id = weight[0]
            };
        }

        public static student UpdateWeight(string[] newweight)
        {
            return new student()
            {
                test_weight = Int32.Parse(newweight[2]),
                course_id = Int32.Parse(newweight[1]),
                test_id = newweight[0]
            };
        }*/



        public static void SaveCourses(string input3)
        {
            coursedata course = new coursedata();
            foreach (string dat in input3.Split('\n'))
            {
                // Console.WriteLine(dat);
                if (dat != "")
                {
                    string[] datSplit = dat.Split(',');
                    string weightage = datSplit[2];

                    course.course_id = Int32.Parse(datSplit[0]);
                    course.course_name = datSplit[1];
                    course.course_Teacher = datSplit[2];

                }
            }
        }
    }
}
