using UnityEngine;

public class WorldAudioManager : MonoBehaviour
{

    public GameObject[] WorldAudios;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WorldAudios[0].SetActive(false);
            WorldAudios[1].SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

}
