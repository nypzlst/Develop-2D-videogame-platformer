using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    [SerializeField] Transform followTarger;
    [SerializeField, Range(0f, 1f)] float parallaxStrenght = 0.1f;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviousPos;
    
    void Start()
    {
        if (!followTarger)
        {
            followTarger = Camera.main.transform;
            targetPreviousPos= followTarger.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var delta = followTarger.position - targetPreviousPos;

        if (disableVerticalParallax)
        {
            delta.y = 0;
        }
        targetPreviousPos= followTarger.position;

        transform.position += delta * parallaxStrenght;
    }
}
