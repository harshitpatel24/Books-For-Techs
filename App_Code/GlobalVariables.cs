using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GlobalVariables
/// </summary>
namespace GlobalVariables
{
    
    public static class Globals
    {
        static int GlobalInt;
        static Globals()
        {
            GlobalInt = 1234;
        }
        public static int getGlobal()
        {
            return (GlobalInt);
        }
        public static void setGlobal(int i)
        {
            GlobalInt = i;
        }
    }
}