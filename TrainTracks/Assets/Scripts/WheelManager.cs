using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    public GameObject Engine;
    RailEngineManager EngineManager;
    public Animator Rolling;
    // Start is called before the first frame update
    void Start()
    {
        Rolling.SetFloat("Multiplier", 0);
        EngineManager = Engine.GetComponent<RailEngineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Rolling.SetFloat("Multiplier", Mathf.Lerp(EngineManager.targetVelocity, EngineManager.velocity, .5f) * 50);
    }
}
