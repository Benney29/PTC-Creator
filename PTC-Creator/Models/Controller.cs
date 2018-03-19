using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTC_Creator.Models
{
    internal class Controller
    {
        const string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        const string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        const string PASSWORD_CHARS_NUMERIC = "23456789";
        const string PASSWORD_CHARS_SPECIAL = "*$-+?_&=!%{}/";

        public void Start()
        {
            Initiate();
        }

        public void Initiate()
        {
            List<Task> taskList = new List<Task>();
            Parallel.For(0, GlobalSettings.creatorSettings.createAmount, 
                new ParallelOptions { MaxDegreeOfParallelism = GlobalSettings.creatorSettings.threadAmount }
                , i => GetRandomAccount());
            foreach (StatusModel _ in GlobalSettings.creationBag)
            {
                GlobalSettings.creationStatus.Add(_);
            }
            GlobalSettings.createForm.StatusGridRedraw();
        }

        private void GetRandomAccount()
        {
            string username = GetUsername();
            string password = GetPassword();
            string dob = GetDob().ToString("yyyy-MM-dd");
            StatusModel _ = new StatusModel();
            _.username = username;
            _.password = password;
            _.dob = dob;
            _.email = username + "@" + GlobalSettings.creatorSettings.domain;
            _.status = CreationStatus.Waiting;
            GlobalSettings.creationBag.Add(_);
        }

        private string GetUsername()
        {
            int maxLength = 14;
            GlobalSettings.creatorSettings.username = "";
            GlobalSettings.nameGenObj.GenerateRandomFirstName().Replace(" ", "");
            string name = GlobalSettings.creatorSettings.username == "" ?
                GlobalSettings.nameGenObj.GenerateRandomFirstName().Replace(" ", "") : GlobalSettings.creatorSettings.username;

            var charSwitch = name.Select(x => GlobalSettings.random.Next() % 2 == 0 ? (char.IsUpper(x) ? x.ToString().ToLower().First() : x.ToString().ToUpper().First()) : x);
            name = new String(charSwitch.ToArray()).Replace("l", "L").Replace("I", "i").Replace("O", "o").Replace("0", "1");//Try to avoid confused words
            if (name.Length > 14) return name.Substring(0, 14);
            string randomNumber = new string(Enumerable.Repeat(PASSWORD_CHARS_NUMERIC, maxLength - name.Length)
              .Select(s => s[GlobalSettings.random.Next(s.Length)]).ToArray());
            return name + randomNumber;
        }

        private string GetPassword()
        {
            if (GlobalSettings.creatorSettings.password != "")
            {
                return GlobalSettings.creatorSettings.password;
            }
            string pass;
            pass = new string(Enumerable.Repeat(PASSWORD_CHARS_LCASE, 3)
              .Select(s => s[GlobalSettings.random.Next(s.Length)]).ToArray());
            pass += new string(Enumerable.Repeat(PASSWORD_CHARS_UCASE, 3)
              .Select(s => s[GlobalSettings.random.Next(s.Length)]).ToArray());
            pass += new string(Enumerable.Repeat(PASSWORD_CHARS_NUMERIC, 3)
              .Select(s => s[GlobalSettings.random.Next(s.Length)]).ToArray());
            pass += new string(Enumerable.Repeat(PASSWORD_CHARS_SPECIAL, 3)
              .Select(s => s[GlobalSettings.random.Next(s.Length)]).ToArray());
            return pass;
        }
        private DateTime GetDob()
        {
            DateTime start = new DateTime(1986, 1, 1);
            int range = (DateTime.Parse("1995-1-1") - start).Days;
            return start.AddDays(GlobalSettings.random.Next(range));
        }
    }
}
