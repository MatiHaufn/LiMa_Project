using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool _isGrounded() { return _grounded; }
    bool _grounded;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            _grounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            _grounded = false;
        }
    }

}
