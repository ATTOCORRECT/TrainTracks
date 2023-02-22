using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailEngineManager : MonoBehaviour
{

    GameObject[] Rails;
    RailManager[] RailManagers;

    [HideInInspector] public float[] cumulativeArcLength;

    int railSegmentPosition = 0; // which track segment is currently being occupied
    public float railPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rails = GameObject.FindGameObjectsWithTag("BezierRail");

        RailManagers = new RailManager[Rails.Length];
        for (int i = 0; i < Rails.Length; i++) 
        {
            for (int j = 0; j < Rails.Length; j++)
            {
                if (Rails[j].GetComponent<RailManager>().sequenceNumber == i)
                {
                    RailManagers[i] = Rails[j].GetComponent<RailManager>();
                }
            }
        }

        cumulativeArcLength = new float[Rails.Length + 1];
        cumulativeArcLength[0] = 0;
        for (int i = 0; i < RailManagers.Length; i++)
        {
            cumulativeArcLength[i + 1] = cumulativeArcLength[i] + RailManagers[i].arcLength;
        }
        Debug.Log(cumulativeArcLength);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        railPosition += .1f;

        transform.position = RailPositionToWorldPosition(railPosition);
        Vector2 direction = RailPositionToTrackDirection(railPosition);
        transform.eulerAngles = new Vector3(0, 0, (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
    }

    float mod(float x, float m) // i hate C# why do i even have to do this
    {
        return (x % m + m) % m;
    }

    public Vector2 RailPositionToWorldPosition(float position)
    {
        float totalArcLength = cumulativeArcLength[cumulativeArcLength.Length - 1];
        position = mod(position, totalArcLength);

        for (int i = 0; i < cumulativeArcLength.Length - 1; i++)
        {
            if (position >= cumulativeArcLength[i] && position < cumulativeArcLength[i + 1])
            {
                railSegmentPosition = i;
            }
        }

        return RailManagers[railSegmentPosition].DistanceToPoint(position - cumulativeArcLength[railSegmentPosition]);
    }

    public Vector2 RailPositionToTrackDirection(float position)
    {
        Vector2 a = RailPositionToWorldPosition(position - .1f);
        Vector2 b = RailPositionToWorldPosition(position + .1f);
        return (b - a).normalized;
    }
}
