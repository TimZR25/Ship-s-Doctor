using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InventoryView _inventoryView;

    public void Start()
    {
        Inventory inventory = new Inventory();

        _player.Inject(inventory);
        _inventoryView.Inject(inventory);
    }
}
