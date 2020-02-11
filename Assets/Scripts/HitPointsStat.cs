using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsStat : MonoBehaviour
{
    [SerializeField]
    private float _lerpSpeed;

    [SerializeField]
    private Slider _slider;
    //private Image _content;
    private float _currentValue;
    private float _currentFill;
    private float t = 0;

    public Gradient _gradient;
    public Image _fillImage;

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
        //_content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentFill != _slider.value)
        {
            //_content.fillAmount = Mathf.Lerp(_content.fillAmount, _currentFill - 0.1f, Time.deltaTime * _lerpSpeed);
            _slider.value = Mathf.Lerp(_slider.value, _currentValue - 0.1f, Time.deltaTime * _lerpSpeed);
            _fillImage.color = _gradient.Evaluate(_slider.normalizedValue);
        }
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = currentValue;

        _slider.maxValue = maxValue;
        _slider.value = maxValue;
    }

    public float GetLerpHitPoints()
    {
        return _slider.value;
        //return _content.fillAmount;
    }
}
