using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailCarScript : MonoBehaviour
{
    public GameObject Engine;
    //RailEngineScript engineScript;

    float railPosition = 0;
    public float carOffset;
    public int carPosition;

    void Start()
    {
        //engineScript = Engine.GetComponent<RailEngineScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //railPosition = engineScript.railPosition;

        //transform.position = engineScript.RailPositionToWorldPosition(railPosition - carOffset * carPosition);
        //Vector2 direction = engineScript.RailPositionToTrackDirection(railPosition - carOffset * carPosition);
        //transform.eulerAngles = new Vector3(0, 0, (Mathf.Atan2(direction.y ,direction.x) * Mathf.Rad2Deg));

    }
}