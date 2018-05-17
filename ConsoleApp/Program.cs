using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;

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
                try
                {
                    db.Database.Connection.Open(); // Abre la conexion

                    // Utilizando el Stored Procedure para crear
                    Console.WriteLine("-------> Crear Persona <-------");
                    Console.WriteLine("Ingrese el Documento");
                    string documentToAdd = Console.ReadLine();
                    Console.WriteLine("Ingrese el Nombre");
                    string nameToAdd = Console.ReadLine();
                    SqlParameter docAdd = new SqlParameter("@doc", documentToAdd);
                    SqlParameter namAdd = new SqlParameter("@name", nameToAdd);
                    db.Database.ExecuteSqlCommand("NewPerson @doc, @name", docAdd, namAdd);
                    


                    // Utilizando el Stored Procedure para modificar
                    Console.WriteLine("");
                    Console.WriteLine("-------> Modificar Persona <-------");
                    Console.WriteLine("Ingrese el Documento");
                    string documentToUpdate = Console.ReadLine();
                    Console.WriteLine("Ingrese el Nombre");
                    string nameToUpdate = Console.ReadLine();
                    SqlParameter docUpd = new SqlParameter("@doc", documentToUpdate);
                    SqlParameter namUpd = new SqlParameter("@name", nameToUpdate);
                    db.Database.ExecuteSqlCommand("UpdatePerson @doc, @name", docUpd, namUpd);


                    // Utilizando el Stored Procedure para borrar
                    Console.WriteLine("");
                    Console.WriteLine("-------> Borrar Persona <-------");
                    Console.WriteLine("Ingrese el Documento a borrar");
                    string documentToDelete = Console.ReadLine();
                    SqlParameter delP = new SqlParameter("@doc", documentToDelete);
                    db.Database.ExecuteSqlCommand("DeletePerson @doc", delP);
                    Console.WriteLine("");

                    DbDataReader reader = cmd.ExecuteReader(); // Ejecuta el Stored Procedure
                    // Leemos las Personas
                    ObjectResult<Person> people = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<Person>(reader, "people",
                        MergeOption.AppendOnly);

                    // Mostramos las personas
                    foreach (Person item in people)
                    {
                        Console.WriteLine($"{item.Document} --- {item.name}");
                    }
                    reader.Close(); // Cerramos la ejecucion del Stored Procedure
                }
                finally
                {
                    db.Database.Connection.Close(); // Cerramos la conexion
                }
                Console.ReadKey();
            }
        }
    }
}
