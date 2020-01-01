using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [HideInInspector] public float Score = 0;
    [SerializeField] private float Speed = 2;
    public float AddSpeed{ set {Speed = Speed * value;}}
    public GameObject StartHidingObject;
    [HideInInspector] public float BestScore = 0, LastScore = 0;
    
    private Vector3 _vectorToMove = Vector3.zero;
    private Rigidbody _rigidbody;
    private CapsuleCollider _collider; 
    private const float _multiplySpeedPerMoment = .01f;
    

    private void Awake(){
        
        if(PlayerPrefs.HasKey("BestScore") == false){
            PlayerPrefs.SetFloat("BestScore",0);
        }
        else{
            BestScore = PlayerPrefs.GetFloat("BestScore");
        }
        if(PlayerPrefs.HasKey("LastScore") == false){
            PlayerPrefs.SetFloat("LastScore",0);
        }
        else{
            LastScore = PlayerPrefs.GetFloat("LastScore");
        }
    }
     
    void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        SetScoresData(BestScore,LastScore);
    }

    private void Update()
    {
        if(Time.timeScale != 0)
        {
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began ) {
                    Move();
                }
            }
            else if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Move();
            }
        }
    }

    private void FixedUpdate()
    {
        _vectorToMove = _vectorToMove.normalized;
        _vectorToMove *= Speed;
        _vectorToMove.y = _rigidbody.velocity.y;
        _rigidbody.velocity = _vectorToMove + Physics.gravity/4;
        Speed += Time.fixedDeltaTime * _multiplySpeedPerMoment; 
    } 
    public void Move()
    {
        if(StartHidingObject)
            Destroy(StartHidingObject);
        _vectorToMove = 
        (_vectorToMove.normalized.z > 0)? 
        (Vector3.left):
        (Vector3.forward);
    }
    public void SetScoresData(float _bestScore, float _lastScore)
    {
        StartHidingObject.transform.FindChild("LastScore").GetComponent<TextMesh>().text = "Last score:" + _lastScore.ToString() + "\nBest score:"+ _bestScore.ToString();
    }
}
