using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject _PlayerBody;
    [SerializeField] GameObject _Player2D;
    [SerializeField] GameObject _WallCollider;
    [SerializeField] GameObject _GroundCheck;
    [SerializeField] float _jumpForce;

    public float _speed;
    public float _acceleration;
    
    //Player Movement
    Rigidbody _myRigidbody;
    Vector3 _move;
    float _startSpeed;
    float _halfSpeed;
    float _verticalVelocity = -1;
    bool _PlayerIs3D = true;

    private void Start()
    {
        _myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        
        _PlayerBody.SetActive(_PlayerIs3D);
        //_Player2D.SetActive(!_PlayerIs3D);

        _startSpeed = _speed;
        _halfSpeed = _speed * .75f;
    }
    private void Update()
    {
        Move();
        SwitchDimension();

        Debug.Log(_GroundCheck.GetComponent<GroundCheck>()._isGrounded());

        if (Input.GetButtonDown("Jump") && _GroundCheck.GetComponent<GroundCheck>()._isGrounded())
        {
            _myRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }



    private void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");
        
        if (!_PlayerIs3D)
            zDir = 0;

        if (xDir != 0 && zDir != 0)
            _speed = _halfSpeed;
        else
            _speed = _startSpeed;

        _move = transform.right * xDir * _acceleration + transform.forward * zDir * _acceleration;

        _myRigidbody.velocity = new Vector3(_move.x * _speed, _verticalVelocity, _move.z * _speed);
    }

    private void SwitchDimension()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(_WallCollider.GetComponent<WallTracker>().trackedWall == true && _PlayerIs3D == true)
                _PlayerIs3D = false; 
            else
                _PlayerIs3D = true;

            _PlayerBody.SetActive(_PlayerIs3D);
           // _Player2D.SetActive(!_PlayerIs3D);
        }
    }
}
