using System;

//Public class to can use in "other window"
public class EternalGoal : Goal // SimpleGoal child class of Goal
{
    //Protect class inside the propieties to not affect the working of the program (only the inherit class)
    //Protect class inside the propieties to not affect the working of the program (only the inherit class)
    //protected string _title;
    //protected string _description;
    //protected int _pointsToComplete;
    //protected List<string> _listOfGoals = new List<string>();

    //------------------ Constructors section (templates)--------------

    //The default SimpleGoal when we create (all the parameters from Goal)
    public EternalGoal(string goalName, string goalDescription, int pointsArchieved) : base(goalName, goalDescription, pointsArchieved)
    {
        //Default values
        _title = goalName;
        _description = goalDescription;
        _pointsToComplete = pointsArchieved;
    }
    //------------------ Constructors section (templates)--------------
    //-------------------------- Methods ------------------------------

    // Override auto-implemented property with ordinary property
    // to provide specialized accessor behavior.

    //Method to set this value to a list
    public override string GetGoalInformation()
    {
        return $"[ ] {_title} ({_description})";
    }

    //Add the points to the total
    public override int GetGoalCompleted(int userPoints)
    {
        GetGoalInformation();
        userPoints = userPoints + _pointsToComplete;
        return userPoints;
    }
    
    //Method to convert the object in a string (to save in an external file)
    public override string GetStringRepresentation()
    {
        return "EternalGoal:" + _title + "," + _description + "," + _pointsToComplete;
    }
}
