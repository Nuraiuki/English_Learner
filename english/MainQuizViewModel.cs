using System.Collections.Generic;

public class MainQuizViewModel
{
    public List<MainQuestion> MainQuizQuestions { get; }

    public MainQuizViewModel()
    {
        MainQuizQuestions = new List<MainQuestion>
        {
            new MainQuestion
            {
                Texts = "Choose the correct phrasal verb to complete the sentence: \"Could you please _______ your shoes before entering the house?\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come in", false),
                    new MainAnswer("take off", true),
                    new MainAnswer("go on", false)
                }
            },
            new MainQuestion
            {
                Texts = "Select the appropriate phrasal verb: \"I'm sorry, I can't _______ your invitation to the party tonight.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come on", false),
                    new MainAnswer("go over", false),
                    new MainAnswer("take on", true)
                }
            },
            new MainQuestion
            {
                Texts = "Which phrasal verb fits the sentence: \"She always _______ new challenges with enthusiasm.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("comes over", false),
                    new MainAnswer("takes on", true),
                    new MainAnswer("goes off", false)
                }
            },
            new MainQuestion
            {
                Texts = "Identify the correct phrasal verb: \"Don't forget to _______ the light when you leave the room.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come in", false),
                    new MainAnswer("go off", true),
                    new MainAnswer("take on", false)
                }
            },
            new MainQuestion
            {
                Texts = "Which phrasal verb should be used: \"Can you _______ the meeting for a moment? I need to grab some water.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come on", false),
                    new MainAnswer("go over", true),
                    new MainAnswer("take off", false)
                }
            },
            new MainQuestion
            {
                Texts = "Select the appropriate phrasal verb: \"I'll _______ your offer and let you know by tomorrow.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come over", false),
                    new MainAnswer("take off", false),
                    new MainAnswer("take on", true)
                }
            },
            new MainQuestion
            {
                Texts = "Choose the correct phrasal verb to complete the sentence: \"Could you _______ the radio? It's too loud.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come in", false),
                    new MainAnswer("go off", true),
                    new MainAnswer("turn off", false)
                }
            },
            new MainQuestion
            {
                Texts = "Which phrasal verb best completes the sentence: \"We should _______ the project before the deadline.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("take on", false),
                    new MainAnswer("go over", true),
                    new MainAnswer("come on", false)
                }
            },
            new MainQuestion
            {
                Texts = "Identify the appropriate phrasal verb: \"I need to _______ some groceries on my way home.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come in", false),
                    new MainAnswer("take off", false),
                    new MainAnswer("go pick up", true)
                }
            },
            new MainQuestion
            {
                Texts = "Select the correct phrasal verb: \"Let's _______ this issue at the next team meeting.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come over", false),
                    new MainAnswer("take on", true),
                    new MainAnswer("go over", false)
                }
            },
            new MainQuestion
            {
                Texts = "Which phrasal verb fits the sentence: \"The bus will _______ at the next stop. Please prepare to exit.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come on", false),
                    new MainAnswer("take off", true),
                    new MainAnswer("go off", false)
                }
            },
            new MainQuestion
            {
                Texts = "Choose the correct phrasal verb to complete the sentence: \"Could you _______ the volume of the TV? It's too low.\"",
                MainAnswers = new List<MainAnswer>
                {
                    new MainAnswer("come in", false),
                    new MainAnswer("turn up", true),
                    new MainAnswer("go on", false)
                }
            }
        };
    }
}

public class MainQuestion
{
    public string Texts { get; set; }
    public List<MainAnswer> MainAnswers { get; set; }
}
public class MainAnswer
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    public bool IsSelected { get; set; } // Добавлено новое свойство

    public MainAnswer(string text, bool isCorrect)
    {
        Text = text;
        IsCorrect = isCorrect;
        IsSelected = false; // Устанавливаем значение по умолчанию
    }
}
