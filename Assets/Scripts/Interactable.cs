using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] protected Player _player;
    public abstract void Interact();
}
