using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class User
    {
        public string id { get; set; }
        public string pw { get; private set; }
        public string pwCheck { get; private set; }
        public string name { get; private set; }
        public string gender { get; private set; }
        public string year { get; private set; }
        public string month { get; private set; }
        public string day { get; private set; }

        //if click button
        public User(string id, string pw, string pwCheck, string name, string gender, string
            
            year, string month, string day)
        {
            this.id = id + "@hancomgmd.com";
            this.pw = pw;
            this.pwCheck = pwCheck;
            this.name = name;
            this.gender = gender;
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public override string ToString()
        {
            return $"ID: {id}\n" +
                $"PW: {pw}\n" +
                $"PW Check: {pwCheck}\n" +



                $"Name: {name}\n" +
                $"Gender: {gender}\n" +
                $"Birth: {year}/{month}/{day}\n";
        }
    }
}
