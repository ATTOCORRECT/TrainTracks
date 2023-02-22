using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailManager : MonoBehaviour
{
    Vector2[] point = new Vector2[4];

    LineRenderer LineRenderer;

    float[] cumulativeArcLengthLUT;
    [HideInInspector] public float arcLength; 
    public int sequenceNumber; // assign in unity
    
    // Start is called before the first frame update
    void Awake()
    {
        LineRenderer = gameObject.GetComponent<LineRenderer>();

        for (int i = 0; i < 4; i++) 
        {
            point[i] = transform.GetChild(i).GetComponent<Transform>().position;
        }
       
        int pointSamples = 32; // number of samples the bezier gets, curve resolution
        LineRenderer.positionCount = pointSamples;
        Vector2[] bezierSamples = new Vector2[pointSamples];

        // sample points on bezier
        for (int i = 0; i < pointSamples; i++) 
        {
            Vector2 point = BezierCurve(i / (float)(pointSamples - 1));
            LineRenderer.SetPosition(i, point);
            bezierSamples[i] = point;
        }



        // arcLength aproximation and lookup table
        float cumulativeArcLength = 0;
        cumulativeArcLengthLUT = new float[bezierSamples.Length];
        cumulativeArcLengthLUT[0] = 0;
        for (int i = 1; i < (bezierSamples.Length); i++) 
        {
            cumulativeArcLength += (bezierSamples[i] - bezierSamples[i - 1]).magnitude;
            cumulativeArcLengthLUT[i] = cumulativeArcLength;
        }
        arcLength = cumulativeArcLengthLUT[cumulativeArcLengthLUT.Length - 1];

        Debug.Log(arcLength);
        Debug.Log(DistanceToT(cumulativeArcLengthLUT, arcLength));
        Debug.Log(DistanceToPoint(arcLength));
        Debug.Log("---");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 DistanceToPoint(float distance)
    {
        return BezierCurve(DistanceToT(cumulativeArcLengthLUT, distance));
    }

    float DistanceToT(float[] LUT, float distance)
    {
        float arcLength = LUT[LUT.Length - 1];
        int n = LUT.Length;
        for ( int i = 0; i < n - 1; i++)
        {
            if (distance >= LUT[i] && distance < LUT[i + 1])
            {
                float x = distance;
                float x0 = LUT[i];
                float x1 = LUT[i + 1];
                float y0 = i / ((float)n - 1);
                float y1 = (i + 1) / ((float)n - 1);

                return ((y1 - y0) / (x1 - x0)) * (x - x0) + y0;
            }
        }
        return distance / arcLength;
    }

    Vector2 BezierCurve(float t) 
    {
        // line segments
        Vector2 line0 = Vector2.Lerp(point[0], point[1], t);
        Vector2 line1 = Vector2.Lerp(point[1], point[2], t);
        Vector2 line2 = Vector2.Lerp(point[2], point[3], t);
        // quadratic bezier
        Vector2 Quad0 = Vector2.Lerp(line0, line1, t);
        Vector2 Quad1 = Vector2.Lerp(line1, line2, t);
        // cubic bezier
        Vector2 Cube0 = Vector2.Lerp(Quad0, Quad1, t);

        return Cube0;
    }
}
