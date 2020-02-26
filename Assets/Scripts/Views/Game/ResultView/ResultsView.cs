using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Views.Game.ResultView
{
    public class ResultsView : MonoBehaviour, IResultsView
    {
        private IResultView[] _Results;

        public void SetResults(int[] numbers)
        {
            if (_Results == null)
                InitResults();

            ClearAll();

            if (numbers == null)
                return;

            for (int i = 0; i < numbers.Length && i < _Results.Length; i++)
            {
                _Results[i].SetResult(numbers[i]);
            }
        }

        private void InitResults() 
        {
            _Results = GetComponentsInChildren<IResultView>();
        }

        private void ClearAll()
        {
            for (int i = 0; i < _Results.Length; i++)
            {
                _Results[i].Clear();
            }
        }
    }
}