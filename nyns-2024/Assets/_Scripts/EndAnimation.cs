using System.Collections;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    [SerializeField] Signal _endDialogue;
    [SerializeField] GameObject _siren;
    [SerializeField] Transform _endPoint;
    [SerializeField] float _swimSpeed;
    [SerializeField] RuntimeAnimatorController _swimAnim;

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
        LeanTween.rotate(_siren, new Vector3(75f, 180f, 0f), 3f).setEaseOutCubic();
        yield return new WaitForSeconds(1.5f);
        _siren.GetComponent<Animator>().runtimeAnimatorController = _swimAnim;
        LeanTween.move(_siren, _endPoint.position, _swimSpeed).setEaseOutCubic();
        this.enabled = false;
    }
}