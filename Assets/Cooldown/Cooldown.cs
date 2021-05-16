using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cooldown
{
    // Cooldown management
    private float _nextTime;
    private float _lastTime;
    public delegate void Callback();
    public event Callback IsOverEvent;

    // Public inspector setters
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool readyOnStart = true;
    [SerializeField] private bool automaticReset = true;

    public Cooldown()
    {
        if (!readyOnStart)
            this.Reset();
        this.Run();
    }


    public void Clear()
    {
        _nextTime = Time.time;
        _lastTime = Time.time;
    }
    // Automatic behaviour, callback based
    public void Run()
	{
        if (this.IsOver())
		{
            if (IsOverEvent != null)
                IsOverEvent();
            if (this.automaticReset)
                this.Reset();
		}
	}

    // Cooldown setter
    public void SetCooldown(float _time)
    {
        _lastTime = 0;
        cooldownTime = _time;
    }

    // Get elapsed time since last reset
    public float GetElapsed()
    {
        return Time.time - _lastTime;
    }

    // Get time until over
    public float TimeUntilOver()
    {
        return _nextTime - Time.time;
    }

    // Is the cooldown over
    public bool IsOver()
    {
        return Time.time >= _nextTime;
    }

    // Reset cooldown
    public void Reset()
    {
        _nextTime = Time.time + cooldownTime;
        _lastTime = Time.time;
    }
}
