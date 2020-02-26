using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Models.Network;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Server
{
    public class ClientMono : MonoBehaviour
    {
        [SerializeField] private float _TimeForUpdate = 5;

        [Inject]
        private IClient Client { get; set; }

        private void Start()
        {
            InvokeRepeating(nameof(OnRepeat), 0, _TimeForUpdate);
        }

        private void OnRepeat()
        {
            Client.OnEvent();
        }
    }
}