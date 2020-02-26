using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

namespace Assets.Scripts.Views.Game.BetView
{
    public class BetsView : MonoBehaviour, IBetsView
    {
        [SerializeField]
        private Button [] _Buttons;

        [SerializeField]
        private TextMeshProUGUI _BetName;

        private IBetView[] _betViews;

        private event Action _onClick;

        private void Start()
        {
            InitBetViews();

            for (int i = 0; i < _Buttons.Length; i++)
            {
                _Buttons[i].onClick.AddListener(InvokeEvent);
            }
        }

        public void SetView(int i)
        {
            if (_betViews == null)
                InitBetViews();

            ClearViews();

            _betViews[i].Activate();

            _BetName.text = _betViews[i].BetName;
        }

        public void AddListener(Action onClick)
        {
            _onClick += onClick;
        }

        public void RemoveListener(Action onClick)
        {
            _onClick -= onClick;
        }

        private void ClearViews()
        {
            for (int i = 0; i < _betViews.Length; i++)
                _betViews[i].Clear();
        }

        private void InitBetViews()
        {
            _betViews = GetComponentsInChildren<IBetView>(true);
        }
        
        private void InvokeEvent()
        {
            _onClick?.Invoke();
        }
    }
}