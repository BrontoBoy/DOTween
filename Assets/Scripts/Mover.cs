using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _distance = 3f;
    [SerializeField] private float _duration = 2f;
	[SerializeField] private Vector3 _direction = new Vector3(1f, 0f, 0f);
	[SerializeField] private int _infiniteLoopsValue = -1;
    
    void Start()
    {
    	Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + _direction.normalized * _distance;
        transform.DOMove(endPosition, _duration).SetEase(Ease.InOutSine).SetLoops(_infiniteLoopsValue, LoopType.Yoyo);
    }
}