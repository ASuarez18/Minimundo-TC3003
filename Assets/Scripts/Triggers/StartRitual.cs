using UnityEngine;

public class StartRitual : MonoBehaviour
{
    public GameObject Orb;

    void EnableLight()
    {
        Orb.GetComponentInChildren<Light>().enabled = true;
    }

    void EnablePulse()
    {
        Orb.GetComponent<LightPulse>().enabled = true;
    }
}
