using System.Collections;
using TMPro;
using UnityEngine;

public class SmoothedTextValue : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;
    [SerializeField] private int _minValueChanges = 5;

    private Coroutine _waterfallJob;

    public void StartSmooth(TMP_Text valueField, int startValue, int targetValue, string additionalText = "")
    {
        if (gameObject.activeSelf)
        {
            if (_minValueChanges > Mathf.Abs(targetValue - startValue))
                valueField.text = additionalText + targetValue.ToString();
            else
            {
                if (_waterfallJob != null)
                    StopCoroutine(_waterfallJob);
                _waterfallJob = StartCoroutine(SmoothValue(valueField, startValue, targetValue, additionalText));
            }
        }
    }

    private IEnumerator SmoothValue(TMP_Text valueField, int startValue, int targetValue, string additionalText = "")
    {
        float lerp = 0f;

        while (lerp < _duration)
        {
            lerp += Time.deltaTime;
            valueField.text = additionalText + ((int)Mathf.Lerp(startValue, targetValue, lerp / _duration)).ToString();
            yield return new WaitForFixedUpdate();
        }

        valueField.text = additionalText + targetValue.ToString();
        _waterfallJob = null;
    }
}
