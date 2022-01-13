/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SamplesCommon
{
	/// <summary>
	/// Summary description for SamplesListInput.
	/// </summary>
	public class SamplesListInput : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label descriptionText;
		private System.Windows.Forms.ComboBox dataList;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SamplesListInput()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.descriptionText = new System.Windows.Forms.Label();
			this.dataList = new System.Windows.Forms.ComboBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// descriptionText
			// 
			this.descriptionText.Location = new System.Drawing.Point(16, 24);
			this.descriptionText.Name = "descriptionText";
			this.descriptionText.Size = new System.Drawing.Size(352, 23);
			this.descriptionText.TabIndex = 0;
			this.descriptionText.Text = "(Label Input)";
			// 
			// dataList
			// 
			this.dataList.BackColor = System.Drawing.SystemColors.Window;
			this.dataList.Location = new System.Drawing.Point(16, 48);
			this.dataList.Name = "dataList";
			this.dataList.Size = new System.Drawing.Size(344, 21);
			this.dataList.TabIndex = 1;
			this.dataList.KeyDown += new KeyEventHandler(this.dataList_OnKeyPress);
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(200, 80);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(288, 80);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// SamplesListInput
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 110);
			this.ControlBox = false;
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.dataList);
			this.Controls.Add(this.descriptionText);
			this.Name = "SamplesListInput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SamplesListInput";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public string getInput( string title, string description, string[] itemList, int selectedIndex) 
		{
			if ( (title == null) || (0 == title.CompareTo("")) )
			{
				this.Text = "";
			}
			else
			{
				this.Text = title;
			}
			if ( (description == null) || (0 == description.CompareTo("")) )
			{
				descriptionText.Text = "";
			}
			else
			{
				descriptionText.Text = description;
			}
			int nbItems = itemList.GetLength(0);
			for (int i=0; i<nbItems; i++)
			{
				dataList.Items.Add(itemList[i]);
			}

			dataList.SelectedIndex = selectedIndex;

			string dataValue = "";
			DialogResult result = ShowDialog();
			if( result == DialogResult.Cancel ) 
			{
				throw new SamplesInputException( "INPUT_CANCELLED_BY_USER" );
			}
			else if (result == DialogResult.OK )
			{
				dataValue = (string)dataList.SelectedItem;
				if ( (dataValue == null) || (0 == dataValue.CompareTo("")) )
				{
					MessageBox.Show("Invalid value selected.");
					throw new SamplesInputException( "INPUT_CANCELLED_BY_USER" );
				}
			}
			return dataValue;
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void dataList_OnKeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonOK_Click(sender, e);
			}
		}
		
		/// <summary>
		/// Exception thrown by the simple text input dialog when you click Cancel.
		/// </summary>
		public class SamplesInputException : System.Exception 
		{
			public SamplesInputException( string message )
				: base( message ) 
			{
			}
		}

	}
}
