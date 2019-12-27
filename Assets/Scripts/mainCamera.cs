using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{ 
    private GameObject _player;
    private Vector3 _deltaOfVectors;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _deltaOfVectors = transform.position - _player.transform.position;
    }

    void Update()
    {
        transform.position += (transform.position - (_player.transform.position + _deltaOfVectors)) * Time.deltaTime;
    }
}
