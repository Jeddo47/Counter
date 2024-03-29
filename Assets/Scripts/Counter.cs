using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private float _delay = 0.5f;

    private bool isRunning = false;
    private Coroutine _countCoroutine;
    private float _number = 0;

    private void Start()
    {
        _text.text = "0";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isRunning == false)
            {
                _countCoroutine = StartCoroutine(NumberCount(_delay));
                isRunning = true;
            }
            else
            {
                StopCoroutine(_countCoroutine);               
                isRunning = false;
            }
        }
    }

    private IEnumerator NumberCount(float delay)
    {
        var wait = new WaitForSeconds(delay);        

        while (true)
        {
            _number++;
            DisplayCount(_number);
            yield return wait;
        }
    }

    private void DisplayCount(float number)
    {
        _text.text = number.ToString();
    }
}
