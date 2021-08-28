using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CodeChallenge.Web.Helpers
{
    public static class FileReader
    {
        public static string[] ReadFile(string textFilePath)
        {
            if (File.Exists(textFilePath))
            {
                return File.ReadAllLines(textFilePath);

                //foreach(var ln in lines)
                //{
                //    if (!string.IsNullOrWhiteSpace(ln) && ln.Contains(" "))
                //    {
                //        var splitLine = ln.Split(' ');

                //        var key = splitLine.FirstOrDefault();
                //        var value = splitLine.Skip(1).FirstOrDefault();

                //        creditRules[key] = value;
                //    }
                //}                
            }

            return null;
        }
    }
}