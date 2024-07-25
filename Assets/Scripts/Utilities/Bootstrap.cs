using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private GlobalUIView _globalUIView;

    [Header("Audio")]
    [SerializeField] private AudioLibrary _audioLibrary;
    [SerializeField] private AudioSource _musicSource;

    private Patient[] _patients;

    private void Awake()
    {
        Inventory inventory = new Inventory();
        _patients = FindObjectsByType<Patient>(FindObjectsSortMode.None);
        _globalUIView.Inject(inventory, _patients);
        _player.Inject(inventory);
        
        foreach (var patient in _patients)
        {
            patient.Inject(_audioLibrary);
        }
    }

    private void Start()
    {
        PlayMainTheme();
    }

    public void PlayMainTheme()
    {
        AudioSource audioSource = Instantiate(_musicSource);
        audioSource.clip = _audioLibrary.GetAudio(AudioLibrary.Names.Theme);
        audioSource.Play();
    }
}
