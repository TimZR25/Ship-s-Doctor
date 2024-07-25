using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class BarrelSupplies : Interactable
    {
        [SerializeField] private ItemType _itemType;

        public override void Interact()
        {
            _player.Inventory.AddItem(_itemType);
        }
    }
}
