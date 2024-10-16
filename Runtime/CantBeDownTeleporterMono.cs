using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantBeDownTeleporterMono : MonoBehaviour
{
    public Transform m_whatToObserve;
    public Transform m_savePoint;

    public Rigidbody m_whatToAffect;
    public float m_whatItDown = -20;

    
    void Update()
    {
        if(m_whatToObserve.position.y< m_whatItDown)
            {
            m_whatToObserve.position = m_savePoint.position; 
            m_whatToAffect.linearVelocity = Vector3.zero;
        }

    }
}
