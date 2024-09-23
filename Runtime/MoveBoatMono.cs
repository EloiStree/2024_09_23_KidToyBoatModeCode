using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoatMono : MonoBehaviour
{

    public Transform m_whatToMove;
    public float m_moveForwardSpeed = 0.3f;
    public float m_moveBackwardSpeed = 0.15f;
    public float m_rotateSpeed = 60;

    [Range(-1f, 1f)]
    public float m_percentLeftRight;
    [Range(-1f,1f)]
    public float m_percentBackForward;


    public void SetLeftRightPercent(float percent)
    {
        m_percentLeftRight = percent;
    }
    public void SetBackForwardPercent(float percent)
    {
        m_percentBackForward = percent;
    }

    private void Reset()
    {
        m_whatToMove = transform;
    }

    void Update()
    {

        float moveSpeed = m_moveForwardSpeed;
        if(m_moveBackwardSpeed < 0)
        {
            moveSpeed = m_moveBackwardSpeed;
        }

        float percentRotation = m_percentLeftRight * m_percentBackForward;
        if (Mathf.Abs(percentRotation) < 0.1f) {
            percentRotation = 0;
        }
        m_whatToMove.Translate( Vector3.forward * moveSpeed * m_percentBackForward * Time.deltaTime);
        m_whatToMove.Rotate( Vector3.up * m_rotateSpeed  * percentRotation * Time.deltaTime);
    }
}
