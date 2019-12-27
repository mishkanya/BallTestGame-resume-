using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    public int BonusScore = 10;
    public float SpeedMultiply = 1.1f;
    public UnityEvent BonusAction;
    private PlayerScript _playerScript;
    private float _rotationSpeed = 80f;
    private Text _scoreBar;
    void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        _scoreBar = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<Text>();
    }

    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(Time.time * _rotationSpeed, Time.time * _rotationSpeed, Time.time * _rotationSpeed);
    }
    private void OnTriggerEnter(Collider col){
        if(col.tag == "Player")
        TakeCrystal(); 
    }
    void TakeCrystal(){
        _playerScript.Score += BonusScore;
        _playerScript.AddSpeed = 1.2f;
        BonusAction.Invoke();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("destroy",0.5f);
        _scoreBar.text = _playerScript.Score.ToString();
    }
    private void destroy() => Destroy(gameObject);
}
