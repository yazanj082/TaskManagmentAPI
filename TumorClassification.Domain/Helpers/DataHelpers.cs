using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Persistence.Helpers
{
    public static class DataHelpers
    {
        public static string EncodePass(string pass)
        {
            if (String.IsNullOrEmpty(pass)) return "";
            pass += "this is my custom Secret key for authnetication";
            var result = Encoding.UTF8.GetBytes(pass);
            string res = Convert.ToBase64String(result);
            return res;

        }
    }
}