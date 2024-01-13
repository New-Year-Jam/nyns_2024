using System.Collections;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    [SerializeField] Signal _endDialogue;
    [SerializeField] GameObject _siren;
    [SerializeField] Transform _endPoint;
    [SerializeField] float _swimSpeed;

    private void Update()
    {
        if (_endDialogue.getState())
        {
            StartCoroutine("End");
        }
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(1);

        LeanTween.move(_siren, _endPoint, _swimSpeed).setEaseOutCubic();
        this.enabled = false;
    }
}