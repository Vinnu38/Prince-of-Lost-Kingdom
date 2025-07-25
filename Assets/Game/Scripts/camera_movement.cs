using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 offset;
    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x < 140)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.transform.position - offset, ref velocity, .5f);
        }

        
    }
}
