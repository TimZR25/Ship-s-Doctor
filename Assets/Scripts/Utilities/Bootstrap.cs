using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InventoryView _inventoryView;

    public void Start()
    {
        Inventory inventory = new Inventory();

        _inventoryView.Inject(inventory);
        _player.Inject(inventory);
    }
}
