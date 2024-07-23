using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagnostics : MonoBehaviour
{
    [SerializeField] private Stopwatch _stopwatch;

    [SerializeField] private List<Patient> _patients;

    [SerializeField] private float _breakOffset = 2.5f;
    [SerializeField] private float _waitingOffset = 5f;

    private void Start()
    {
        _stopwatch.Run();

        _stopwatch.Elapsed += OnElapsed;
    }

    private void OnElapsed(int interval)
    {
        foreach (Patient patient in _patients)
        {
            patient.MaxBreakTime -= _breakOffset;
            patient.MaxWaitingTime -= _waitingOffset;
        }
    }
}
