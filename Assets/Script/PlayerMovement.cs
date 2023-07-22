using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject _PlayerBody;
    [SerializeField] GameObject _Player2D;
    [SerializeField] GameObject _WallCollider;
    bool _PlayerIs3D = true; 

    //Player Movement
    Rigidbody _myRigidbody;

    public Vector3 move;
    public float _speed;
    public float _acceleration;
    float _startSpeed;
    float _halfSpeed;
    float verticalVelocity = -1;

    private void Start()
    {
        _myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        
        _PlayerBody.SetActive(_PlayerIs3D);
        //_Player2D.SetActive(!_PlayerIs3D);

        _startSpeed = _speed;
        _halfSpeed = _speed * .75f;
    }
    private void FixedUpdate()
    {
        Move();
        SwitchDimension(); 
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

        move = transform.right * xDir * _acceleration + transform.forward * zDir * _acceleration;

        _myRigidbody.velocity = new Vector3(move.x * _speed, verticalVelocity, move.z * _speed);
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
