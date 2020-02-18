using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Prefabs;
using UnityEngine;

public class MenuPrefab : MonoBehaviour, IMenuPrefab
{
    public string GetName => nameof();

    public GameObject GameObject => throw new System.NotImplementedException();

    public Event OnClick => throw new System.NotImplementedException();

}
