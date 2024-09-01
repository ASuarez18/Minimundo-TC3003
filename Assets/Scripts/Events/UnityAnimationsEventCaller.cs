using UnityEngine;
using UnityEngine.Serialization;

public class UnityAnimationsCaller : MonoBehaviour
{
    [FormerlySerializedAs("_unityEvents")]
    [SerializeField]
    private MyUnityEvents myUnityEvents;

    public void CallStartRitualEvent()
    {
        myUnityEvents.StartRitual?.Invoke();
    }
}
