using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    List<TeamStruct> Teams;
    public GameObject Worm;
    GameObject _currWorm;

    [SerializeField] private int _turnNumber = 0;
    [SerializeField] private int _wormNumber = 0;

    public CinemachineVirtualCamera AimCam;
    public CinemachineVirtualCamera TPSCam;
    public Transform PrimeCam;

    [SerializeField] PlayerInput _playerInput;
    private InputAction _endTurnAction;

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
        _endTurnAction = _playerInput.actions["EndTurn"];
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
                StartNewTurn();
                break;
            case GameState.EndTurn:
                EndOldTurn();
                break;
            case GameState.Victory:
                PlayerVictory();
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void TeamAssignment(int _numberOfTeams, int _numberOfWorms)
    {
        for(int i = 0; i < _numberOfTeams; i++)
        {
            TeamStruct _tempTeam = new(i+1);
            Color _teamColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1.0f);

            for(int x = 0; x < _numberOfWorms; x++)
            {
                Vector3 _randSpawnPos = new(UnityEngine.Random.Range(-50, 51), 5, UnityEngine.Random.Range(-50, 51));
                //_tempTeam.TeamMembers[x] = Instantiate(Worm, _randSpawnPos, Quaternion.identity);
                _tempTeam.TeamMembers.Add(Instantiate(Worm, _randSpawnPos, Quaternion.identity));
                _tempTeam.TeamMembers[x].GetComponentInChildren<Renderer>().material.color = _teamColor;
            }

            Teams.Add(_tempTeam);
        }
        UpdateGameState(GameState.PlayerTurn);
    }

    private void PlayerVictory()
    {
        
    }

    private void StartNewTurn()
    {
        //To do
        //Find active worm from team
        //Add Cameras to its variables so it follows correctly
        //When has fired, end turn and make a new turn
        //When no more of one team exists, call upon PlayerVictory
        if (Teams[_turnNumber].TeamMembers[_wormNumber] != null)
        {
            _currWorm = Teams[_turnNumber].TeamMembers[_wormNumber];

            _currWorm.GetComponent<WörmController>().Cam = PrimeCam;
            _currWorm.GetComponentInChildren<WeaponArm>().UpdateCam();
            _currWorm.GetComponent<WörmController>().Active = true;
            TPSCam.m_LookAt = _currWorm.transform;
            AimCam.m_LookAt = _currWorm.transform;

            TPSCam.m_Follow = _currWorm.transform;
            AimCam.m_Follow = _currWorm.transform;
        }
        else
        {
            UpdateGameState(GameState.EndTurn);
        }
    }
    private void EndOldTurn()
    {
        _currWorm.GetComponent<WörmController>().Active = false;
        _currWorm.GetComponentInChildren<WeaponArm>().Fired = false;

        _turnNumber++;
        if(_turnNumber >= Teams.Count)
        {
            _wormNumber++;
            if(_wormNumber == Teams[_turnNumber - 1].TeamMembers.Count)
            {
                _wormNumber = 0;
            }
            _turnNumber = 0;

        }
        UpdateGameState(GameState.PlayerTurn);
    }
    private void OnEnable()
    {
        _endTurnAction.performed += _ => UpdateGameState(GameState.EndTurn);
    }
}

public enum GameState
{
    AssignTeams,
    PlayerTurn,
    EndTurn,
    Victory
}
