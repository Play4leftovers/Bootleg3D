using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WörmStats : MonoBehaviour
{
    public int Health;
    public int PlayerID;
    public Transform Worm;

    public void TakeDamage(int _damage)
    {
        Health -= _damage;
        if (Health <= 0)
        {
            Death();
        }
    }
    
    void Death()
    {
        Destroy(Worm.gameObject);
    }
}
