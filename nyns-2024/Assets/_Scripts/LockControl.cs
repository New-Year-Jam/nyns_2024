using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    [SerializeField]
    private int[] _correctCombo;

    private int[] _currentCombo;

    private void Start()
    {
        _currentCombo = new int[] {0, 0, 0};
        
        RotateLock._Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "Cube1":
                _currentCombo[0] = number;
                break;
            
            case "Cube2":
                _currentCombo[1] = number;
                break;
            
            case "Cube3":
                _currentCombo[2] = number;
                break;
        }

        if (_currentCombo[0] == _correctCombo[0] && _currentCombo[1] == _correctCombo[1] && _currentCombo[2] == _correctCombo[2])
        {
            // TODO: Implement opening logic here
            Debug.Log("Opened!");
        }
    }

    private void OnDestroy()
    {
        RotateLock._Rotated -= CheckResults;
    }
}
