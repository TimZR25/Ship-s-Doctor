using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Item
{
    public Orange(int count) : base(count)
    {
        _type = ItemType.Oranges;
        _name = "Oranges";
    }
}
