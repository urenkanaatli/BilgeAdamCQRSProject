using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class Performance : Attribute
    {

        /// <summary>
        /// ms
        /// </summary>
        public int Duration { get; set; }
    }
}
