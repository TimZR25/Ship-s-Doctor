using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BarrelSupplies : Interactable
{
    [SerializeField] private ItemType _itemType;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        _audioSource.Play();

        Item item = _player.Inventory.GetItem(_itemType);
        while (item.Count < _player.MaxItems)
        {
            _player.Inventory.AddItem(_itemType);
        }
    }
}