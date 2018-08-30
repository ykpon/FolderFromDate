using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FolderFromDate
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string dir = Directory.GetCurrentDirectory();
            try
            {
                if(!Directory.Exists(dir + "/" + date))
                {
                    Directory.CreateDirectory(dir + "/" + date);
                }
                else
                {
                    var reg = new Regex(@"(\d{4})\.(\d{2})\.(\d{2})(\-\d+)");
                    var directories = Directory.GetDirectories(dir);
                    var matches = directories.Select(f => reg.Match(f)).Where(f => f.Success).Select(x => Convert.ToInt32(x.Value.Split('-')[1])).ToList();
                    var nextNumber = "001";
                    if(matches.Count > 0)
                    {
                        nextNumber = (matches.Max() + 1).ToString("D3");
                    }
                    Directory.CreateDirectory(dir + "/" + date + "-" + nextNumber);
                }
            } catch(Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message.ToString());
                Console.ReadLine();
            }
        }
    }
}
