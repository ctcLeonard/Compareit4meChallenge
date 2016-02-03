using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge1
{
	public class DataParser
	{

		/// <summary>
		/// Parses our file and validates the data
		/// </summary>
		public List<Entry> ParseFile(string file)
		{
			List<Entry> result = new List<Entry>();

			string[] lines = file.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < lines.Length; i++)
			{
				string[] parts = lines[i].Split(new char[] { ',' });

				string id, amount, name;
				//Validate if we have all our data
				try
				{
					id = parts[0];
					amount = parts[1];
					name = parts[2];
				}
				catch (IndexOutOfRangeException exception)
				{
					MessageBox.Show("Error occured on line " + (i + 1) + "\nOne or more of the required values is missing");
					return null;
				}

				//Validate if our data is correct
				Entry entry = new Entry();
				if (id.Length != 10)
				{
					MessageBox.Show("Error occured on line " + (i + 1) + "\nThe ID does not have a length of 10 characters");
					return null;
				}

				if (amount.IndexOfAny(new char[] { ',', '.', '-' }) > 0)
				{
					MessageBox.Show("Error occured on line " + i + 1 + "\nThe amount is not a rounded number");
					return null;
				}

				entry.ID = int.Parse(id);
				entry.Amount = int.Parse(amount);
				entry.Name = name;

				result.Add(entry);
			}

			return result;
		}
	}
}
