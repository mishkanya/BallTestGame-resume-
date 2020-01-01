using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Crystal : BonusItem
{
    public float SpeedMultiply = 1.1f;
    void Start()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        _scoreBar = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<Text>();
    }

    void Update()
    {
        Animation();
    }
    private void OnTriggerEnter(Collider col){
        if(col.tag == "Player")
        TakeCrystal(); 
    }
    void TakeCrystal(){
        _playerScript.AddSpeed = SpeedMultiply;
        Hider();
    }
}
