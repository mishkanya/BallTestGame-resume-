using UnityEngine;
using System;

public class mainCamera : MonoBehaviour
{ 
    private GameObject _player;
    private Vector3 _deltaOfVectors;
    private const float _speed = 3;
    public bool quitBool = false;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _deltaOfVectors = transform.position - _player.transform.position;
    }
    void Update()
    {
        p();
        transform.position = _player.transform.position + _deltaOfVectors; 
    }
    void p(){
        if(Input.touchCount > 1)
            quitBool = false;
            
        if (Input.GetKeyDown(KeyCode.Escape) && quitBool == true){
            Application.Quit();
        }
        if(Input.anyKey){
            if (Input.GetKey(KeyCode.Escape))
                quitBool = true;
            else 
                quitBool = false;
        }
    }
}
