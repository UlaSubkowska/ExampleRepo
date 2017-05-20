using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace quiz_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
                List<string> asks = new List<string>();
                List<string> answers = new List<string>();
                List<int> goodanswers = new List<int>();

                int IterationOfAnswers = 0;
                string blockOfAnswers = "";
                int number_of_good_answere = 1;

                foreach (string line in File.ReadLines(@"C:\Users\Ula\GitHub\quiz_exercise\questions.txt"))
                {
                    if (line.Contains(">"))
                    {
                        string lineOutOfFirstSign = line.Substring(1);
                        asks.Add(lineOutOfFirstSign);
                        number_of_good_answere = 1;
                    }
                    else if (line.Contains("-") || line.Contains("*"))
                    {
                        IterationOfAnswers++;
                        blockOfAnswers += line.Substring(1) + "\n";
                        int numberOfAnswersForOneAsk = 4;
                        if (IterationOfAnswers % numberOfAnswersForOneAsk == 0)
                        {
                            answers.Add(blockOfAnswers);
                            blockOfAnswers = "";
                        }
                        if (line.Contains("*"))
                            goodanswers.Add(number_of_good_answere);
                        number_of_good_answere++;
                    }
                }

                Console.WriteLine("Hello, do you want to start mountain test?\nThen press enter ;)\n" +
                    "(Please keep in mind that you should type only small letter related to ansewer you chose)");
                Console.ReadLine();

                for (int ask = 0; ask < 10; ask++)
                {
                    int user_answer_int = 0;
                    Console.WriteLine(asks[ask] + "\n" + answers[ask]);
                    string user_answer = Console.ReadLine();
                    if (user_answer == "a") { user_answer_int = 1; }
                    else if (user_answer == "b") { user_answer_int = 2; }
                    else if (user_answer == "c") { user_answer_int = 3; }
                    else if (user_answer == "d") { user_answer_int = 4; }
                    else
                    {
                        Console.WriteLine("Something went wrong try type your answer again.\n");
                        ask--;
                        continue;
                    }
                    if (user_answer_int == goodanswers[ask]) Console.WriteLine("GREAT - it's good answer\n");
                    else if (user_answer_int != goodanswers[ask])
                    {
                        Console.WriteLine("Unfortunatelly you are wrong, try again.\n");
                        ask--;
                        continue;
                    }
                };
                Console.ReadLine();
            }
        }
    }

