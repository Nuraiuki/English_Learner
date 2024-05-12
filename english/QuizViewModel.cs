
using System.Collections.Generic;

public class QuizViewModel
{
    public List<Question> QuizQuestions { get; }

    public QuizViewModel()
    {
        QuizQuestions = new List<Question>
        {


   new Question
        {
            Text = "Complete the sentence using the correct form of Perfect Tense: \"By the time I ____________ (to arrive) home, she had already left.\"",
            Answers = new List<Answer>
{
    new Answer("arrived", true),
    new Answer("have arrived", false),
    new Answer("was arriving", false)
}

        },
        new Question
        {
            Text = "Choose the correct form of the verb to complete the sentence in Perfect Tense: \"He __________ (to study) English for five years before he moved to the United States.\"",
            Answers = new List<Answer>
            {
                new Answer( "has studied",  false ),
                new Answer( "had studied",  true ),
                new Answer ( "was studying",  false )
            }
        },
        new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"Can you __________ the meaning of this word?\"",
    Answers = new List<Answer>
    {
        new Answer("look up", true),
        new Answer("look for", false),
        new Answer("look after", false)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"He needs to __________ his bad habits.\"",
    Answers = new List<Answer>
    {
        new Answer("get rid of", true),
        new Answer("get out of", false),
        new Answer("get into", false)
    }
},

new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"I need to ___________ my car before the road trip.\"",
    Answers = new List<Answer>
    {
        new Answer("fill up", true),
        new Answer("fill out", false),
        new Answer("fill in", false)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"Can you please ___________ the meeting?\"",
    Answers = new List<Answer>
    {
        new Answer("call off", true),
        new Answer("call in", false),
        new Answer("call out", false)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"She ___________ the lights before going to bed.\"",
    Answers = new List<Answer>
    {
        new Answer("turned off", true),
        new Answer("turned on", false),
        new Answer("turned out", false)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"I will ___________ with my friend tomorrow.\"",
    Answers = new List<Answer>
    {
        new Answer("catch up", true),
        new Answer("catch on", false),
        new Answer("catch out", false)
    }
},
new Question
{
    Text = "Choose the correct option to complete the sentence in Present Perfect Tense: \"I __________ (never / to be) to Australia.\"",
    Answers = new List<Answer>
    {
        new Answer("have never been", true),
        new Answer("never been", false),
        new Answer("has never been", false)
    }
},
new Question
{
    Text = "Вставьте пропущенное слово: \"I ___________ to the store yesterday.\"",
    Answers = new List<Answer>
    {
        new Answer("went", true),
        new Answer("go", false),
        new Answer("going", false)
    }
},


new Question
{
    Text = "Вставьте пропущенное слово: \"She ________ her homework every day.\"",
    Answers = new List<Answer>
    {
        new Answer("doing", false),
        new Answer("do", false),
        new Answer("does", true)
    }
},

new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"She always ___________ her homework before dinner.\"",
    Answers = new List<Answer>
    {
        new Answer("does", false),
        new Answer("makes", false),
        new Answer("finishes", true)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"Please ___________ your shoes at the door.\"",
    Answers = new List<Answer>
    {
        new Answer("put up", false),
        new Answer("take off", true),
        new Answer("bring in", false)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"I can't ___________ that song out of my head.\"",
    Answers = new List<Answer>
    {
        new Answer("shake off", false),
        new Answer("put off", false),
        new Answer("get rid of", true)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"The sun will ___________ soon.\"",
    Answers = new List<Answer>
    {
        new Answer("go out", false),
        new Answer("come out", true),
        new Answer("show up", false)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"He ___________ his car in the garage.\"",
    Answers = new List<Answer>
    {
        new Answer("parks up", false),
        new Answer("parks off", false),
        new Answer("parks in", true)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"He always ___________ his friends after work.\"",
    Answers = new List<Answer>
    {
        new Answer("hang out with", true),
        new Answer("hang up on", false),
        new Answer("hang in there", false)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"Can you ___________ the volume on the TV?\"",
    Answers = new List<Answer>
    {
        new Answer("turn down", true),
        new Answer("turn over", false),
        new Answer("turn in", false)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"She ___________ her vacation because of the bad weather.\"",
    Answers = new List<Answer>
    {
        new Answer("called off", true),
        new Answer("called in", false),
        new Answer("called out", false)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"I need to ___________ my computer to install the updates.\"",
    Answers = new List<Answer>
    {
        new Answer("log off", false),
        new Answer("log into", false),
        new Answer("log in", true)
    }
},
new Question
{
    Text = "Choose the correct phrasal verb to complete the sentence: \"He ___________ to his boss about the project.\"",
    Answers = new List<Answer>
    {
        new Answer("reported back", true),
        new Answer("reported on", false),
        new Answer("reported in", false)
    }
}
    




        };
    }
}
