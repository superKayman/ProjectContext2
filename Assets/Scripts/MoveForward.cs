using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    float m_distanceTraveled = 0f;
    public float maxDis;
    public float x,y,z;

    void Update()
    {
        if (m_distanceTraveled < maxDis)
        {
            Vector3 oldPosition = transform.position;
            transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
            m_distanceTraveled += Vector3.Distance(oldPosition, transform.position);

        }
    }
}
