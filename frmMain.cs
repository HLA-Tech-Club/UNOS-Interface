using System;
using System.Windows.Forms;



namespace UNOSInterface
{

    public partial class frmMain : Form
    {
        public static string patientID;
        public frmMain()
        {
            InitializeComponent();
            ini.IniFile();
            dgvMain.DataSource = api.GetWaitlist("CCCC", "TX1", "KI");
            dgvMain.ClearSelection();
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dgvMain.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvMain.Rows[selectedrowindex];
            patientID = Convert.ToString(selectedRow.Cells["RegistrationId"].Value);
            dgvUA.Rows.Clear();
            data.fillUADgv(api.GetUA(patientID), dgvUA);
        }
    }
}
