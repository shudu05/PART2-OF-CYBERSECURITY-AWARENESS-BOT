# 🛡️ Cybersecurity Awareness Bot

## Project Description

The Cybersecurity Awareness Bot is a C# Windows Forms desktop application that teaches users about basic cybersecurity and online safety. It provides information and tips about passwords, phishing, safe browsing, privacy, online scams, and malware.

The application uses a stylized, high-contrast dark cyberpunk graphical user interface (GUI) to make learning about cybersecurity simple, modern, and interactive.

## Project Features

- **Voice Greeting:** Plays a recorded WAV greeting when the application starts using native audio streams.
- **Dynamic Content Layout:** Built entirely programmatically inside a single form instance, providing optimized scaling, caret tracking, and a cohesive dark UI layout without designer file overhead.
- **Keyword Recognition:** Automatically parses text streams to match cybersecurity topics such as passwords, phishing, and malware.
- **Random Responses:** Utilizes specialized random index arrays to select different tips from a predefined collection so the bot does not always give the same response.
- **Conversation Flow:** Seamlessly tracks dialogue history to handle follow-up questions such as "another tip" and "explain more".
- **Memory & Metrics Tracking:** Passive state variables register user identity and dynamically calculate the user's favorite security topic based on chat history to personalize greetings on consecutive loops.
- **Sentiment Detection:** Detects simple user expressions such as "worried", "curious", and "frustrated" to adjust conversational responses empathetically.
- **Delegates Implementation:** Leverages explicit object delegate callbacks to pipe, sanitize, and format chatbot message outputs securely before UI rendering.
- **Error Handling & Edge Cases:** Safely intercepts empty text entries, unhandled inputs, or terminal flags (like "exit" and "quit") without crashing or interrupting system processing.

## Classes Used

### 1. Program Class
The `Program` class serves as the main entry runtime thread for the application. It initializes base application configurations and opens the primary `Form1` execution window loop.

### 2. Form1 Class (UI & Layout Layer)
The `Form1` class programmatically designs and maintains the entire Graphical User Interface from scratch. It builds the panels, rich textbox containers, input textboxes, action button styling, and event listeners while initializing the Task 1 background audio components.

### 3. Chat Class (Core Engine Backend)
The `Chat` class acts as the primary data processing and conversation coordinator backend. It manages key token matches, generic collection schemas, sentiment conditions, delegate initializations, metric logging, and randomized index tip retrieval.

### 4. Logo Class
The `Logo` class provides structured title and subtitle strings to maintain a neat typographic presentation across the header layers.

## Technologies Used

- C# (Object-Oriented Programming)
- .NET Framework / .NET SDK
- Windows Forms (WinForms API)
- Visual Studio IDE
- WAV Audio Processing

## Project Files

- `Program.cs` — Application initialization vector.
- `Form1.cs` — Dynamic presentation container layout and user interface.
- `Chat.cs` — Algorithmic conversation manager, delegates, collections, and state engines.
- `Logo.cs` — Visual typography configuration resource class.
- `voice/CyberSecurityAwarenessBot.wav` — Audio resource asset containing the voice greeting.
- `README.md` — Complete documentation outlining project metrics and architecture specifications.

## How to Run the Project

1. Open the project folder (`Cyber.sln`) inside **Visual Studio**.
2. Ensure the workload for **.NET Desktop Development** is installed.
3. Check that the audio file is correctly located inside the compiled `voice` directory.
4. Clean and Rebuild the solution from the top **Build** toolbar menu.
5. Press **F5** (or click the green **Start** button) to run the application on Windows.
6. Type casual greetings or explicit cybersecurity inquiries into the dark interface terminal.
7. Enter `exit` or `quit` to end the session or click the close icon.

## Example Questions

- Hello / Hi / Hey
- How are you?
- What do you remember about me?
- What is your purpose?
- What is cybersecurity?
- How can I protect my password?
- What is phishing?
- How can I browse safely?
- How can I protect my privacy?
- I'm worried about online scams.
- I'm curious about malware.
- Give me another tip.
- Explain more.

## Purpose of the Project

The purpose of this project is to promote digital safety awareness by introducing simple, actionable strategies to secure accounts, data, and communication lines. 

Architecturally, the project serves as a showcase for core advanced software principles including Object-Oriented Design (OOD), generic collection frameworks, runtime data memory state logging, programmatic graphical rendering, sentiment evaluation, and delegate function patterns.