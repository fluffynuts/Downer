namespace Downer
{
    public class MonthItem
    {
        public int Month { get; private set; }
        public string Name { get; private set; }

        public MonthItem(int month, string name)
        {
            Name = name;
            Month = month;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}