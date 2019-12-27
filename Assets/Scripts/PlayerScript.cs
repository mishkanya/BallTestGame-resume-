using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int Score = 0;
    [SerializeField] private float Speed = 60;
    public float AddSpeed{ get {return Speed;} set {Speed = Speed * value;}}
    
    private Vector3 _vectorToMove = Vector3.zero;
    private Rigidbody _rigidbody;
    private CapsuleCollider _collider; 

    void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _vectorToMove = 
            (_vectorToMove.normalized == Vector3.forward)? 
            (Vector3.left):
            (Vector3.forward);
        }
    }
    void FixedUpdate()
    {
        _rigidbody.velocity = _vectorToMove * Speed + Vector3.up * Physics.gravity.y;
    } 
    
}
