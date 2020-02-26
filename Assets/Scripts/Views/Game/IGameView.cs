using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Models.Games;
using Assets.Scripts.Views.Game.BetView;
using UnityEngine;

public interface IGameView
{
    IGamePresenter GamePresenter { get; set; }
    Games GameId { get; }
    GameObject GameObject { get; }
    IBetsView BetsView { get; }
    void SetResults(int[] results);
    void Select();
    void Unselect();
}
