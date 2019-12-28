using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [HideInInspector] public int Score = 0;
    [SerializeField] private float Speed = 2;
    public float AddSpeed{ set {Speed = Speed * value;}}
    public GameObject TextAboutStart;
    
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
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            if(TextAboutStart)
                Destroy(TextAboutStart);
            _vectorToMove = 
            (_vectorToMove.normalized == Vector3.forward)? 
            (Vector3.left):
            (Vector3.forward);
        }
    }
    void FixedUpdate()
    {
        _rigidbody.velocity = _vectorToMove * Speed + Physics.gravity;
    } 
}
