using System.Collections.Generic;
using UnityEngine;

public class Patient : Interactable
{
    private Necessity necessity;

    private List<Item> _items;

    private void Start()
    {
        necessity = new Necessity();
        _items = necessity.GetNecessities();

        foreach (Item item in _items)
        {
            Debug.Log($"I need {item.Name}: {item.Count}");
        }
    }

    public override void Interact()
    {
        foreach (Item item in _items)
        {
            for (int i = 0; i <= item.Count; i++)
            {
                if (_player.Inventory.TryRemoveItem(item.Type))
                {
                    item.Count--;
                }
            }
        }

        List<Item> buff = new List<Item>(_items);

        for (int i = 0; i < buff.Count; i++)
        {
            if (buff[i].Count <= 0)
            {
                _items.Remove(buff[i]);
            }
        }

        if (_items.Count > 0)
        {
            foreach (Item item in _items)
            {
                Debug.Log($"I need {item.Name}: {item.Count}");
            }
        }
        else
        {
            Debug.Log("Thank you");
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _items = necessity.GetNecessities();
            foreach (Item item in _items)
            {
                Debug.Log($"I need {item.Name}: {item.Count}");
            }
        }
    }
}
