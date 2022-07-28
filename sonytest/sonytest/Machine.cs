using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sonytest
{
    public class Machine : Subject
    {
        public string name { get; set; }
    }
    public abstract class Subject
    {
        //create list of employees/observers that can be assigned to machines
        private List<Employee> observers = new List<Employee>();
        public string state { get; set; }

        //Change the state of the machine
        public void setState(string set, string name)
        {
            state = set;
            notifyAllObservers(name);

            //updateSQL(name);  //Commented out as it will throw an error since there is nothing it will connect to.
        }

        //Attach employee to a machine
        public void attach(Employee o)
        {
            Console.Write("Attaching" + "\n\n");
            observers.Add(o);
        }

        //notify observers of a change in a machine
        public void notifyAllObservers(string name)
        {
            Console.Write("Notifying..." + "\n\n");
            foreach (var observer in observers)
            {
                observer.update(state, name);
            }
        }

        //Update SQL, this is for the web front end
        void updateSQL(string name)
        {
            //This will be used for the web front end.

            //Conncet to the sql database
            string connetionString;
            SqlConnection sqlcon;
            connetionString = @"Data Source=MySQL_Server;Initial Catalog=PlantProcess;User ID=app;Password=iamtheapp";
            sqlcon = new SqlConnection(connetionString);
            sqlcon.Open();

            //querey for updating machine state then another part for inserting a new machine incase a new machine is implimented
            //This makes it so there is no need to add it to the front end later as it will automatically add itself
            string sqlqry = "update PlantProcess.dbo.machineLiveState set state = '" + state + "' where machine = '" + name + "'\n";
            sqlqry += "IF @@ROWCOUNT = 0 \n";
            sqlqry += "insert into PlantProcess.dbo.machineLiveState (machine, state) values ('" + name + "','" + state + "')";

            //command to write querey to sql
            SqlCommand updateSQL = new SqlCommand();
            updateSQL.CommandText = sqlqry;
            updateSQL.Connection = sqlcon;
            updateSQL.ExecuteNonQuery();
            updateSQL.Dispose();
        }

    }
}