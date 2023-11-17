using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop05 World!");
    }
}/*  Notes:
Eliminate duplicate code in spinner function
 Reduce the number of lines in the classes to be able to make a cleaner code
 Eliminate unnecessary or irrelevant constructors
 Add function to exceed requirements, where it shows the start time of the program (sesion) and the end time, in addition to a counter to see how much time the user is currently in session. (Line 15 and 150 of the code explain the feature)
 Add a message together the spinner to explain the behavior of it (not is a problem in the load) 
 */

using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        //Variables
        int userPoints = 0; //user's point (started with 0)
        int option = 0; //user's choose menu options (started with 0)
        //string fileName = "goals.txt";
        bool completedSimpleGoal = false; //boolean to show the first time the congratulations message
        List<Goal> listOfGoals = new List<Goal>(); //Create a list of objetcts (Necesary put <Goal> the father class to avoid problems)


        while (option != 6)
        {

            //Display the menu
            Console.WriteLine();
            Console.WriteLine($"You have {userPoints} points.");
            Console.WriteLine();
            Console.WriteLine("[1] Create a New Goal");
            Console.WriteLine("[2] List Goals");
            Console.WriteLine("[3] Save Goals");
            Console.WriteLine("[4] Load Goals");
            Console.WriteLine("[5] Record Event");
            Console.WriteLine("[6] Quit");
            Console.Write("Select a choice from the menu: ");
            option = int.Parse(Console.ReadLine());


            switch (option)
            {
                //---- If the user decide to "[1] Create a New Goal" -----
                case 1:
                    Console.Clear();
                    Console.WriteLine("The type of Goals are: ");
                    Console.WriteLine("[1] Simple Goal");
                    Console.WriteLine("[2] Eternal Goal ");
                    Console.WriteLine("[3] Checklist Goal ");
                    Console.Write("Which type of goal would you like to create? ");
                    int goalOption = int.Parse(Console.ReadLine());
                    switch (goalOption)
                    {
                        //-------------- [1] Simple Goal ----------------
                        case 1:
                            Console.Clear();
                            //Get the values of the goal from the user
                            Console.Write("What is the name of your goal? ");
                            string simpleGoalName = Console.ReadLine();
                            Console.Write("What is a short description of it? ");
                            string simpleGoalDescription = Console.ReadLine();
                            Console.Write("What is the amount assosiated to this goal? ");
                            int simpleGoalPoints = int.Parse(Console.ReadLine());
                            //Create the object and add the values got from the user
                            bool finished = false;
                            SimpleGoal simpleGoal = new(simpleGoalName, simpleGoalDescription, simpleGoalPoints, finished);
                            //Add to the list
                            listOfGoals.Add(simpleGoal);
                            break;
                        //------------- [1] Simple Goal - End ------------
                        //-------------- [2] Eternal Goal ----------------
                        case 2:
                            Console.Clear();
                            //Get the values of the goal from the user
                            Console.Write("What is the name of your goal? ");
                            string eternalGoalName = Console.ReadLine();
                            Console.Write("What is a short description of it? ");
                            string eternalGoalDescription = Console.ReadLine();
                            Console.Write("What is the amount assosiated to this goal? ");
                            int eternalGoalPoints = int.Parse(Console.ReadLine());
                            //Create the object and add the values got from the user
                            EternalGoal eternalGoal = new(eternalGoalName, eternalGoalDescription, eternalGoalPoints);
                            //Add to the list
                            listOfGoals.Add(eternalGoal);
                            break;
                        //----------- [2] Eternal Goal - End -------------
                        //------------ [3] Checklist Goal ----------------
                        case 3:
                            Console.Clear();
                            //Get the values of the goal from the user
                            Console.Write("What is the name of your goal? ");
                            string checklistGoalName = Console.ReadLine();
                            Console.Write("What is a short description of it? ");
                            string checklistGoalDescription = Console.ReadLine();
                            Console.Write("What is the amount assosiated to this goal? ");
                            int checklistGoalPoints = int.Parse(Console.ReadLine());
                            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                            int checklistVerificationCounter = int.Parse(Console.ReadLine());
                            Console.Write("What is the bonus for accomplish at that many times? ");
                            int checklistBonusGoalCompleted = int.Parse(Console.ReadLine());
                            //Counter always start in 0                            
                            int checkListCounter = 0;
                            //Create the object and add the values got from the user
                            CheckListGoal checklistGoal = new(checklistGoalName, checklistGoalDescription, checklistGoalPoints, checklistVerificationCounter, checklistBonusGoalCompleted, checkListCounter);
                            //Add to the list
                            listOfGoals.Add(checklistGoal);
                            break;
                        //---------- [3] Checklist Goal - End ------------

                        default:
                            Console.Clear();
                            Console.WriteLine("Wrong. Please choose another option.");
                            break;
                    }
                    break;
                //------------ "[1] Create a New Goal" - end ------------ 



                //------------------ "[2] List Goal"  ------------------- 
                case 2:
                    Console.Clear();
                    Console.WriteLine("The goals are: ");
                    Console.WriteLine();
                    //Show all the elements in the list
                    int count = 1; //Counter to put an index
                    foreach (var goal in listOfGoals)
                    {
                        Console.WriteLine(count + ". " + goal.GetGoalInformation());
                        count++;
                    }
                    break;
                //--------------- "[2] List Goal" - End ----------------- 



                //------------------ "[3] Save Goals"  ------------------- 
                case 3:
                    Console.Clear();
                    Console.Write("What is the filename for the goal file? ");
                    string fileName = Console.ReadLine();
                    using (StreamWriter outputFile = new StreamWriter(fileName))
                    {
                        // You can add userPoints in the moment
                        outputFile.WriteLine(userPoints);

                        //For each goal inside the list, save a line with different formats(override in the class)
                        foreach (var goal in listOfGoals)
                        {
                            outputFile.WriteLine(goal.GetStringRepresentation());
                        }
                    }
                    break;
                //------------------ "[3] Save Goals"- End --------------- 



                //------------------ "[4] Load Goals"  ------------------- 
                case 4:
                    Console.Clear();
                    Console.Write("What is the filename for the goal file? ");
                    fileName = Console.ReadLine();
                    //Load all the lines in the file
                    string[] linesInFile = System.IO.File.ReadAllLines(fileName);
                    //Charge the userpoints from the file and add to the currently points
                    string firstLine = linesInFile[0];
                    userPoints = int.Parse(firstLine);

                    List<Goal> tempList = new List<Goal>();
                    for (int i = 0; i < linesInFile.Length; i++)
                    {

                        //That affect all the lines expect the first (because the first is the userpoints)
                        if (i != 0)
                        {
                            //Divide in parts the line of the file
                            var parts = linesInFile[i].Split(':')[1].Split(',');

                            //When the line start with "SimpleGoal" create a new SimpleGoal and add to the list
                            if (linesInFile[i].StartsWith("SimpleGoal:"))
                            {
                                SimpleGoal simpleGoal = new(parts[0], parts[1], int.Parse(parts[2]), bool.Parse(parts[3]));
                                tempList.Add(simpleGoal);
                                //If the title exist in the list, replace that
                                if (!tempList.Any(goal => goal.GetGoalName() == simpleGoal.GetGoalName()))
                                {
                                    tempList.Add(simpleGoal);
                                }

                            }
                            //When the line start with "EternalGoal" create a new SimpleGoal and add to the list
                            else if (linesInFile[i].StartsWith("EternalGoal:"))
                            {
                                EternalGoal eternalGoal = new(parts[0], parts[1], int.Parse(parts[2]));

                                //If the title exist in the list, replace that
                                if (!tempList.Any(goal => goal.GetGoalName() == eternalGoal.GetGoalName()))
                                {
                                    tempList.Add(eternalGoal);
                                }
                            }
                            //When the line start with "EternalGoal" create a new SimpleGoal and add to the list
                            else if (linesInFile[i].StartsWith("CheckListGoal:"))
                            {
                                CheckListGoal checkListGoal = new(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                                tempList.Add(checkListGoal);
                                //If the title exist in the list, replace that
                                if (!tempList.Any(goal => goal.GetGoalName() == checkListGoal.GetGoalName()))
                                {
                                    tempList.Add(checkListGoal);
                                }
                            }
                        }

                    }
                    //Change the value to the listOfGoals
                    listOfGoals = tempList;
                    break;
                //------------------ "[4] Load Goals"- End --------------- 



                //------------------ "[5] Record Event" ------------------
                case 5:
                    Console.Clear();
                    Console.Write("Which is the goal you accomplish? ");
                    int numberToDelete = int.Parse(Console.ReadLine());
                    //Rest 1 because the List start with 0 not 1
                    int indexToDelete = numberToDelete - 1;
                    //Search that in the List
                    if (indexToDelete >= 0 && indexToDelete < listOfGoals.Count)
                    {
                        //Create a object to manipulate
                        Goal goalToDelete = listOfGoals[indexToDelete];

                        //If the goal searched is a SimpleGoal
                        if (goalToDelete is SimpleGoal)
                        {
                            
                            userPoints = ((SimpleGoal)goalToDelete).GetGoalCompleted(userPoints);
                            if (completedSimpleGoal == false)
                            {
                                //The first time record
                                Console.WriteLine($"Congratulations! You have earned {goalToDelete.GetGoalPoints()} points!");
                                Console.WriteLine($"You now have {userPoints} points.");
                                completedSimpleGoal = true;
                            }

                        }
                        //If the goal searched is a EternalGoal
                        if (goalToDelete is EternalGoal)
                        {
                            userPoints = ((EternalGoal)goalToDelete).GetGoalCompleted(userPoints);
                            Console.WriteLine($"Congratulations! You have earned {goalToDelete.GetGoalPoints()} points!");

                        }
                        //If the goal searched is a CheckListGoal
                        if (goalToDelete is CheckListGoal)
                        {
                            userPoints = ((CheckListGoal)goalToDelete).GetGoalCompleted(userPoints);
                            if (!goalToDelete.GetGoalInformation().StartsWith("[X]"))
                            {
                                //Repeat until the currentGoal is the same like the finalGoal
                                Console.WriteLine($"Congratulations! You have earned {goalToDelete.GetGoalPoints()} points!");
                                Console.WriteLine($"You now have {userPoints} points.");
                            }
                            else
                            {

                            }

                        }

                        listOfGoals.RemoveAt(indexToDelete);
                        listOfGoals.Insert(indexToDelete, goalToDelete);

                        Console.WriteLine();
                    }
                    break;
                //------------------ "[5] Record Event" - End -----------



                //------------------ "[6] Quit"  ------------------------ 
                case 6:
                    break;
                //------------------ "[6] Quit" - End ------------------- 


                //Default case (when the user wrong) 
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong. Please choose another option.");
                    break;
            }

        }
    }
}