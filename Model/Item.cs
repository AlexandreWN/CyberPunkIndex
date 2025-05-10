namespace Model;

public class Item
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Decimal Price { get; private set; }
    public string Source { get; private set; }

    public Guid IdCategory { get; private set; }
    public Guid IdSubType { get; private set; }
    public Guid IdProducer { get; private set; }

    public Category Category { get; private set; }
    public SubType SubType { get; private set; }
    public Producer Producer { get; private set; }

    public Item()
    {

    }
}