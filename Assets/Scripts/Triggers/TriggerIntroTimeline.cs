using Player;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerIntroTimeline : MonoBehaviour
{
    public PlayableDirector timeline; 
    public GameObject player; 
    private PlayerController playerController; 
    public float delay = 109f;
    public Camera timelineCamera;

    private void Start()
    {
       
        playerController = player.GetComponent<PlayerController>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {    
            gameObject.GetComponent<BoxCollider>().enabled = false;
            timeline.Play();
            timelineCamera.GetComponent<Camera>().depth = 1.0f;
            playerController.enabled = false;
            player.GetComponentInChildren<Animator>().SetFloat("Forward", 0.0f);
            player.GetComponentInChildren<Animator>().SetFloat("Side", 0.0f);
            StartCoroutine(ReactivatePlayerController());
        }
    }

    IEnumerator ReactivatePlayerController()
    {
        yield return new WaitForSeconds(delay);
        playerController.enabled = true;
        timelineCamera.GetComponent<Camera>().depth = -1.0f;
    }
}
