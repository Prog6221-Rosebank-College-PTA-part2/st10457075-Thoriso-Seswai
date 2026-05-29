using System;
using System.Drawing;
using System.Windows.Forms;

namespace Prog6221_Part_2_ST10457075_Thoriso_Seswai
{
    public partial class Form1 : Form
    {
        // ==========================================================
        // CONTROLS
        // ==========================================================

        Label lblTitle = new Label();

        RichTextBox rtbChat = new RichTextBox();

        TextBox txtInput = new TextBox();

        Button btnSend = new Button();

        Button btnClear = new Button();

        Button btnExit = new Button();
        Chatbot bot = new Chatbot();


        // ==========================================================
        // CONSTRUCTOR
        // ==========================================================

        public Form1()
        {
            CreateGUI();

        }

        // ==========================================================
        // CREATE GUI
        // ==========================================================

        private void CreateGUI()
        {
            // FORM

            this.Text =
                "Cybersecurity Awareness Bot";

            this.Size =
                new Size(900, 600);

            this.StartPosition =
                FormStartPosition.CenterScreen;

            this.BackColor =
                Color.FromArgb(20, 20, 20);

            // ======================================================
            // TITLE LABEL
            // ======================================================

            lblTitle.Text =
                "CYBERSECURITY AWARENESS BOT";

            lblTitle.Location =
                new Point(170, 20);

            lblTitle.Size =
                new Size(600, 40);

            lblTitle.Font =
                new Font("Segoe UI", 18, FontStyle.Bold);

            lblTitle.ForeColor =
                Color.Cyan;

            // ======================================================
            // CHAT AREA
            // ======================================================

            rtbChat.Location =
                new Point(50, 80);

            rtbChat.Size =
                new Size(780, 300);

            rtbChat.BackColor =
                Color.Black;

            rtbChat.ForeColor =
                Color.Lime;

            rtbChat.Font =
                new Font("Consolas", 11);

            rtbChat.ReadOnly = true;

            // ======================================================
            // INPUT BOX
            // ======================================================

            txtInput.Location =
                new Point(50, 410);

            txtInput.Size =
                new Size(500, 35);

            txtInput.Font =
                new Font("Segoe UI", 11);

            txtInput.KeyDown +=
                txtInputKeyDown;

            // ======================================================
            // SEND BUTTON
            // ======================================================

            btnSend.Text =
                "SEND";

            btnSend.Location =
                new Point(580, 410);

            btnSend.Size =
                new Size(100, 40);

            btnSend.BackColor =
                Color.Blue;

            btnSend.Click +=
                btnSendClick;

            // ======================================================
            // CLEAR BUTTON
            // ======================================================

            btnClear.Text =
                "CLEAR";

            btnClear.Location =
                new Point(690, 410);

            btnClear.Size =
                new Size(100, 40);

            btnClear.BackColor =
                Color.DarkRed;

            btnClear.ForeColor =
                Color.White;

            btnClear.Click +=
                btnClearClick;

            // ======================================================
            // EXIT BUTTON
            // ======================================================

            btnExit.Text =
                "EXIT";

            btnExit.Location =
                new Point(580, 470);

            btnExit.Size =
                new Size(210, 40);

            btnExit.BackColor =
                Color.Gray;

            btnExit.ForeColor =
                Color.White;

            btnExit.Click +=
                btnExitClick;

            // ======================================================
            // ADD CONTROLS
            // ======================================================

            this.Controls.Add(lblTitle);

            this.Controls.Add(rtbChat);

            this.Controls.Add(txtInput);

            this.Controls.Add(btnSend);

            this.Controls.Add(btnClear);

            this.Controls.Add(btnExit);

            // ======================================================
            // WELCOME MESSAGE
            // ======================================================

            rtbChat.AppendText(
                "🤖 Welcome to the Cybersecurity Awareness Bot!\n\n");

            rtbChat.AppendText(
                "Topics:\n");

            rtbChat.AppendText(
                "• Password Safety\n");

            rtbChat.AppendText(
                "• Phishing Awareness\n");

            rtbChat.AppendText(
                "• Privacy Protection\n");

            rtbChat.AppendText(
                "• Safe Browsing\n\n");
        }

        
        // ==========================================================
        // SEND BUTTON
        // ==========================================================

    private void btnSendClick(object sender, EventArgs e)
        {
            // GET USER INPUT

            string input =
                txtInput.Text.Trim();

            // ======================================================
            // ERROR HANDLING
            // QUESTION 7
            // ======================================================

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show(
                    "Please enter a message.");

                return;
            }

            // ======================================================
            // DISPLAY USER MESSAGE
            // ======================================================

            rtbChat.AppendText(
                "👤 You: " +
                input +
                Environment.NewLine);

            // ======================================================
            // GET RESPONSE FROM CHATBOT CLASS
            // ======================================================

            string response =
                bot.ProcessMessage(input);

            // ======================================================
            // DISPLAY BOT RESPONSE
            // ======================================================

            rtbChat.AppendText(
                "🤖 Bot: " +
                response +
                Environment.NewLine +
                Environment.NewLine);

            // ======================================================
            // CLEAR INPUT BOX
            // ======================================================

            txtInput.Clear();

            // ======================================================
            // AUTO SCROLL CHAT
            // ======================================================

            rtbChat.SelectionStart =
                rtbChat.Text.Length;

            rtbChat.ScrollToCaret();

            // ======================================================
            // RETURN CURSOR TO INPUT BOX
            // ======================================================

            txtInput.Focus();
        }

        // ==========================================================
        // CLEAR BUTTON
        // ==========================================================

        private void btnClearClick(object sender, EventArgs e)
        {
            rtbChat.Clear();
        }

        // ==========================================================
        // EXIT BUTTON
        // ==========================================================

        private void btnExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ==========================================================
        // ENTER KEY SUPPORT
        // ==========================================================

        private void txtInputKeyDown(object sender,
                                     KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSendClick(sender, e);

                e.SuppressKeyPress = true;
            }
        }
    }
}


