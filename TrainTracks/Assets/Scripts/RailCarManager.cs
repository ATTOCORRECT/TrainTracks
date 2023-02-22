using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailCarManager : MonoBehaviour
{
    public GameObject Engine;
    RailEngineManager engineManager;

    float railPosition = 0;
    public float carOffset;
    public int carPosition;

    void Start()
    {
        engineManager = Engine.GetComponent<RailEngineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        railPosition = engineManager.railPosition;

        transform.position = engineManager.RailPositionToWorldPosition(railPosition - carOffset * carPosition);
        Vector2 direction = engineManager.RailPositionToTrackDirection(railPosition - carOffset * carPosition);
        transform.eulerAngles = new Vector3(0, 0, (Mathf.Atan2(direction.y ,direction.x) * Mathf.Rad2Deg));

    }
}