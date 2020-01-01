using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonuseSpawner : MonoBehaviour
{
    public GameObject[] Bonuses;
    void Start()
    {
        if(Random.value < 0.50)
        Instantiate(Bonuses[Random.Range(0, Bonuses.Length)],transform.position, transform.rotation);
    }
}
