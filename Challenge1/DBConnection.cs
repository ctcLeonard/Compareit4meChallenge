using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge1
{
	public class DBConnection
	{

		/// <summary>
		/// Adds entries to our database
		/// </summary>
		/// <param name="entry"></param>
		public void AddEntry(Entry entry)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\EntriesDatabase.mdf;Integrated Security=True"))
				{
					SqlCommand command = new SqlCommand("AddEntry", connection);
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.Add(new SqlParameter("@id", entry.ID));
					command.Parameters.Add(new SqlParameter("@name", entry.Name));
					command.Parameters.Add(new SqlParameter("@amount", entry.Amount));
					command.Connection.Open();
					command.ExecuteNonQuery();
				}
			}
			catch (SqlException exception)
			{
				MessageBox.Show("Could not add duplicate entries to the database");
			}
		}
	}
}
