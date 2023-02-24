using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Movement
    Rigidbody _myRigidbody;

    public Vector3 move;
    public float _speed;
    public float _acceleration;
    float _startSpeed;
    float _halfSpeed;
    float verticalVelocity;

    private void Start()
    {
        _myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        _startSpeed = _speed;
        _halfSpeed = _speed * .75f;
    }
    private void FixedUpdate()
    {
        Move(); 
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 && z != 0)
            _speed = _halfSpeed;
        else
            _speed = _startSpeed;

        move = transform.right * x * _acceleration + transform.forward * z * _acceleration;

        _myRigidbody.velocity = new Vector3(move.x * _speed, verticalVelocity, move.z * _speed);
    }
}
