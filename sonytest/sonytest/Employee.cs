using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonytest
{
    public class Employee : Observer
    {
        public String role { get; set; }

        //Writes update of machine change to console, state is machine state and from is machine name
         public void update(String state, String from)
         {
           Console.Write("Attention " + name + " " + role + "\nMachine:" + from + " is *" + state + "*\n\n");
         }
    }
    public abstract class Observer
    {
        public string name { get; set; }


        //***Although specified in UML to make two upates, I find it unnessaccary to have two the same, especially when you desire a veriable that isn't called in observer***
        //
        //public void update(String state, String from)
        //{
        //    //Console.Write("Attention " + name + "\nMachine:" + from + " is *" + state + "*\n\n");
        //}

    }
}
