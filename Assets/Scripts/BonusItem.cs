using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class BonusItem : MonoBehaviour
{
    public int BonusScore = 10;
    public UnityEvent BonusAction;
    
    protected PlayerScript _playerScript;
    
    protected float _rotationSpeed = 80f;
    
    protected Text _scoreBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void Animation(){
        gameObject.transform.rotation = Quaternion.Euler(Time.time * _rotationSpeed, Time.time * _rotationSpeed, Time.time * _rotationSpeed);
    }
    protected void destroy() => Destroy(gameObject);
    protected void Hider(){
        _playerScript.Score += BonusScore;
        BonusAction.Invoke();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("destroy",0.5f);
        _scoreBar.text = _playerScript.Score.ToString();
    }
}
