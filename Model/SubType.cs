namespace Model;

public class SubType
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid IdType { get; private set; }
    public ItemType ItemType { get; private set; }

    public SubType()
    {

    }
}