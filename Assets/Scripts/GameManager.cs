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

    List<TeamStruct> Teams;
    public GameObject Worm;

    private int _turnNumber;

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
        Teams = new List<TeamStruct>();
        UpdateGameState(GameState.AssignTeams);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.AssignTeams:
                TeamAssignment(2, 4);
                break;
            case GameState.PlayerTurn:
                NewTurn();
                break;
            case GameState.victory:
                PlayerVictory();
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void TeamAssignment(int _numberOfTeams, int _numberOfWorms)
    {
        for(int i = 0; i < _numberOfTeams; i++)
        {
            TeamStruct _tempTeam = new(_numberOfWorms, i+1);
            for(int x = 0; x < _numberOfWorms; x++)
            {
                Vector3 _randSpawnPos = new(UnityEngine.Random.Range(-50, 51), 5, UnityEngine.Random.Range(-50, 51));
                _tempTeam.TeamMembers[x] = Instantiate(Worm, _randSpawnPos, Quaternion.identity);
            }

            Teams.Add(_tempTeam);
        }
    }

    private void PlayerVictory()
    {
        throw new NotImplementedException();
    }

    private void NewTurn()
    {
        //To do
        //Find active worm from team
        //Add Cameras to its variables so it follows correctly
        //When has fired, end turn and make a new turn
        //When no more of one team exists, call upon PlayerVictory
        throw new NotImplementedException();
    }
}

public enum GameState
{
    AssignTeams,
    PlayerTurn,
    victory
}
