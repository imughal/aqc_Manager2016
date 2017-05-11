namespace AQC_Manager
{
    partial class employeesList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.employeesShow = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.viewDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.employeesShow)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // employeesShow
            // 
            this.employeesShow.AllowUserToAddRows = false;
            this.employeesShow.AllowUserToDeleteRows = false;
            this.employeesShow.AllowUserToOrderColumns = true;
            this.employeesShow.AllowUserToResizeColumns = false;
            this.employeesShow.AllowUserToResizeRows = false;
            this.employeesShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeesShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeesShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.employeesShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesShow.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.employeesShow.DefaultCellStyle = dataGridViewCellStyle2;
            this.employeesShow.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.employeesShow.Location = new System.Drawing.Point(12, 68);
            this.employeesShow.MultiSelect = false;
            this.employeesShow.Name = "employeesShow";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.employeesShow.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.employeesShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.employeesShow.Size = new System.Drawing.Size(726, 457);
            this.employeesShow.TabIndex = 0;
            this.employeesShow.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.employeesShow_CellMouseDoubleClick);
            this.employeesShow.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.employeesShow_CellMouseDown);
            this.employeesShow.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.employeesShow_RowPostPaint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewEmployeeToolStripMenuItem,
            this.editEmployeeToolStripMenuItem,
            this.viewDocumentsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 70);
            // 
            // viewEmployeeToolStripMenuItem
            // 
            this.viewEmployeeToolStripMenuItem.Name = "viewEmployeeToolStripMenuItem";
            this.viewEmployeeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.viewEmployeeToolStripMenuItem.Text = "&View Employee";
            this.viewEmployeeToolStripMenuItem.Click += new System.EventHandler(this.viewEmployeeToolStripMenuItem_Click);
            // 
            // editEmployeeToolStripMenuItem
            // 
            this.editEmployeeToolStripMenuItem.Name = "editEmployeeToolStripMenuItem";
            this.editEmployeeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.editEmployeeToolStripMenuItem.Text = "&Edit Employee";
            this.editEmployeeToolStripMenuItem.Click += new System.EventHandler(this.editEmployeeToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // viewDocumentsToolStripMenuItem
            // 
            this.viewDocumentsToolStripMenuItem.Name = "viewDocumentsToolStripMenuItem";
            this.viewDocumentsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.viewDocumentsToolStripMenuItem.Text = "View Documents";
            this.viewDocumentsToolStripMenuItem.Click += new System.EventHandler(this.viewDocumentsToolStripMenuItem_Click);
            // 
            // headerCombo
            // 
            this.headerCombo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.headerCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.headerCombo.FormattingEnabled = true;
            this.headerCombo.Location = new System.Drawing.Point(119, 12);
            this.headerCombo.Name = "headerCombo";
            this.headerCombo.Size = new System.Drawing.Size(121, 21);
            this.headerCombo.TabIndex = 4;
            // 
            // employeesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 537);
            this.Controls.Add(this.headerCombo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.employeesShow);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(766, 575);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(766, 575);
            this.Name = "employeesList";
            this.ShowInTaskbar = false;
            this.Text = "All Employees";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeesShow)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView employeesShow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDocumentsToolStripMenuItem;
        private System.Windows.Forms.ComboBox headerCombo;
    }
}