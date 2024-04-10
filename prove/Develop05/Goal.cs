public abstract class Goal
{
    protected string shortName;
    protected string description;
    protected int points;

    public string ShortName => shortName;

    public Goal(string name, string desc, int pts)
    {
        shortName = name;
        description = desc;
        points = pts;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
