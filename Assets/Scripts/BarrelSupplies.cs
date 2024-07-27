using UnityEngine;

public class BarrelSupplies : Interactable
{
    [SerializeField] private ItemType _itemType;

    public override void Interact()
    {
        Item item = _player.Inventory.GetItem(_itemType);
        while (item.Count < _player.MaxItems)
        {
            _player.Inventory.AddItem(_itemType);
        }
    }
}