using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PainClinic.Models
{
    public class StatesDictionary
    {
        public static SelectList StateSelectList
        {
            get { return new SelectList(StateDictionary, "Value", "Key"); }
        }


        public static readonly IDictionary<string, string>

           StateDictionary = new Dictionary<string, string>{

                {"Choose.....", "" },
                {"Alabama", "AL" },
                {"Alaska", "AK" },
                {"Arizona", "AZ" },
                {"Arkansas", "AR" },
                {"California", "CA" },
                {"Colorado", "CO" },
                {"Connecticut", "CT" },
                {"Delaware", "DE" },
                {"Florida", "FL" },
                {"Georgia", "GA" },
                {"Hawaii", "HI" },
                {"Idaho", "ID" },
                {"Illinois", "IL" },
                {"Indiana", "IN" },
                {"Iowa", "IA" },
                {"Kansas", "KS" },
                {"Kentucky", "KY" },
                {"Louisiana", "LA" },
                {"Maine", "ME" },
                {"Maryland", "MD" },
                {"Massachusetts", "MA" },
           };








    }
      
}

