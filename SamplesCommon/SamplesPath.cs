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
	/// Simple dialog box for collecting a searchPath.
	/// </summary>
	public class SamplesPath : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox searchPathText;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SamplesPath()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Closed += new EventHandler(SamplesPath_Closed);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SamplesPath));
			this.label1 = new System.Windows.Forms.Label();
			this.searchPathText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter a Search Path:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// searchPathText
			// 
			this.searchPathText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.searchPathText.Location = new System.Drawing.Point(128, 16);
			this.searchPathText.Name = "searchPathText";
			this.searchPathText.Size = new System.Drawing.Size(232, 20);
			this.searchPathText.TabIndex = 1;
			this.searchPathText.Text = "";
			// 
			// SamplesPath
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 54);
			this.Controls.Add(this.searchPathText);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SamplesPath";
			this.Text = "Search Path";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Get or set the search path text in the dialog box.
		/// </summary>
		public string searchPath {
			get {
				return this.searchPathText.Text;
			}
			set {
				this.searchPathText.Text = value;
			}
		}

		/// <summary>
		/// This window has been closed; we need to close the owner, too.
		/// </summary>
		/// <param name="sender">Who sent this event? (not used)</param>
		/// <param name="e">Extra event arguments (not used)</param>
		private void SamplesPath_Closed(object sender, EventArgs e) {
			// If I've been closed, my owner should close, too.
			this.Owner.Close();
		}
	}
}
