using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _interactRadius = 2f;

    private Inventory _inventory;
    public Inventory Inventory => _inventory;

    public void Inject(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void Update()
    {
        //AddRemove();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _interactRadius);

        if (colliders.Length <= 0) return;

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Interactable interactable))
            {
                interactable.Interact();
            }
        }
    }

    private void AddRemove()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _inventory.AddItem(ItemType.Oranges);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _inventory.TryRemoveItem(ItemType.Oranges);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _inventory.AddItem(ItemType.Painkillers);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _inventory.TryRemoveItem(ItemType.Painkillers);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _interactRadius);
    }
}
