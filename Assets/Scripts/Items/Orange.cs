using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Item
{
    public Orange(int count, string name) : base(count, name)
    {
        _itemType = ItemType.Oranges;
    }
}
