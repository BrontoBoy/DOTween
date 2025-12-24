using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _duration = 1.5f;
    [SerializeField] private float _factorX = 2f;
    [SerializeField] private float _factorY = 2f;
    [SerializeField] private float _factorZ = 2f;
	[SerializeField] private int _infiniteLoopsValue = -1;
    
    void Start()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(originalScale.x * _factorX, originalScale.y * _factorY, originalScale.z * _factorZ);
        transform.DOScale(targetScale, _duration).SetEase(Ease.InOutBounce).SetLoops(_infiniteLoopsValue, LoopType.Yoyo);
    }
}