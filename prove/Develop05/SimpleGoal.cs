public class SimpleGoal : Goal
{
    private bool isComplete;

    public SimpleGoal(string name, string desc, int pts) : base(name, desc, pts)
    {
        isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!isComplete)
        {
            isComplete = true;
            return points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return isComplete;
    }

    public override string GetDetailsString()
    {
        return $"[{(isComplete ? "X" : " ")}] {shortName} - {description}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal,{shortName},{description},{points},{(isComplete ? 1 : 0)}";
    }
}
