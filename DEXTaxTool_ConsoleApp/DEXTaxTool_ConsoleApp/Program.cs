using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Input;

namespace DEXTaxTool_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInput userInput = new ConsoleInput();
            userInput.SetUserInput();
              
        }
    }
}
