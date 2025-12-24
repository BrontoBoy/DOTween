using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _duration = 2f;
    [SerializeField] private float _angleX = 0f; 
    [SerializeField] private float _angleY = 360f;
    [SerializeField] private float _angleZ = 0f;
    [SerializeField] private int _infiniteLoopsValue = -1;
    
    void Start()
    {
        transform.DORotate(new Vector3(_angleX, _angleY, _angleZ), _duration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear).SetLoops(_infiniteLoopsValue).SetRelative(true);
    }
}