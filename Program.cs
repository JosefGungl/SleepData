using System;
using System.IO;

namespace SleepData
{
    class Program
    {
        static void Main(string[] args)
        {

            string file = "data.txt";

            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            if (resp == "1")
            {
                // create data file

                 // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());
                
                // determine start and end date
                DateTime today = DateTime.Now;
                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                // random number generator
                Random rnd = new Random();

                // create file
                
            

                StreamWriter sw = new StreamWriter(file);
                

                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                 if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            //get dates from .txt and convert to DateTime
                            string line = sr.ReadLine();
                            string date = line.Split(",")[0];
                            string month = date.Split("/")[0];
                            int newMonth = Int32.Parse(month);
                            string day = date.Split("/")[1];
                            int newDay = Int32.Parse(day);
                            string year = date.Split("/")[2];
                            int newYear = Int32.Parse(year);
                            var newDate = new DateTime(newYear, newMonth, newDay);
                            //output "week of..."
                            Console.WriteLine($"Week of {newDate:MMM}, {newDate:dd}, {newDate:yyyy}");

                            //get ours of sleep from .txt
                            string hours = line.Split(",")[1];
                            int mon = Int32.Parse(hours.Split("|")[0]);
                            int tues = Int32.Parse(hours.Split("|")[1]);
                            int wed = Int32.Parse(hours.Split("|")[2]);
                            int thur = Int32.Parse(hours.Split("|")[3]);
                            int fri = Int32.Parse(hours.Split("|")[4]);
                            int sat = Int32.Parse(hours.Split("|")[5]);
                            int sun = Int32.Parse(hours.Split("|")[6]);

                            //EC variables
                            int total = mon+tues+wed+thur+fri+sat+sun;
                            float avg = total / 7;
                            float avg2 = total % 7;
                            string avg3 = $"{avg}.{avg2}";
                            avg = float.Parse(avg3);



                            //output week
                            Console.WriteLine(" Mo Tu We Th Fr Sa Su Tot Avg");
                            Console.WriteLine(" -- -- -- -- -- -- -- --- ---");
                            Console.WriteLine($" {mon, 2} {tues, 2} {wed, 2} {thur, 2} {fri, 2} {sat, 2} {sun, 2} {total,3} {avg, 2}");
                            Console.WriteLine("");


                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }

            }
        }
    }