using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge1
{
	public partial class MainForm : Form
	{
		DataParser parser;
		DBConnection connection;

		public MainForm()
		{
			InitializeComponent();

			parser = new DataParser();
			connection = new DBConnection();
		}

		/// <summary>
		/// Opens the file dialog and parsers the data. If this goes well we upload it to the database.
		/// </summary>
		private void UploadButton_Click(object sender, EventArgs e)
		{
			string fileString = string.Empty;
			Stream file = null;
			OpenFileDialog fileDialog = new OpenFileDialog();

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if ((file = fileDialog.OpenFile()) != null)
					{
						using (StreamReader reader = new StreamReader(file))
						{
							fileString = reader.ReadToEnd();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occured while loading your file. Original Exception: " + ex.Message);
				}
			}

			List<Entry> result = parser.ParseFile(fileString);
			foreach (Entry entry in result)
			{
				connection.AddEntry(entry);
			}

			MessageBox.Show("Data successfully added to database");
		}
	}
}
