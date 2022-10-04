using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckshot : MonoBehaviour
{
    [SerializeField] float _maxSpread;
    [SerializeField] int _pelletAmount = 12;
    public float _pelletForce;

    public GameObject Pellets;

    private void Awake()
    {
        Vector3 _dir;
        for(int i = 0; i < _pelletAmount; i++)
        {
            _dir = transform.forward + new Vector3(Random.Range(-_maxSpread, _maxSpread), Random.Range(-_maxSpread, _maxSpread), Random.Range(-_maxSpread, _maxSpread));
            GameObject _pellet = Instantiate(Pellets, transform.position, transform.rotation);
            _pellet.GetComponent<Rigidbody>().AddForce(_dir * _pelletForce);
        }
        Destroy(gameObject);
    }
}
