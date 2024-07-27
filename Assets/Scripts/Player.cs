using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _interactRadius = 2f;

    [SerializeField] private int _maxItems = 6;
    public int MaxItems => _maxItems;

    private Inventory _inventory;
    public Inventory Inventory => _inventory;


    public void Inject(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _interactRadius);
    }
}
