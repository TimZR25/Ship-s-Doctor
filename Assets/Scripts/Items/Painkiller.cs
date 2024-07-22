using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painkiller : Item
{
    public Painkiller(int count, string name) : base(count, name)
    {
        _itemType = ItemType.Painkillers;
    }
}
