using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Models.Games;
using UnityEngine;

public interface IGameView
{
    IGamePresenter GamePresenter { get; set; }
    Games GameId { get; }
    GameObject GameObject { get; }
    void SetResultCount(int count);
    void Select();
    void Unselect();
}
