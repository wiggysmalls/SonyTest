using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonytest
{
    class Program
    {
        static void Main(string[] args)
        {
            createAutoBander();
            createCTM();
            createHGSU();
        }
        private static void createAutoBander()
        {
            //declare new object for machine
            Machine machine = new Machine();

            //give it a name and then a current state
            machine.name = "Auto Bander";
            machine.setState("Standby", machine.name);

            Console.Write(machine.name + " " + machine.state + "\n\n");

            //add an employee to the machine
            var newEmploy = new Employee { name = "Martin", role = "Operator" };
            machine.attach(newEmploy);

            //Change the state of machine
            machine.setState("Running", machine.name);
        }
        private static void createCTM()
        {
            Machine machine = new Machine();

            machine.name = "CTM";
            machine.setState("Straved", machine.name);

            Console.Write(machine.name + " " + machine.state + "\n\n");

            var newEmploy = new Employee { name = "Lewis", role = "Supervisor" };
            machine.attach(newEmploy);

            machine.setState("Standy", machine.name);
        }
        private static void createHGSU()
        {
            Machine machine = new Machine();

            machine.name = "HSGU";
            machine.setState("Standby", machine.name);

            Console.Write(machine.name + " " + machine.state + "\n\n");

            var newEmploy = new Employee { name = "Lewis", role = "Supervisor" };
            machine.attach(newEmploy);
            newEmploy = new Employee { name = "Martin", role = "Opp" };
            machine.attach(newEmploy);

            machine.setState("Starved", machine.name);
        }
    }
}
