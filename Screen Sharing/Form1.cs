using RDPCOMAPILib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screen_Sharing
{
    public partial class Form1 : Form
    {
        RDPSession x = new RDPSession();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Incoming(object Guest)
        {
            IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest;//???
            MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x.OnAttendeeConnected += Incoming;
            x.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Trial", "MyGroup", "", 10);
            textBox1.Text = Invitation.ConnectionString;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            x.Close();
            x = null;
        }
    }
}
