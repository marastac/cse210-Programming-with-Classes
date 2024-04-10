public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int pts) : base(name, desc, pts)
    {
        // No additional initialization needed
    }

    public override int RecordEvent()
    {
        // Eternal goal cannot be completed, just return points
        return points;
    }

    public override bool IsComplete()
    {
        // Eternal goal never completes
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {shortName} - {description}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal,{shortName},{description},{points}";
    }
}
