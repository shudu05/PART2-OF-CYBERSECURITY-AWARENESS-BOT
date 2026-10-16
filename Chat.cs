using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Recording
{
    internal class Chat
    {
        private readonly Random random = new Random();

        private string name;
        private string currentTopic = "";

        private readonly Dictionary<string, string[]> tips =
            new Dictionary<string, string[]>
        {
            {
                "password",
                new string[]
                {
                    "Use a long, unique password for every account.",
                    "Never share your passwords with other people.",
                    "Use a password manager to help protect your passwords."
                }
            },
            {
                "phishing",
                new string[]
                {
                    "Check who sent an email before clicking links.",
                    "Never share personal information through suspicious links.",
                    "Look for spelling mistakes and unusual requests in emails."
                }
            },
            {
                "browsing",
                new string[]
                {
                    "Avoid suspicious websites and downloads.",
                    "Check a website address before signing in.",
                    "Keep your browser updated."
                }
            },
            {
                "privacy",
                new string[]
                {
                    "Avoid sharing your home address online.",
                    "Review your social media privacy settings.",
                    "Think carefully before posting personal information."
                }
            },
            {
                "scams",
                new string[]
                {
                    "Be careful of messages promising prizes or easy money.",
                    "Never send money because of a suspicious message.",
                    "Verify a request before sharing information or making payments."
                }
            },
            {
                "malware",
                new string[]
                {
                    "Only download files from trusted sources.",
                    "Keep your device and security software updated.",
                    "Avoid opening unexpected attachments."
                }
            }
        };

        // Constructor used by MainForm.
        public Chat(string userName)
        {
            name = string.IsNullOrWhiteSpace(userName)
                ? "Guest"
                : userName.Trim();
        }

        // The GUI calls this method when the user sends a message.
        public string GetResponse(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                return "Please type a question so I can help you.";
            }

            question = question.Trim().ToLowerInvariant();

            // --- ADDED: Greeting handlers ---
            if (question == "hello" || question == "hi" || question == "hey")
            {
                return "Hello! How are you doing today? Ready to learn about staying safe online?";
            }

            if (question.Contains("how are you"))
            {
                return "I'm doing great, thank you for asking! How are you doing? I'm ready to help you with cybersecurity anytime.";
            }

            // Remember a new name.
            if (question.StartsWith("my name is "))
            {
                string newName = question.Substring(11).Trim();

                if (newName.Length > 0)
                {
                    name = newName;
                    return "Nice to meet you, " + name;
                }

                return "Please tell me your name after 'my name is'.";
            }

            // Recognise emotions and offer support.
            if (question.Contains("worried") ||
                question.Contains("scared") ||
                question.Contains("afraid"))
            {
                string worriedTopic = FindTopic(question);

                if (worriedTopic != "")
                {
                    currentTopic = worriedTopic;

                    return "It's understandable to feel concerned about " +
                           worriedTopic + ". Here's something you can do: " +
                           GetTip(worriedTopic);
                }

                if (currentTopic != "")
                {
                    return "I understand that this can feel worrying. " +
                           "Let's take it one step at a time. " +
                           GetTip(currentTopic);
                }

                return "I understand that online safety can feel worrying. " +
                       "We can take it one step at a time. " +
                       "You can ask me about passwords, phishing, privacy or scams.";
            }

            if (question.Contains("frustrated") ||
                question.Contains("annoyed"))
            {
                return "I understand this can be frustrating. " +
                       "Take your time, and let's work through it one step at a time.";
            }

            if (question.Contains("curious") ||
                question.Contains("interested"))
            {
                return "It's great that you're curious! " +
                       "Ask me about any cybersecurity topic, and let's learn together.";
            }

            // Follow-up questions use the last topic.
            if (question.Contains("another tip") ||
                question.Contains("more tips") ||
                question.Contains("give me another"))
            {
                if (currentTopic != "")
                {
                    return "Here's another tip about " + currentTopic +
                           ": " + GetTip(currentTopic);
                }

                return "Choose a topic first: passwords, phishing, browsing, " +
                       "privacy, scams or malware.";
            }

            if (question.Contains("explain more") ||
                question.Contains("tell me more") ||
                question.Contains("more information"))
            {
                if (currentTopic != "")
                {
                    return "Let's explore " + currentTopic + " a little more. " +
                           GetTip(currentTopic);
                }

                return "Which topic would you like to explore? " +
                       "Try passwords, phishing, browsing, privacy, scams or malware.";
            }

            // General questions.
            if (question.Contains("your purpose") ||
                question.Contains("what do you do") ||
                question.Contains("who are you"))
            {
                return "I'm your Cybersecurity Awareness Bot! " +
                       "I'm here to help you learn how to stay safe online.";
            }

            if (question.Contains("what is cybersecurity") ||
                question.Contains("define cybersecurity"))
            {
                return "Cybersecurity means protecting devices, networks " +
                       "and information from digital attacks.";
            }

            // Identify a cybersecurity topic.
            string foundTopic = FindTopic(question);

            if (foundTopic != "")
            {
                currentTopic = foundTopic;
                return "Let's talk about " + currentTopic + ": " +
                       GetTip(currentTopic);
            }

            // Handle unknown messages.
            return "I'm not sure I understand that yet. " +
                   "Try asking me about passwords, phishing, browsing, " +
                   "privacy, scams or malware.";
        }

        private string FindTopic(string question)
        {
            if (question.Contains("password") ||
                question.Contains("passcode"))
                return "password";

            if (question.Contains("phishing") ||
                question.Contains("suspicious email"))
                return "phishing";

            if (question.Contains("browsing") ||
                question.Contains("website") ||
                question.Contains("browser"))
                return "browsing";

            if (question.Contains("privacy") ||
                question.Contains("personal information"))
                return "privacy";

            if (question.Contains("scam") ||
                question.Contains("fraud"))
                return "scams";

            if (question.Contains("malware") ||
                question.Contains("virus"))
                return "malware";

            return "";
        }

        private string GetTip(string topic)
        {
            if (!tips.ContainsKey(topic))
            {
                return "Please choose a cybersecurity topic I recognise.";
            }

            string[] topicTips = tips[topic];
            int number = random.Next(topicTips.Length);

            return topicTips[number];
        }
    }
}