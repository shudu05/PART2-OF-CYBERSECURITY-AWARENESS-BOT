using Recording;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Cyber
{
    public partial class Form1 : Form
    {
        private Chat chat;

        private RichTextBox chatArea;
        private TextBox messageBox;
        private Button sendButton;

        private Color backgroundColor = Color.FromArgb(22, 24, 42);
        private Color purpleColor = Color.FromArgb(125, 80, 255);
        private Color cyanColor = Color.FromArgb(50, 220, 230);

        // 1. Keeps the parameterless constructor so your app launches cleanly
        public Form1()
        {
            InitializeComponent();

            string userName = "User"; // Default fallback username
            chat = new Chat(userName);

            CreateWindow();
            ShowWelcomeMessage(userName);
            PlayVoiceGreeting();
        }

        private void CreateWindow()
        {
            Text = "Cybersecurity Awareness Bot";
            Size = new Size(800, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = backgroundColor;
            ForeColor = Color.White;
            MinimumSize = new Size(600, 500);

            // Header
            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 95;
            header.BackColor = purpleColor;
            Controls.Add(header);

            Logo logo = new Logo();

            Label title = new Label();
            title.Text = logo.GetTitle();
            title.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            title.ForeColor = Color.White;
            title.Location = new Point(20, 15);
            title.AutoSize = true;
            header.Controls.Add(title);

            Label subtitle = new Label();
            subtitle.Text = logo.GetSubtitle();
            subtitle.Font = new Font("Segoe UI", 10);
            subtitle.ForeColor = Color.White;
            subtitle.Location = new Point(23, 55);
            subtitle.AutoSize = true;
            header.Controls.Add(subtitle);

            // Chat display
            chatArea = new RichTextBox();
            chatArea.Dock = DockStyle.Fill;
            chatArea.BackColor = Color.FromArgb(31, 34, 55);
            chatArea.ForeColor = Color.White;
            chatArea.Font = new Font("Segoe UI", 11);
            chatArea.ReadOnly = true;
            chatArea.BorderStyle = BorderStyle.None;
            chatArea.DetectUrls = true;
            chatArea.HideSelection = false;
            chatArea.Padding = new Padding(10);
            Controls.Add(chatArea);

            // Bottom input area
            Panel bottomPanel = new Panel();
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Height = 75;
            bottomPanel.BackColor = backgroundColor;
            Controls.Add(bottomPanel);

            messageBox = new TextBox();
            messageBox.Location = new Point(15, 18);
            messageBox.Width = 570;
            messageBox.Anchor = AnchorStyles.Left |
                                AnchorStyles.Right |
                                AnchorStyles.Top;
            messageBox.Font = new Font("Segoe UI", 11);
            messageBox.BackColor = Color.White;
            messageBox.ForeColor = Color.Black;
            bottomPanel.Controls.Add(messageBox);

            sendButton = new Button();
            sendButton.Text = "Send";
            sendButton.Location = new Point(600, 14);
            sendButton.Size = new Size(150, 38);
            sendButton.Anchor = AnchorStyles.Right |
                               AnchorStyles.Top;
            sendButton.BackColor = cyanColor;
            sendButton.ForeColor = Color.FromArgb(22, 24, 42);
            sendButton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.FlatAppearance.BorderSize = 0;
            bottomPanel.Controls.Add(sendButton);

            sendButton.Click += SendButton_Click;
            messageBox.KeyDown += MessageBox_KeyDown;

            AcceptButton = sendButton;
        }

        private void ShowWelcomeMessage(string userName)
        {
            AddMessage(
                "BOT",
                "Welcome, " + userName +
                "! Ask me about passwords, phishing, safe browsing, privacy, scams or malware.",
                purpleColor);

            AddMessage(
                "BOT",
                "You can also say 'another tip' or 'explain more'. Type 'exit' to close the bot.",
                cyanColor);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string message = messageBox.Text.Trim();

            if (message == "")
            {
                AddMessage("BOT", "Please type a message first.", cyanColor);
                return;
            }

            AddMessage("YOU", message, cyanColor);
            messageBox.Clear();

            if (message.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                message.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                AddMessage("BOT", "Goodbye! Remember to browse safely.", purpleColor);
                sendButton.Enabled = false;
                messageBox.Enabled = false;
                return;
            }

            string response = chat.GetResponse(message);
            AddMessage("BOT", response, purpleColor);
        }

        private void AddMessage(string sender, string message, Color colour)
        {
            chatArea.SelectionStart = chatArea.TextLength;
            chatArea.SelectionLength = 0;

            chatArea.SelectionColor = colour;
            chatArea.SelectionFont = new Font("Segoe UI", 11, FontStyle.Bold);
            chatArea.AppendText(sender + ": ");

            chatArea.SelectionColor = Color.White;
            chatArea.SelectionFont = new Font("Segoe UI", 11);
            chatArea.AppendText(message + Environment.NewLine + Environment.NewLine);

            chatArea.SelectionStart = chatArea.TextLength;
            chatArea.ScrollToCaret();
        }

        private void PlayVoiceGreeting()
        {
            string voicePath = Path.Combine(
                AppContext.BaseDirectory,
                "voice",
                "CyberSecurityAwarenessBot.wav");

            if (File.Exists(voicePath))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(voicePath);
                    player.Play();
                }
                catch (Exception)
                {
                    AddMessage("BOT", "The voice greeting could not be played.", cyanColor);
                }
            }
            else
            {
                AddMessage("BOT", "Voice greeting file not found. You can still use the chatbot.", cyanColor);
            }
        }

        // 2. Preserved from your visual design template file to prevent designer errors
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}