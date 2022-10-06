using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TeamStruct
{
    public GameObject[] TeamMembers;
    //public Dictionary<GameObject, int> Ammo;
    public int TeamNumber;
    public TeamStruct(int _memberSize, int _teamNumber)
    {
        TeamMembers = new GameObject[_memberSize];
        TeamNumber = _teamNumber;
    }
}
