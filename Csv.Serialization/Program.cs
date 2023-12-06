using Csv.Serialization.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Csv.Serialization
{
    public class Program
	{
		/// <summary>
		/// Console Application Entry Point
		/// </summary>
		/// <param name="args">...</param>
		static void Main(string[] args)
		{
			// Serialization
			var data = GetPeople();
			using (var stream = new FileStream("persons.csv", FileMode.Create, FileAccess.Write))
			{
				var cs = new CsvSerializer<Person>()
				{
					UseTextQualifier = true,
				};
				cs.Serialize(stream, data);
			}

			// Deserialization
			IList<Person> deserializedData = null;
			using (var stream = new FileStream("persons.csv", FileMode.Open, FileAccess.Read))
			{
				var cs = new CsvSerializer<Person>()
				{
					UseTextQualifier = true,
				};

				deserializedData = cs.Deserialize(stream);
			}

			// ... display data to console
			foreach (var person in data)
			{
				Console.Write(person.ToText());
			}

			Console.WriteLine();
			Console.Write("Successfully Completed");
			Console.ReadLine();
		}


		/// <summary>
		/// Create Sample Data
		/// </summary>
		/// <returns></returns>
		private static IList<Person> GetPeople()
		{
			var employees = new List<Person>()
			{
				new Person()
				{
					Address1 = "The Club, 33 Dalgety St",
					BitFlags = 12345,
					BitMask = 0xab,
					BSB1 = "061234",
					ContactName = "Rmeov",
					ContactTitle = "Mr",
					DepartmentCode = "GT",
					DirectAccount1 = "09874578",
					DOB = DateTime.Parse("23 January, 1910"),
					eMailAddress = "django@jazzclub.com",					
					FirstName = "Django",
					Id = Guid.NewGuid(),
					LastName = "Reinhardt",					
					MobilePhone = "023984761",
					PostCode = "3000",
					State = "FR",					
					Suburb = "Bayswater",					
				},
				new Person()
				{
					Address1 = "9 Fifth Avenue",
					BitFlags = 12345,
					BitMask = 0xab,
					BSB1 = "061234",
					ContactName = "Xlot,lol",
					ContactTitle = "Ms",
					DepartmentCode = "AB",
					DirectAccount1 = "09874578",
					DOB = DateTime.Parse("23 January 1910"),
					eMailAddress = "xlot@msoft.com",					
					FirstName = "Ambere",
					Id = Guid.NewGuid(),
					LastName = "Hawkins",					
					MobilePhone = "023432761",
					PostCode = "5000",
					State = "CA",					
					Suburb = "Mermaid Beach",					
				},
		};
			return employees;
		}
	}
}