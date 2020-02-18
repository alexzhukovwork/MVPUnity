using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Prefabs;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class MenuModel : IMenuModel
    {
        public IMenuElementView[] MenuPrefabs { get; set; }

        public IMenuElementView Current { get; set; }

        public MenuModel(IMenuElementView[] menuPrefabs)
        {
            MenuPrefabs = menuPrefabs;
        }

        public void SetCurrentElement(int index)
        {
            if (MenuPrefabs.Length > 0)
                Current = MenuPrefabs[index];
        }
    }
}