using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextEffectChanger : MonoBehaviour
{
    [SerializeField] private string[] _texts = { "Привет", "ЯЮниор!!!", "Я", "стану", "разработчиком", "на", "Unity!!!", "Наверное...", "Спасибо!!!" };
    [SerializeField] private float _typewriterDuration = 2f;
    [SerializeField] private float _pauseAfterTypewriter = 1f;
    [SerializeField] private float _pauseAfterAddition = 0.5f;
    [SerializeField] private float _pauseAfterReplacement = 1f; 
    [SerializeField] private float _clearDurationDivider = 3f;
    [SerializeField] private float _additionDelayMultiplier = 0.5f;  
    [SerializeField] private int _infiniteLoopsValue = -1; 

	private Text _text;
   
    void Start()
    {
        Text _text = GetComponent<Text>();

        if (_text == null || _texts.Length == 0) 
			return;
        
		_text.text = string.Empty;

       	float clearTextDuration = _typewriterDuration / _clearDurationDivider;
        float textAdditionDelay = _pauseAfterTypewriter * _additionDelayMultiplier;
        
        Sequence textSequence = DOTween.Sequence();
        
        for (int i = 0; i < _texts.Length - 1; i++)
        {
            textSequence.Append(_text.DOText(_texts[i], _typewriterDuration).SetEase(Ease.Linear));
            textSequence.AppendInterval(_pauseAfterTypewriter);
            textSequence.AppendCallback(() => _text.text += string.Empty);
            textSequence.AppendInterval(_pauseAfterAddition);

            int nextIndex = (i + 1) % _texts.Length;
            string nextText = _texts[nextIndex];
            
            textSequence.Append(_text.DOText(string.Empty, clearTextDuration));
            textSequence.Append(_text.DOText(nextText, _typewriterDuration).SetEase(Ease.Linear));
            textSequence.AppendInterval(_pauseAfterReplacement);
        }
        
        textSequence.SetLoops(_infiniteLoopsValue);
    }
}