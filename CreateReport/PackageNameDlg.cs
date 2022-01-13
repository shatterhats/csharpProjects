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
using SamplesCommon;
using cognosdotnet_10_2;

namespace CreateReport
{
	/// <summary>
	/// Summary description for PackageNameDlg.
	/// </summary>
	public class PackageNameDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox packageNameCB;
		public bool isOKed = false;
		public static SamplesConnect cBIServer = null;

		public PackageNameDlg()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PackageNameDlg));
			this.label1 = new System.Windows.Forms.Label();
			this.packageNameCB = new System.Windows.Forms.ComboBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please choose a package";
			// 
			// packageNameCB
			// 
			this.packageNameCB.BackColor = System.Drawing.SystemColors.Control;
			this.packageNameCB.Location = new System.Drawing.Point(16, 48);
			this.packageNameCB.Name = "packageNameCB";
			this.packageNameCB.Size = new System.Drawing.Size(344, 21);
			this.packageNameCB.TabIndex = 1;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(200, 80);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(288, 80);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// PackageNameDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 110);
			this.ControlBox = false;
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.packageNameCB);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PackageNameDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Package";
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			isOKed = true;
			this.Close();
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		public string getSelectedPackageName() 
		{
			string packageName = (string)packageNameCB.SelectedItem;
			if ( (packageName == null) || (0 == packageName.CompareTo("")) )
			{
				MessageBox.Show("Please enter a valid package name.");
			}
			return packageName;
		}

		public void setSelectedPackage(int value) 
		{
			if (packageNameCB.Items.Count >= value)
			{
				packageNameCB.SelectedIndex = value;
			}
			else
			{
				packageNameCB.SelectedIndex = 0;
			}
		}

		public void setPackageNames(string[] packageNames)
		{
			int nbPackages = packageNames.GetLength(0);
			for (int i=0; i<nbPackages; i++)
			{
				packageNameCB.Items.Add(packageNames[i]);
			}
		}

		public int getSelectedPackageIndex()
		{
			return packageNameCB.SelectedIndex;
		}

		public void setConnection(SamplesConnect connection)
		{
			cBIServer = connection;
		}
	}
}
