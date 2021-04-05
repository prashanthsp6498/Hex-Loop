using System;
using System.Collections;
using System.Collections.Generic;
using HexLoop.Manager;
using HexLoop.Manager.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ScoreView scoreView;
    [SerializeField] private ScoreModel scoreModel;

    public static Action UpdateScore;

    private void OnEnable()
    {
        UpdateScore = UpdatePlayerScore;
    }


    private void UpdatePlayerScore()
    {
        scoreView.UpdateScore(scoreModel.GetUpdatedScore());
    }

}
