using UnityEngine;

public class mainCamera : MonoBehaviour
{ 
    private GameObject _player;
    private Vector3 _deltaOfVectors;
    private const float _speed = 3;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _deltaOfVectors = transform.position - _player.transform.position;
    }
    void Update()
    {
        transform.position += ((_player.transform.position + _deltaOfVectors) - transform.position) * Time.deltaTime * _speed;
    }
}
