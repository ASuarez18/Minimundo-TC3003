using Player;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource audioSource;
    public AnimationCurve curvce;

    #region Steps
    public List<AudioClip> GrassSteps;
    public List<AudioClip> MudSteps;
    public List<AudioClip> RockSteps;
    public List<AudioClip> WoodSteps;
    #endregion

    #region Run
    public List<AudioClip> GrassRun;
    public List<AudioClip> MudRun;
    public List<AudioClip> RockRun;
    public List<AudioClip> WoodRun;
    #endregion

    #region Jumps Start
    public List<AudioClip> GrassJumpsStart;
    public List<AudioClip> MudJumpsStart;
    public List<AudioClip> RockJumpsStart;
    public List<AudioClip> WoodJumpsStart;
    #endregion

    #region Jumps End
    public List<AudioClip> GrassJumpsEnd;
    public List<AudioClip> MudJumpsEnd;
    public List<AudioClip> RockJumpsEnd;
    public List<AudioClip> WoodJumpsEnd;
    #endregion

    PlayerController controller;

    private void Start()
    {
        controller = GetComponentInParent<PlayerController>();
    }

    public void PlayStepAudio()
    {
        int floor = controller.FloorIndex;
        int index;
        switch (floor)
        {
            case 0:
                index = Random.Range(0, GrassSteps.Count);
                audioSource.PlayOneShot(GrassSteps[index]);
                break;
            case 1:
                index = Random.Range(0, MudSteps.Count);
                audioSource.PlayOneShot(MudSteps[index]);
                break;
            case 2:
                index = Random.Range(0, RockSteps.Count);
                audioSource.PlayOneShot(RockSteps[index]);
                break;
            case 3:
                index = Random.Range(0, WoodSteps.Count);
                audioSource.PlayOneShot(WoodSteps[index]);
                break;
        }
        curvce.Evaluate(0.5f);
    }

    public void PlayRunAudio()
    {
        int floor = controller.FloorIndex;
        int index;
        switch (floor)
        {
            case 0:
                index = Random.Range(0, GrassRun.Count);
                audioSource.PlayOneShot(GrassRun[index]);
                break;
            case 1:
                index = Random.Range(0, MudRun.Count);
                audioSource.PlayOneShot(MudRun[index]);
                break;
            case 2:
                index = Random.Range(0, RockRun.Count);
                audioSource.PlayOneShot(RockRun[index]);
                break;
            case 3:
                index = Random.Range(0, WoodRun.Count);
                audioSource.PlayOneShot(WoodRun[index]);
                break;
        }
        curvce.Evaluate(0.5f);
    }

    public void PlayJumpStartAudio()
    {
        int floor = controller.FloorIndex;
        int index;
        switch (floor)
        {
            case 0:
                index = Random.Range(0, GrassJumpsStart.Count);
                audioSource.PlayOneShot(GrassJumpsStart[index]);
                break;
            case 1:
                index = Random.Range(0, MudJumpsStart.Count);
                audioSource.PlayOneShot(MudJumpsStart[index]);
                break;
            case 2:
                index = Random.Range(0, RockJumpsStart.Count);
                audioSource.PlayOneShot(RockJumpsStart[index]);
                break;
            case 3:
                index = Random.Range(0, WoodJumpsStart.Count);
                audioSource.PlayOneShot(WoodJumpsStart[index]);
                break;
        }
        curvce.Evaluate(0.5f);
    }

    public void PlayJumpStartEnd()
    {
        int floor = controller.FloorIndex;
        int index;
        switch (floor)
        {
            case 0:
                index = Random.Range(0, GrassJumpsEnd.Count);
                audioSource.PlayOneShot(GrassJumpsEnd[index]);
                break;
            case 1:
                index = Random.Range(0, MudJumpsEnd.Count);
                audioSource.PlayOneShot(MudJumpsEnd[index]);
                break;
            case 2:
                index = Random.Range(0, RockJumpsEnd.Count);
                audioSource.PlayOneShot(RockJumpsEnd[index]);
                break;
            case 3:
                index = Random.Range(0, WoodJumpsEnd.Count);
                audioSource.PlayOneShot(WoodJumpsEnd[index]);
                break;
        }
        curvce.Evaluate(0.5f);
    }

}
