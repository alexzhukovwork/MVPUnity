using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameView
{
    IGamePresenter GamePresenter { get; set; }

    GameObject GameObject { get; }

    void Select();
    void Unselect();
}
