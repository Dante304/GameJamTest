using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsStat : MonoBehaviour
{
    [SerializeField]
    private float _lerpSpeed;

    private Image _content;
    private float _currentValue;
    private float _currentFill;
    private float t = 0;

    public float MaxValue { get; set; }

    public float CurrentValue
    {
        get => _currentValue;
        set
        {
            if (value > MaxValue)
                value = MaxValue;

            if (value < 0)
                value = 0;

            _currentValue = value;
            _currentFill = value / MaxValue;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentFill != _content.fillAmount)
        {
            _content.fillAmount = Mathf.Lerp(_content.fillAmount, _currentFill - 0.1f, Time.deltaTime * _lerpSpeed);
            //t += Time.deltaTime * _lerpSpeed;
        }
        //if (t > 1.0f)
            //t = 0f;
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = currentValue;
    }

    public float GetLerpHitPoints()
    {
        return _content.fillAmount;
    }
}
