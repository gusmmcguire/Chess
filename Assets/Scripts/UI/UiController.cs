﻿using System;
using System.Collections;
using System.Collections.Generic;
using Pieces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UiController : MonoBehaviour
    {
        public GameObject messengerWhite;
        public GameObject messengerBlack;

    
        // Displays the message for the current team in the UI
        public void Message((string message, Piece.Team team) received)
        {
            switch (received.team)
            {
                case Piece.Team.Black:
                    messengerBlack.SendMessage("DisplayText", received.message);
                    break;
                case Piece.Team.White:
                    messengerWhite.SendMessage("DisplayText", received.message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(received.team), received.team, null);
            }
        }

        // Returns to the MainScene
        public void Back()
        {
            //if(SceneManager.GetActiveScene().name == "GameScene") SceneManager.UnloadSceneAsync("Scenes/GameScene");
            //else if(SceneManager.GetActiveScene().name == "960Scene") SceneManager.UnloadSceneAsync("Scenes/960Scene");
            SceneManager.LoadScene("Scenes/MainScene");
        }

    }
}
