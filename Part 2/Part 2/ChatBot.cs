using System;
using System.Collections.Generic;

namespace Prog6221_Part_2_ST10457075_Thoriso_Seswai
{
    class Chatbot
    {
        // ==========================================================
        // FIELDS
        // ==========================================================

        private string userName = "User";

        private string favouriteTopic = "";

        private string currentTopic = "";

        Random random = new Random();

        // ==========================================================
        // RESPONSES DATABASE
        // QUESTION 2, 3, 8
        // ==========================================================

        private Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with numbers and symbols.",
                    "Never reuse the same password on multiple accounts.",
                    "Enable two-factor authentication for extra security.",
                    "Use passwords with at least 12 characters."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Never click suspicious email links.",
                    "Scammers often pretend to be trusted organisations.",
                    "Always verify the sender before opening attachments.",
                    "Be cautious of emails asking for personal information."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Review your privacy settings regularly.",
                    "Avoid sharing sensitive information online.",
                    "Use strong privacy settings on social media.",
                    "Be careful when using public Wi-Fi."
                }
            },

            {
                "safe browsing",
                new List<string>()
                {
                    "Only visit secure HTTPS websites.",
                    "Avoid downloading files from unknown websites.",
                    "Keep your browser updated regularly.",
                    "Install antivirus software for protection."
                }
            },

            {
                "malware",
                new List<string>()
                {
                    "Avoid downloading software from untrusted websites.",
                    "Keep your antivirus software updated.",
                    "Do not open suspicious attachments.",
                    "Scan USB devices before opening files."
                }
            }
        };

        // ==========================================================
        // PROCESS USER MESSAGE
        // ==========================================================

        public string ProcessMessage(string input)
        {
            string lower =
                input.ToLower();

            // ======================================================
            // QUESTION 5 - MEMORY
            // ======================================================

            if (lower.Contains("my name is"))
            {
                string[] words =
                    input.Split(' ');

                userName =
                    words[words.Length - 1];

                return "Nice to meet you, " +
                       userName +
                       "!";
            }

            // ======================================================
            // STORE FAVOURITE TOPIC
            // ======================================================

            if (lower.Contains("interested in"))
            {
                if (lower.Contains("privacy"))
                {
                    favouriteTopic = "privacy";

                    return "Great! I will remember that you are interested in privacy.";
                }

                if (lower.Contains("phishing"))
                {
                    favouriteTopic = "phishing";

                    return "Great! I will remember that you are interested in phishing awareness.";
                }

                if (lower.Contains("password"))
                {
                    favouriteTopic = "password";

                    return "Great! I will remember that you are interested in password safety.";
                }
            }

            // ======================================================
            // RECALL MEMORY
            // ======================================================

            if (lower.Contains("what is my favourite topic"))
            {
                if (favouriteTopic != "")
                {
                    return "Your favourite topic is " +
                           favouriteTopic +
                           ".";
                }

                return "You have not shared your favourite topic yet.";
            }

            // ======================================================
            // SENTIMENT DETECTION
            // QUESTION 6
            // ======================================================

            if (lower.Contains("worried"))
            {
                currentTopic = "phishing";

                return "It is understandable to feel worried about online scams. " +
                       "Here is a helpful tip: " +
                       GetRandomResponse("phishing");
            }

            if (lower.Contains("frustrated") ||
                lower.Contains("confused"))
            {
                return "Cybersecurity can feel confusing at first, but I will explain it simply.";
            }

            if (lower.Contains("curious"))
            {
                return "Curiosity is important because cybersecurity knowledge helps protect you online.";
            }

            // ======================================================
            // QUESTION 4 - CONVERSATION FLOW
            // ======================================================

            if (lower.Contains("tell me more") ||
                lower.Contains("another tip") ||
                lower.Contains("explain more"))
            {
                if (currentTopic != "")
                {
                    return "Here is another " +
                           currentTopic +
                           " tip: " +
                           GetRandomResponse(currentTopic);
                }

                return "Please ask about a cybersecurity topic first.";
            }

            // ======================================================
            // GREETINGS
            // ======================================================

            if (lower.Contains("hello") ||
                lower.Contains("hi"))
            {
                return "Hello " +
                       userName +
                       "! How can I help you with cybersecurity today?";
            }

            // ======================================================
            // KEYWORD RECOGNITION
            // QUESTION 2
            // ======================================================

            foreach (var topic in responses.Keys)
            {
                if (lower.Contains(topic))
                {
                    currentTopic = topic;

                    string answer =
                        GetRandomResponse(topic);

                    // PERSONALISED RESPONSE

                    if (favouriteTopic == topic)
                    {
                        answer +=
                            " Since you are interested in " +
                            topic +
                            ", you should learn more about staying safe online.";
                    }

                    return answer;
                }
            }

            // ======================================================
            // QUESTION 7 - ERROR HANDLING
            // ======================================================

            return "I am not sure I understand. Can you try rephrasing?";
        }

        // ==========================================================
        // RANDOM RESPONSE METHOD
        // QUESTION 3
        // ==========================================================

        private string GetRandomResponse(string topic)
        {
            List<string> topicResponses =
                responses[topic];

            int index =
                random.Next(topicResponses.Count);

            return topicResponses[index];
        }
    }
}


