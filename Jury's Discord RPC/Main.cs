using System;
using System.Drawing;
using System.Windows.Forms;
using DiscordRPC;

namespace Jury_s_Discord_RPC
{

    public partial class Main : Form
    {

        public static string state;
        public static string details;
        public static string imgkey;
        public static string imgtext;
        public static string token;
        bool timestamp = false;
        public Main()
        {
            InitializeComponent();
            
            siticoneCustomGradientPanel1.MouseDown += new MouseEventHandler(MouseDown);
            siticoneCustomGradientPanel1.MouseMove += new MouseEventHandler(MouseMove);
            siticoneCustomGradientPanel1.MouseUp += new MouseEventHandler(MouseUp);
            var timer = new System.Timers.Timer(150);
            timer.Elapsed += (sender, args) =>
            {
                GC.Collect();
            };
            timer.Start();




        }

        private bool m_MousePressed = false;
        private int m_oldX, m_oldY;
        new void MouseDown(object sender, MouseEventArgs e)
        {
            Point TS = this.PointToScreen(e.Location);
            m_oldX = TS.X;
            m_oldY = TS.Y;
            m_MousePressed = true;
        }
        new void MouseUp(object sender, MouseEventArgs e)
        {
            m_MousePressed = false;
        }
        new void MouseMove(object sender, MouseEventArgs e)
        {
            // if not maximized we can move our form
            if (m_MousePressed == true)
            {
                Point TS = this.PointToScreen(e.Location);

                this.Location = new Point(this.Location.X + (TS.X - m_oldX),
                                          this.Location.Y + (TS.Y - m_oldY));
                m_oldX = TS.X;
                m_oldY = TS.Y;
            }
        }

        private void siticoneCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        public static DiscordRpcClient client;
        static void InitializeNormal()
        {

            client = new DiscordRpcClient(token);
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Assets = new Assets()
                {
                    LargeImageKey = imgkey,
                    LargeImageText = imgtext,
                }
            }); ; ;
        }
        static void InitializeTime()
        {

            client = new DiscordRpcClient(token);
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Timestamps = new Timestamps(),
                Assets = new Assets()
                {
                    LargeImageKey = imgkey,
                    LargeImageText = imgtext,
                }
            });
        }

        private void siticoneCheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            timestamp = true;
            
        }

        

        private void siticoneRoundedGradientButton1_Click(object sender, EventArgs e)
        {
            string statee = stateField.Text;
            state = statee;
            string detailss = detailsField.Text;
            details = detailss;
            string keey = imgKeyField.Text;
            imgkey = keey;
            string text = imgtextField.Text;
            imgtext = text;
            string asd = siticoneRoundedTextBox1.Text;
            token = asd;
            if (timestamp = true)
            {
                InitializeTime();
                MessageBox.Show("Discord RPC Updated!");
            }
            else
            {
                InitializeNormal();
                MessageBox.Show("Discord RPC Updated!");
            }
        }

       
    }
}
