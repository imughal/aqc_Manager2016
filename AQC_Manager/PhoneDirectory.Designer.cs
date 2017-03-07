namespace AQC_Manager
{
    partial class PhoneDirectory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.directoryView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.directoryView)).BeginInit();
            this.SuspendLayout();
            // 
            // directoryView
            // 
            this.directoryView.AllowUserToAddRows = false;
            this.directoryView.AllowUserToDeleteRows = false;
            this.directoryView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.directoryView.Location = new System.Drawing.Point(12, 160);
            this.directoryView.Name = "directoryView";
            this.directoryView.ReadOnly = true;
            this.directoryView.Size = new System.Drawing.Size(789, 319);
            this.directoryView.TabIndex = 0;
            // 
            // PhoneDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 491);
            this.Controls.Add(this.directoryView);
            this.Name = "PhoneDirectory";
            this.Text = "PhoneDirectory";
            this.Load += new System.EventHandler(this.PhoneDirectory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.directoryView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView directoryView;
    }
}