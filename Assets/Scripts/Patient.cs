using System.Collections.Generic;
using UnityEngine;

public class Patient : Interactable
{
    private Necessity necessity;

    private List<Item> _items;

    [SerializeField] private float _maxBreakTime = 30f;


    [SerializeField] private float _minWaitingTime = 10;
    [SerializeField] private float _maxWaitingTime = 45f;

    public float MaxBreakTime
    {
        get
        {
            return _maxBreakTime;
        }
        set
        {
            _maxBreakTime = value;
        }
    }
    public float MaxWaitingTime
    {
        get
        {
            return _maxWaitingTime;
        }
        set
        {
            _maxWaitingTime = value;
        }
    }

    private float _breakTime = 0;
    private float _waitingTime = 0;

    private float GetRandomWaitingTime => Random.Range(_minWaitingTime, _maxWaitingTime);

    private State _state;

    private void Start()
    {
        necessity = new Necessity();
        _items = necessity.GetNecessities();

        foreach (Item item in _items)
        {
            Debug.Log($"I need {item.Name}: {item.Count}");
        }

        _waitingTime = GetRandomWaitingTime;
        _state = State.Waiting;
    }

    public override void Interact()
    {
        foreach (Item item in _items)
        {
            int count = item.Count;
            for (int i = 0; i < item.Count; i++)
            {
                if (_player.Inventory.TryRemoveItem(item.Type))
                {
                    count--;
                }
            }

            item.Count = count;
        }

        List<Item> buff = new List<Item>(_items);

        for (int i = 0; i < buff.Count; i++)
        {
            if (buff[i].Count <= 0)
            {
                _items.Remove(buff[i]);
            }
        }

        if (_items.Count > 0)
        {
            foreach (Item item in _items)
            {
                Debug.Log($"I need {item.Name}: {item.Count}");
            }
        }
        else
        {
            _breakTime = _maxBreakTime;
            _state = State.Breaking;
        }
    }

    public void Update()
    {
        switch (_state)
        {
            case State.Waiting:
                if (_waitingTime >= 0)
                {
                    _waitingTime -= Time.deltaTime;
                }
                else
                {
                    _waitingTime = 0;
                    Debug.Log("You LOSE");
                    _state = State.Dead;
                }
                break;
            case State.Breaking:
                if (_breakTime > 0)
                {
                    _breakTime -= Time.deltaTime;
                }
                else
                {
                    _items = necessity.GetNecessities();
                    _waitingTime = GetRandomWaitingTime;
                    _state = State.Waiting;

                    foreach (Item item in _items)
                    {
                        Debug.Log($"I need {item.Name}: {item.Count}");
                    }
                }
                break;
            default:
                break;
        }
    }

    private enum State
    {
        Waiting, Breaking, Dead
    }
}
