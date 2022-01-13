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
	/// A simple text input dialog.
	/// </summary>
	public class SamplesInput : System.Windows.Forms.Form {
		private System.Windows.Forms.Label descriptionText;
		private System.Windows.Forms.TextBox dataText;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public bool isOKed = false;
		public bool isCanceled = false;


		public SamplesInput() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SamplesInput));
			this.descriptionText = new System.Windows.Forms.Label();
			this.dataText = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// descriptionText
			// 
			this.descriptionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionText.Location = new System.Drawing.Point(16, 16);
			this.descriptionText.Name = "descriptionText";
			this.descriptionText.Size = new System.Drawing.Size(344, 23);
			this.descriptionText.TabIndex = 0;
			this.descriptionText.Text = "(input description)";
			this.descriptionText.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// dataText
			// 
			this.dataText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataText.Location = new System.Drawing.Point(16, 48);
			this.dataText.Name = "dataText";
			this.dataText.Size = new System.Drawing.Size(344, 20);
			this.dataText.TabIndex = 1;
			this.dataText.Text = "";
			this.dataText.KeyDown += new KeyEventHandler(this.dataText_OnKeyPress);
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(200, 80);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(288, 80);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Cancel";
			// 
			// SamplesInput
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(376, 110);
			this.ControlBox = false;
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.dataText);
			this.Controls.Add(this.descriptionText);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SamplesInput";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "(Input Title)";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Get input from the user.
		/// 
		/// Shows the window as a modal dialog, and returns the string input.
		/// Throws SamplesInputException if the user clicks Cancel instead.
		/// </summary>
		/// <param name="description">Descriptive text for the input dialog.</param>
		/// <param name="default_value">Default value (use "" if none).</param>
		/// <returns>The text input by the user.</returns>
		public string getInput( string title, string description, string default_value ) {
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
			if ( (default_value == null) || (0 == default_value.CompareTo("")) )
			{
				dataText.Text = "";
			}
			else
			{
				dataText.Text = default_value;
			}

			DialogResult result = ShowDialog();
			if( result == DialogResult.Cancel ) 
			{
				throw new SamplesInputException( "INPUT_CANCELLED_BY_USER" );
			}
			return dataText.Text;
		}

		private void okButton_Click(object sender, System.EventArgs e)
		{
			isOKed = true;
			if ( (dataText.Text == null) || (0 == dataText.Text.CompareTo("")) )
			{
				MessageBox.Show("Please enter a name for the report to be created.");
			}
			else
			{
				this.Close();
			}
		}

		private void dataText_OnKeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				okButton_Click(sender, e);
			}
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
