using System;
using System.Collections;
using UnityEngine;

public class RotateLock : Interactable
{
    public static event Action<string, int> _Rotated = delegate {};

    [SerializeField]
    private int _currNum = 0;

    [SerializeField]
    private float _rotationSpeed = 0.001f;

    private bool _coroutineAllowed = true;

    private void Start()
    {
        transform.Rotate(0f, 0f, _currNum * -36f);
    }

    public override void Action()
    {
        if (Input.GetButton("Interact") && _coroutineAllowed)
        {
            StartCoroutine("RotateWheel");
        }
    }

    private IEnumerator RotateWheel()
    {
        _coroutineAllowed = false;

        // We set the iterations to 36, assuming that the total number of digits on a given lock is 10.
        for (int i = 0; i < 36; i++) {
            transform.Rotate(0f, 0f, -1f);
            yield return new WaitForSeconds(_rotationSpeed);
        }

        _coroutineAllowed = true;

        _currNum += 1;

        if (_currNum > 9)
        {
            _currNum = 0;
        }

        _Rotated(name, _currNum);
    }
}