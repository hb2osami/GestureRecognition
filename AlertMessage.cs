///<summary>
///The Output defiend in our program is an AlertMessage 
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetImage
{
    class AlertMessage : Output
    {
        /// <summary>
        /// In this case we just print the result
        /// </summary>
        /// <param name="e"></param>
        public void output(string e )
        {
            Console.WriteLine(e);
        }
    }
}
