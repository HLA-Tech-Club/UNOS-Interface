
namespace UNOSInterface
{
    partial class frmMain
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
            this.btnRefreshWaitlist = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.dgvUA = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUA)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshWaitlist
            // 
            this.btnRefreshWaitlist.Location = new System.Drawing.Point(12, 12);
            this.btnRefreshWaitlist.Name = "btnRefreshWaitlist";
            this.btnRefreshWaitlist.Size = new System.Drawing.Size(261, 23);
            this.btnRefreshWaitlist.TabIndex = 0;
            this.btnRefreshWaitlist.Text = "Refresh Waitlist";
            this.btnRefreshWaitlist.UseVisualStyleBackColor = true;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMain.Location = new System.Drawing.Point(15, 43);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersWidth = 62;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(887, 456);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            // 
            // dgvUA
            // 
            this.dgvUA.AllowUserToAddRows = false;
            this.dgvUA.AllowUserToDeleteRows = false;
            this.dgvUA.AllowUserToResizeRows = false;
            this.dgvUA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUA.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUA.Location = new System.Drawing.Point(15, 514);
            this.dgvUA.MultiSelect = false;
            this.dgvUA.Name = "dgvUA";
            this.dgvUA.ReadOnly = true;
            this.dgvUA.RowHeadersWidth = 62;
            this.dgvUA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUA.Size = new System.Drawing.Size(887, 330);
            this.dgvUA.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 951);
            this.Controls.Add(this.dgvUA);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnRefreshWaitlist);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "frmMain";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshWaitlist;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DataGridView dgvUA;
    }
}