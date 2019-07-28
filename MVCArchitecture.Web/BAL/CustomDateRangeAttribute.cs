using System;
using System.ComponentModel.DataAnnotations;

namespace MVCArchitecture.Web.BAL
{
    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute()
        : base(typeof(DateTime), new DateTime(1950, 1, 1).ToShortDateString(), DateTime.Now.ToShortDateString()) { }
    }
}