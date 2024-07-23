using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    public override void Interact()
    {
        _player.Inventory.AddItem(ItemType.Painkillers);
    }
}
