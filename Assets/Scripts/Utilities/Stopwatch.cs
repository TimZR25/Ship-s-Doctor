using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private Text _time;

    private float _seconds = 0;
    public float Seconds => _seconds;

    private bool _isRunning = false;

    public UnityAction<int> Elapsed;

    private int _interval = 1;

    private void Update()
    {
        Calculate();
    }

    private void Calculate()
    {
        if (_isRunning)
        {
            _seconds += Time.deltaTime;

            _time.text = ((int)_seconds).ToString();

            if (_seconds >= _interval * 30)
            {
                _interval++;
                Elapsed?.Invoke(_interval);
            }
        }
    }

    public void Run()
    {
        _isRunning = true;
    }

    public void Stop()
    {
        _isRunning = false;
    }
}
