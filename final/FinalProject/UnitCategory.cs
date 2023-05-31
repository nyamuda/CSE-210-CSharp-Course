public class UnitCategory
{
    public string Name { get; set; }
    public List<Unit> Units = new List<Unit>();


    public UnitCategory(string name)
    {
        Name = name;
    }



}