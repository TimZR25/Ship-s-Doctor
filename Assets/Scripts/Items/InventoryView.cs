using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    private Inventory _inventory;

    public void Inject(Inventory inventory)
    {
        _inventory = inventory;

        _inventory.Oranges.CountChanged += OnOrangesChanged;
        _inventory.Painkillers.CountChanged += OnPainkillersChanged;
    }

    private void OnOrangesChanged(int count)
    {
        Debug.Log($"Oranges: {count}");
    }

    private void OnPainkillersChanged(int count)
    {
        Debug.Log($"Painkillers: {count}");
    }
}
