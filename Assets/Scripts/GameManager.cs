using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }


    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        UpdateGameState(GameState.PlayerTurn);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.PlayerTurn:
                NewTurn();
                break;
            case GameState.victory:
                PlayerVictory();
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void PlayerVictory()
    {
        throw new NotImplementedException();
    }

    private void NewTurn()
    {
        throw new NotImplementedException();
    }
}

public enum GameState
{
    PlayerTurn,
    victory
}
