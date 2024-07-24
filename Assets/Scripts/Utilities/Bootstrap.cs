using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InventoryView _inventoryView;

    [Header("Audio")]
    [SerializeField] private AudioLibrary _audioLibrary;
    [SerializeField] private AudioSource _musicSource;

    private Patient[] _patients;

    private void Awake()
    {
        _patients = FindObjectsByType<Patient>(FindObjectsSortMode.None);
    }

    private void Start()
    {
        Inventory inventory = new Inventory();

        _inventoryView.Inject(inventory);
        _player.Inject(inventory);

        foreach (var patient in _patients)
        {
            patient.Inject(_audioLibrary);
        }

        PlayMainTheme();
    }

    public void PlayMainTheme()
    {
        AudioSource audioSource = Instantiate(_musicSource);
        audioSource.clip = _audioLibrary.GetAudio(AudioLibrary.Names.Theme);
        audioSource.Play();
    }
}
