using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [HideInInspector] public int Score = 0;
    [SerializeField] private float Speed = 2;
    public float AddSpeed{ set {Speed = Speed * value;}}
    public GameObject StartHidingObject;
    
    private Vector3 _vectorToMove = Vector3.zero;
    private Rigidbody _rigidbody;
    private CapsuleCollider _collider; 
    

    void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbody = GetComponent<Rigidbody>();
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
}
