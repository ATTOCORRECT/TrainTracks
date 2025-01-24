using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    public GameObject Engine;
    RailEngineManager EngineManager;
    public GameObject LeftWheel;
    public GameObject RightWheel;
    float speed = 5000;
    // Start is called before the first frame update
    void Start()
    {
        EngineManager = Engine.GetComponent<RailEngineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotationalVelocity = Mathf.Lerp(EngineManager.targetVelocity, EngineManager.velocity, .5f) * speed * Time.deltaTime;
        LeftWheel.transform.Rotate(Vector3.forward * rotationalVelocity * -1);
        RightWheel.transform.Rotate(Vector3.forward * rotationalVelocity);
    }
}
