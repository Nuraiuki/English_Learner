using System.Collections.Generic;

public class Question
{
    public string Text { get; set; }
    public List<Answer> Answers { get; set; }
}
public class Answer
{
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    public bool IsSelected { get; set; } // Добавленное свойство

    public Answer(string text, bool isCorrect)
    {
        Text = text;
        IsCorrect = isCorrect;
    }
}
