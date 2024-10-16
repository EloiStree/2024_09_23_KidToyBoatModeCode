using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepWaterHeightWithScriptMono : MonoBehaviour
{
    public Transform m_whatToAffect;
    public Transform m_waterWorldLevel;
    public Rigidbody m_rigidbodyToAffect;
    public float m_heightAdjustement = 0.01f;

    void LateUpdate()
    {
        if (m_whatToAffect.position.y < m_waterWorldLevel.position.y)
        {
            Vector3 position = m_whatToAffect.position;
            position.y = m_waterWorldLevel.position.y+ m_heightAdjustement;
            m_whatToAffect.position = position;

            Vector3 velocity = Vector3.zero;

                velocity = m_rigidbodyToAffect.velocity;
        
            if(velocity.y < 0)
            {
                velocity.y = 0;
                m_rigidbodyToAffect.linearVelocity = velocity;
            }
            velocity.y = 0.01f;
            m_rigidbodyToAffect.linearVelocity = velocity;
        }

    }
}