using UnityEngine.Events;

public abstract class Item
{
    private int _count;
    public int Count
    {
        get { return _count; }
        set
        {
            _count = value;
            CountChanged?.Invoke(_count);
        }
    }

    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
        }
    }

    protected ItemType _itemType;
    public ItemType ItemType => _itemType;

    public UnityAction<int> CountChanged;

    public Item(int count, string name)
    {
        Count = count;
        Name = name;
    }
}
