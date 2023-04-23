using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject _PlayerBody;
    [SerializeField] GameObject _DecalProjectorObject;
    [SerializeField] GameObject _WallCollider;
    [SerializeField] DecalProjector _DecalProjector; 
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
        _DecalProjectorObject.SetActive(!_PlayerIs3D);

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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if (!_PlayerIs3D)
            z = 0;

        if (x != 0 && z != 0)
            _speed = _halfSpeed;
        else
            _speed = _startSpeed;

        move = transform.right * x * _acceleration + transform.forward * z * _acceleration;

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
            _DecalProjectorObject.SetActive(!_PlayerIs3D);
        }
    }
}
