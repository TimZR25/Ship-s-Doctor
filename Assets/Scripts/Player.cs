using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory _inventory;

    public void Inject(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _inventory.AddItem(ItemType.Oranges);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _inventory.RemoveItem(ItemType.Oranges);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _inventory.AddItem(ItemType.Painkillers);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _inventory.RemoveItem(ItemType.Painkillers);
        }
    }
}
