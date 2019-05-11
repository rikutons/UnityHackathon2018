using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour
{
    public float disappearInterval;   // 点滅周期
    public float appearInterval;   // 点滅周期

    private float time;
    private bool isEnabled;
    new private Renderer renderer;
    // Use this for initialization
    void Start()
    {
        time = 0;
        isEnabled = true;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isEnabled&&time > disappearInterval)
        {
            var alpha = 0;
            var color = renderer.material.color;
            renderer. material.color = new Color(color.r, color.g, color.b, alpha);
            isEnabled = false;
        }
        else if (time > disappearInterval + appearInterval)
        {
            var alpha = 255;
            var color = renderer.material.color;
            renderer.material.color = new Color(color.r, color.g, color.b, alpha);
            isEnabled = true;
            time = 0;
        }
    }
}