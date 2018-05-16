using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (PersonContext db = new PersonContext())
            {
                db.Database.Initialize(force: false);

                // Crear comando para ejecutar el Stored Procedure
                DbCommand cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "[dbo].[GetAllPeople]";
            }
        }
    }
}
