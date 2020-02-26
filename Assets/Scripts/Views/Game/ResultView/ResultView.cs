using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Views.Game.ResultView
{
    public class ResultView : MonoBehaviour, IResultView
    {
        [SerializeField] private TextMeshProUGUI _Text;

        private void Reset()
        {
            _Text = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetResult(int number)
        {
            _Text.text = number.ToString();
            gameObject.SetActive(true);
        }

        public void Clear()
        {
            gameObject.SetActive(false);
        }
    }
}
