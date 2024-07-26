using UnityEngine;

public class BarrelSupplies : Interactable
{
    [SerializeField] private ItemType _itemType;

    public override void Interact()
    {
        _player.Inventory.AddItem(_itemType);
    }
}