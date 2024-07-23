using System;

public class Inventory
{
    private Orange _oranges;
    public Orange Oranges => _oranges;

    private Painkiller _painkillers;
    public Painkiller Painkillers => _painkillers;

    public Inventory()
    {
        _oranges = new Orange();
        _painkillers = new Painkiller();

        _oranges.Count = 0;
        _painkillers.Count = 0;
    }

    public Item GetItem(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Oranges:
                return _oranges;
            case ItemType.Painkillers:
                return _painkillers;
            default:
                throw new NotImplementedException();
        }
    }

    public void AddItem(ItemType itemType)
    {
        Item items = GetItem(itemType);
        items.Count++;
    }

    public bool TryRemoveItem(ItemType itemType)
    {
        Item items = GetItem(itemType);
        if (items.Count > 0)
        {
            items.Count--;

            return true;
        }

        return false;
    }
}
