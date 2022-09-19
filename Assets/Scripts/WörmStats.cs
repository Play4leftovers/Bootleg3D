using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WörmStats : MonoBehaviour
{
    public int Health;
    public int PlayerID;
    public Transform Worm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Death();
        }
    }
    
    void Death()
    {
        Destroy(Worm);
    }
}
