using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public GameObject Fill;
    public GameObject Engine;
    Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
        Slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float maxValue = Engine.GetComponent<RailEngineManager>().velocity * 4;
        Fill.GetComponent<RectTransform>().anchorMax = new Vector2 (1, .2f + maxValue);

        if (Mathf.Abs(Slider.value - 0) < .005f)
        {
            Slider.value = 0;
        }
    }
}
