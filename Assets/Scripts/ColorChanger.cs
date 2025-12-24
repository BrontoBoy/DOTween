using DG.Tweening;
using UnityEngine;

public class ObjectColorChanger : MonoBehaviour
{
    [SerializeField] private Color[] _colors = { Color.red, Color.blue, Color.green, Color.yellow };
    [SerializeField] private float _colorChangeDuration = 1f;
	[SerializeField] private int _infiniteLoopsValue = -1;
    
    void Start()
    {
        Material material = GetComponent<Renderer>().material;
        Sequence colorSequence = DOTween.Sequence();
        
        foreach (Color color in _colors)
        {
            colorSequence.Append(material.DOColor(color, _colorChangeDuration));
        }
        
        colorSequence.SetLoops(_infiniteLoopsValue);
    }
}