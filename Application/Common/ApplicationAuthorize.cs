using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ApplicationAuthorize : Attribute
    {
        public string Role { get; set; }
   

    }
}
