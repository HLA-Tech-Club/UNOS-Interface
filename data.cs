using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNOSInterface
{
    class data
    {
        #region waitlist
        public class Waitlist
        {
            public int BirthSexId { get; set; }
            public bool BloodTypeVerificationPending { get; set; }
            public string CenterPatientId { get; set; }
            public DateTime DateOfBirth { get; set; }
            public List<object> EthnicityRace { get; set; }
            public string FirstName { get; set; }
            public bool HasParentRegistration { get; set; }
            public string LastName { get; set; }
            public string ListingCenterCode { get; set; }
            public string ListingCenterType { get; set; }
            public DateTime ListingDateUsedByMatchUtc { get; set; }
            public int MedicalUrgencyStatusId { get; set; }
            public DateTime RegistrationAddDateUtc { get; set; }
            public int RegistrationId { get; set; }
            public int RegistrationInactiveReasonId { get; set; }
            public string RegistrationOrganCode { get; set; }
            public bool Removed { get; set; }
            public string SocialSecurityNumber { get; set; }
            public string VerifiedBloodTypeCode { get; set; }
        }

        public class WaitlistRoot
        {
            public List<Waitlist> Value { get; set; }
            public List<object> ValidationResults { get; set; }
        }
#endregion

        #region UA

        public class UA 
        {
            public bool AntibodiesDetected { get; set; }
            public bool AntibodiesTested { get; set; }
            public int CpraPercentScore { get; set; }
            public double CpraScore { get; set; }
            public IList<int> UnacceptableAntigensA { get; set; }
            public IList<int> UnacceptableAntigensB { get; set; }
            public IList<object> UnacceptableAntigensBW { get; set; }
            public IList<int> UnacceptableAntigensC { get; set; }
            public IList<object> UnacceptableAntigensDPB1 { get; set; }
            public IList<object> UnacceptableAntigensDQA1 { get; set; }
            public IList<int> UnacceptableAntigensDQB1 { get; set; }
            public IList<int> UnacceptableAntigensDR { get; set; }
            public IList<int> UnacceptableAntigensDR51 { get; set; }
            public IList<object> UnacceptableAntigensDR52 { get; set; }
            public IList<object> UnacceptableAntigensDR53 { get; set; }

        }

        public class UARoot
        {
            public IList<object> ValidationResults { get; set; }
            public UA Value { get; set; }
        }

        public static void fillUADgv(UA uas, DataGridView dgv)
        {
            List<string> A = new List<string>();
            List<string> B = new List<string>();
            List<string> Bw = new List<string>();
            List<string> C = new List<string>();
            List<string> DR = new List<string>();
            List<string> DRw = new List<string>();
            List<string> DQB = new List<string>();
            List<string> DQA = new List<string>();
            List<string> DPB = new List<string>();
            //List<string> DPA = new List<string>();
            foreach (var ab in uas.UnacceptableAntigensA)
            {
                A.Add("A" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensB)
            {
                B.Add("B" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensBW)
            {
                Bw.Add("Bw" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensC)
            {
                C.Add("C" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensDR)
            {
                DR.Add("DR" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensDR51)
            {
                DRw.Add("DR" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensDR52)
            {
                DRw.Add("DR" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensDR53)
            {
                DRw.Add("DR" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensDQB1)
            {
                DQB.Add("DQ" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensDQA1)
            {
                DQA.Add("DQA1*" + ab);
            }
            foreach (var ab in uas.UnacceptableAntigensDPB1)
            {
                DPB.Add("DP" + ab);
            }
            //foreach (var ab in uas.UnacceptableAntigensDPA1)
            //{
             //   DPA.Add("DPA1*" + ab);
            //}

            //set your count of columns here
            dgv.ColumnCount = 2;

            // Assign your columns
            dgv.Columns[0].Name = "Locus";
            dgv.Columns[1].Name = "Antibodies";

            // Add your rows here    
            dgv.Rows.Add("A", String.Join(", ", A.ToArray()));
            dgv.Rows.Add("B", String.Join(", ", B.ToArray()));
            dgv.Rows.Add("Bw", String.Join(", ", Bw.ToArray()));
            dgv.Rows.Add("C", String.Join(", ", C.ToArray()));
            dgv.Rows.Add("DR", String.Join(", ", DR.ToArray()));
            dgv.Rows.Add("DR51/52/53", String.Join(", ", DRw.ToArray()));
            dgv.Rows.Add("DQB1", String.Join(", ", DQB.ToArray()));
            dgv.Rows.Add("DQA1", String.Join(", ", DQA.ToArray()));
            dgv.Rows.Add("DPB1", String.Join(", ", DPB.ToArray()));
            //dgv.Rows.Add("DPA1", String.Join(", ", DPA.ToArray()));
            //dgv.Rows.Add("A", String.Join(", ", A.ToArray()));
            //DataGridViewRow row = (DataGridViewRow)dgv.Rows[0].Clone();
            //row.Cells["Column2"].Value = "A";
            //row.Cells["Column6"].Value = String.Join(", ", A.ToArray()); 
            //dgv.Rows.Add(row);

        }

#endregion

        #region TOKENS
        public class PasswordTokenValue
        {
            public string AccessToken { get; set; }
            public int ExpiresIn { get; set; }
            public string IssuedAt { get; set; }
            public string RefreshToken { get; set; }
            public string RefreshTokenExpiresIn { get; set; }
            public string RefreshTokenIssuedAt { get; set; }
            public string RefreshTokenStatus { get; set; }
            public string TokenType { get; set; }
            public string Scope { get; set; }
        }

        public class PasswordTokenRoot
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string refresh_token { get; set; }
            public string token_type { get; set; }
            public string scope { get; set; }
            public IList<object> ValidationResults { get; set; }
            public PasswordTokenValue Value { get; set; }
        }
#endregion

    }
}
