using Cinemachine;
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

    private int _turnNumber = 0;
    private int _wormNumber = 0;

    public CinemachineVirtualCamera AimCam;
    public CinemachineVirtualCamera TPSCam;

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
            Color _teamColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1.0f);

            for(int x = 0; x < _numberOfWorms; x++)
            {
                Vector3 _randSpawnPos = new(UnityEngine.Random.Range(-50, 51), 5, UnityEngine.Random.Range(-50, 51));
                _tempTeam.TeamMembers[x] = Instantiate(Worm, _randSpawnPos, Quaternion.identity);
                _tempTeam.TeamMembers[x].GetComponentInChildren<Renderer>().material.color = _teamColor;
            }

            Teams.Add(_tempTeam);
        }
        UpdateGameState(GameState.PlayerTurn);
    }

    private void PlayerVictory()
    {
        
    }

    private void NewTurn()
    {
        //To do
        //Find active worm from team
        //Add Cameras to its variables so it follows correctly
        //When has fired, end turn and make a new turn
        //When no more of one team exists, call upon PlayerVictory
        GameObject _currWorm = Teams[_turnNumber].TeamMembers[_wormNumber];
        _currWorm.GetComponent<WörmController>().Active = true;
        TPSCam.m_LookAt = _currWorm.transform;
        AimCam.m_LookAt = _currWorm.transform;

        TPSCam.m_Follow = _currWorm.transform;
        AimCam.m_Follow = _currWorm.transform;
    }
}

public enum GameState
{
    AssignTeams,
    PlayerTurn,
    victory
}
