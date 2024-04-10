public class ChecklistGoal : Goal
{
    private int amountCompleted;
    private int target;
    private int bonus;

    public ChecklistGoal(string name, string desc, int pts, int tgt, int bns) : base(name, desc, pts)
    {
        amountCompleted = 0;
        target = tgt;
        bonus = bns;
    }

    public override int RecordEvent()
    {
        amountCompleted++;
        if (amountCompleted >= target)
        {
            // If target completed, add bonus points
            return points + bonus;
        }
        return points;
    }

    public override bool IsComplete()
    {
        return amountCompleted >= target;
    }

    public override string GetDetailsString()
    {
        return $"[{(amountCompleted)}/{target}] {shortName} - {description}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal,{shortName},{description},{points},{amountCompleted},{target},{bonus}";
    }
}
