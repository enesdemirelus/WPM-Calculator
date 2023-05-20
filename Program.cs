using System.Timers;
using System;
using System.Diagnostics;


string[] words = File.ReadAllLines("/Users/enesdemirel/Desktop/wpm/words.txt");
string[] finalWords = new String[20];
int[] numbersArray = new int[20];
Stopwatch stopwatch = new Stopwatch();
int totalWrongWords = 0;
double totalCorrectWords = 0;

for (int i = 0; i < 20; i++)
{
    Random randomNumberGenerator = new Random();
    int randomNumber = randomNumberGenerator.Next(999);
    numbersArray.SetValue(randomNumber, i);

}

for (int i = 0; i < 20; i++)
{
    finalWords.SetValue((words[numbersArray[i]]), i);

}

string wordsInOneLine = string.Join(" ", finalWords);



Console.WriteLine("Are you ready to start? y/n (timer starts when you type 'y', and to finish you have to click enter.)");
string answerFromUser = Convert.ToString(Console.ReadLine()!);

if (answerFromUser.ToLower() == "y")
{
    stopwatch.Start();
    Console.WriteLine("---------------------------------------------------------------------------");
    Console.WriteLine(wordsInOneLine);
    Console.WriteLine("---------------------------------------------------------------------------");
    string answerOfWPM = Convert.ToString(Console.ReadLine()!);
    string[] arrayOfAnswerFromUser = answerOfWPM.Split(' ');
    string[] wrongAnswers = new String[20];


    if (arrayOfAnswerFromUser.Length == 20)
    {
        for (int i = 0; i < 20; i++)
    {

        if (arrayOfAnswerFromUser[i] == finalWords[i])
        {
            totalCorrectWords = totalCorrectWords + 1;
        }
        else
        {
            wrongAnswers.Append(arrayOfAnswerFromUser[i]);
            totalWrongWords = totalWrongWords + 1;
        }

    }

        double accurary = (totalCorrectWords / 20) * 100;
        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;
        double totalSeconds = elapsedTime.Seconds;
        double averageTimePerWord = totalSeconds / 20;
        double wpm = 60 / averageTimePerWord;
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Your Accuracy: %" + accurary);
        Console.WriteLine("Your WPM: " + wpm);
        Console.WriteLine("--------------------------------------");



    } else { 
        Console.WriteLine("You did not entered all of the words");
    }


    
}







