using System.Linq;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private GlobalUIView _globalUIView;

    [Header("Audio")]
    [SerializeField] private AudioLibrary _audioLibrary;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private Diagnostics _diagnostics;

    private Patient[] _patients;
    private BarrelSupplies[] _barrelSupplies;

    private void Awake()
    {
        Inventory inventory = new Inventory();

        _patients = FindObjectsByType<Patient>(FindObjectsSortMode.None);
        _barrelSupplies = FindObjectsByType<BarrelSupplies>(FindObjectsSortMode.None);

        _globalUIView.Inject(inventory, _patients);
        _player.Inject(inventory);

        foreach (var patient in _patients)
        {
            patient.Inject(_player, _audioLibrary);
        }

        foreach (var barrelSupplies in _barrelSupplies)
        {
            barrelSupplies.Inject(_player);
        }

        _diagnostics.Inject(_patients.ToList());
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
