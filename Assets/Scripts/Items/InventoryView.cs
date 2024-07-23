using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Text _oranges;
    [SerializeField] private Text _painkillers;

    private Inventory _inventory;

    public void Inject(Inventory inventory)
    {
        _inventory = inventory;

        _inventory.Oranges.CountChanged += OnOrangesChanged;
        _inventory.Painkillers.CountChanged += OnPainkillersChanged;
    }

    private void OnOrangesChanged(int count)
    {
        _oranges.text = $"Oranges: {count}";
    }

    private void OnPainkillersChanged(int count)
    {
        _painkillers.text = $"Painkillers: {count}";
    }
}
