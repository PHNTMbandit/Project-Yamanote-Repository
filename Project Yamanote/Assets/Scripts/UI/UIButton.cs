using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using ProjectYamanote.Audio;

namespace ProjectYamanote.UI
{
    public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private TextMeshProUGUI _text;
        
        private bool _toggle = false;
        
        [SerializeField] private GameObject _toggleGameObject;
        

        private void Awake()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            _text.enabled = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _text.enabled = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _text.enabled = false;
        }

        public void ClickButton()
        {
            FindObjectOfType<AudioManager>().Play("ClickButton");
        }

        public void Toggle()
        {
            if (!_toggle)
            {
                _toggleGameObject.SetActive(true);
                _toggle = true;

            }
            else
            {
                _toggleGameObject.SetActive(false);
                _toggle = false;
            }
        }
    }
}
