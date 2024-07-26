public class Table : Interactable
{
    public override void Interact()
    {
        _player.Inventory.AddItem(ItemType.Painkillers);
    }
}
