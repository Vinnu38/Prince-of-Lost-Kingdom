using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Movement : MonoBehaviour
{
    [SerializeField]  GameObject target;
    [SerializeField] Vector3 offset;
    Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position - offset, ref velocity, 1f);
    }
}
