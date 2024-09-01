using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            gameObject.GetComponentInParent<Animator>().enabled = true;
            gameObject.GetComponent<TriggerDoor>().enabled = false;
        }
    }
}
