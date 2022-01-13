/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
//  Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
//  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SamplesCommon
{
	/// <summary>
	/// A standard "About" dialog box for the samples.
	/// 
	/// You need to add an Activated event handler after creating the
	/// dialog; your event handler needs to set the applicationName
	/// and applicationVersion properties there.
	/// </summary>
	public class SamplesAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox aboutIcon;
		private System.Windows.Forms.Label appName;
		private System.Windows.Forms.Label versionText;
		private System.Windows.Forms.PictureBox line;
		private System.Windows.Forms.Label descriptionText;
		private System.Windows.Forms.Label warningLabel;
		private System.Windows.Forms.Label warningText;
		private System.Windows.Forms.Button okButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SamplesAbout()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SamplesAbout));
			this.aboutIcon = new System.Windows.Forms.PictureBox();
			this.appName = new System.Windows.Forms.Label();
			this.versionText = new System.Windows.Forms.Label();
			this.line = new System.Windows.Forms.PictureBox();
			this.descriptionText = new System.Windows.Forms.Label();
			this.warningLabel = new System.Windows.Forms.Label();
			this.warningText = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// aboutIcon
			// 
			this.aboutIcon.Image = ((System.Drawing.Image)(resources.GetObject("aboutIcon.Image")));
			this.aboutIcon.Location = new System.Drawing.Point(16, 16);
			this.aboutIcon.Name = "aboutIcon";
			this.aboutIcon.Size = new System.Drawing.Size(32, 32);
			this.aboutIcon.TabIndex = 0;
			this.aboutIcon.TabStop = false;
			// 
			// appName
			// 
			this.appName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.appName.Location = new System.Drawing.Point(64, 16);
			this.appName.Name = "appName";
			this.appName.Size = new System.Drawing.Size(208, 24);
			this.appName.TabIndex = 1;
			this.appName.Text = "(Application Name)";
			// 
			// versionText
			// 
			this.versionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.versionText.Location = new System.Drawing.Point(64, 48);
			this.versionText.Name = "versionText";
			this.versionText.Size = new System.Drawing.Size(208, 24);
			this.versionText.TabIndex = 2;
			this.versionText.Text = "(Version)";
			// 
			// line
			// 
			this.line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.line.Location = new System.Drawing.Point(8, 128);
			this.line.Name = "line";
			this.line.Size = new System.Drawing.Size(272, 4);
			this.line.TabIndex = 3;
			this.line.TabStop = false;
			// 
			// descriptionText
			// 
			this.descriptionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.descriptionText.Location = new System.Drawing.Point(64, 80);
			this.descriptionText.Name = "descriptionText";
			this.descriptionText.Size = new System.Drawing.Size(208, 40);
			this.descriptionText.TabIndex = 4;
			this.descriptionText.Text = "This application demonstrates the IBM Cognos Software Development Kit.";
			// 
			// warningLabel
			// 
			this.warningLabel.Location = new System.Drawing.Point(8, 152);
			this.warningLabel.Name = "warningLabel";
			this.warningLabel.Size = new System.Drawing.Size(56, 23);
			this.warningLabel.TabIndex = 5;
			this.warningLabel.Text = "Warning:";
			this.warningLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// warningText
			// 
			this.warningText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.warningText.Location = new System.Drawing.Point(72, 152);
			this.warningText.Name = "warningText";
			this.warningText.Size = new System.Drawing.Size(200, 32);
			this.warningText.TabIndex = 6;
			this.warningText.Text = "This application is not supported by Cognos.";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(200, 200);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 7;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// SamplesAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 238);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.warningText);
			this.Controls.Add(this.warningLabel);
			this.Controls.Add(this.descriptionText);
			this.Controls.Add(this.line);
			this.Controls.Add(this.versionText);
			this.Controls.Add(this.appName);
			this.Controls.Add(this.aboutIcon);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SamplesAbout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About this sample...";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Close the dialog when the OK button is clicked.
		/// </summary>
		/// <param name="sender">What object sent this event? (not used)</param>
		/// <param name="e">Event-specific data. (not used)</param>
		private void okButton_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		/// <summary>
		/// The application's name, as shown in the About dialog box.
		/// </summary>
		public string applicationName {
			set {
				appName.Text = value;
			}
			get {
				return appName.Text;
			}
		}

		/// <summary>
		/// The application's version string, as shown in the About dialog box.
		/// </summary>
		public string applicationVersion {
			set {
				versionText.Text = value;
			}
			get {
				return versionText.Text;
			}
		}
	}
}
