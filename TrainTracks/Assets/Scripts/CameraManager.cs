using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject TrackingObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 position = TrackingObject.GetComponent<Transform>().position;
        position += new Vector3(0, 0, -10);
        transform.position = Vector3.Lerp(transform.position, position, 0.1f);
    }
}