using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace split_big_data
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            
            string dir = @"D:\01DELFI\DELFI\Dataiku\new-york-city-taxi-fare-prediction\train.csv";
            string dir_out = @"D:\01DELFI\DELFI\Dataiku\new-york-city-taxi-fare-prediction\train_data_split\";
            using (FileStream fs = new FileStream(dir, FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                try
                {
                    string str = null;
                    int line_seq = 0;
                    int i = 0;
                    while ((str = sr.ReadLine()) != null)
                    {
                        line_seq++;
                        if (line_seq % 50000 == 0)
                        {
                            i++;
                            //Console.WriteLine("batch + " + i);
                        }
                        using (StreamWriter writer = new StreamWriter((dir_out + "train" + i), true))
                        {
                            writer.WriteLine(str);
                            line_seq++;
                            Console.WriteLine("batch + " + i+" "+ line_seq);
                        }
                    }
                    sr.Close();
                    fs.Close();
                    
                    Console.ReadKey();
                }
                catch (Exception)
                {

                    throw;
                }

            
        }
    }
}
