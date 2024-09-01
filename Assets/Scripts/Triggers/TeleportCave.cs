using UnityEngine;

public class TeleportCave : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            other.enabled = false;
            other.transform.position = target.transform.position;
            other.transform.eulerAngles = target.transform.eulerAngles;
            other.enabled = true;
        }
    }   
}
