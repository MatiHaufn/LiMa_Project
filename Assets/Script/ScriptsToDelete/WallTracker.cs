using UnityEngine;

public class WallTracker : MonoBehaviour
{
    public bool trackedWall;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SwitchWall")
        {
            trackedWall = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SwitchWall")
        { 
            trackedWall = false;
        }
    }
}
