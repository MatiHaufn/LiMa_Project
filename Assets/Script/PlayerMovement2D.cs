using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float _moveSpeed;
    public float _acceleration;

    [SerializeField] Transform _groundCheck;
    [SerializeField] float verticalVelocity = -1;
    [SerializeField] float jumpForce = 1f; 

    Rigidbody _myRigidbody; 
    Vector3 _move;

    public LayerMask _groundMask;
    bool _grounded; 


    private void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
         _grounded = Physics.Raycast(_groundCheck.position, Vector3.down, 0.15f, _groundMask);

        if(_grounded)
            Debug.DrawRay(_groundCheck.position, Vector3.down * 0.15f, Color.red);
        else
            Debug.DrawRay(_groundCheck.position, Vector3.down * 0.15f, Color.green);
            

        float xDir = Input.GetAxis("Horizontal");

        _move = transform.right * xDir * _acceleration;
        _myRigidbody.velocity = new Vector3(_move.x * _moveSpeed, verticalVelocity, 0);

        if (Input.GetButtonDown("Jump") && _grounded == true)
        {
            Debug.Log("Jumpppp!!");
            _myRigidbody.velocity = Vector3.up * jumpForce;
        }
    }

    
}
