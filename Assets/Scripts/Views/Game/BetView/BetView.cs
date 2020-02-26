using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Views.Game.BetView
{
    public class BetView : MonoBehaviour, IBetView
    {
        [SerializeField] private string _BetName = "Обычная";

        public string BetName => _BetName;

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Clear()
        {
            gameObject.SetActive(false);
        }
    }
}