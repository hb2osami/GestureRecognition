///<summary>
/// abstract class to define the Output of the programm , it might be used for the robot later 
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetImage
{
    interface Output
    {
        /// <summary>
        /// the abstract method that must be define
        /// </summary>
        /// <param name="message">the message to be outputed</param>
         void output(String message) ;
    }
}
