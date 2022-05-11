using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    public Vector3 Target;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * 150.0f);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Target - transform.position);

        if (Vector2.Distance(Target, transform.position) < 1.0f)
        {
            Destroy(gameObject);
        }

    }
}
