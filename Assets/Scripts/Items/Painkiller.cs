using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painkiller : Item
{
    public Painkiller(int count) : base(count)
    {
        _type = ItemType.Painkillers;
        _name = "Painkillers";
    }
}
