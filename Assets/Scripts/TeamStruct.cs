using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TeamStruct
{
    public List<GameObject> TeamMembers;
    //public Dictionary<GameObject, int> Ammo;
    public int TeamNumber;
    public TeamStruct(int _teamNumber)
    {
        TeamMembers = new List<GameObject>();
        TeamNumber = _teamNumber;
    }
}
