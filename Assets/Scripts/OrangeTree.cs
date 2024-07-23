using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeTree : Interactable
{
    public override void Interact()
    {
        _player.Inventory.AddItem(ItemType.Oranges);
    }
}
