using System;
using UnityEngine;

namespace Assets.Scripts.Prefabs
{
    public interface IMenuElementView
    {
        GameObject GameObject { get; }
        Action OnClick { get; set; }
        void Select();
        void Unselect();
    }
}