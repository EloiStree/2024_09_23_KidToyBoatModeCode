using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoatOldWayMono : MonoBehaviour
{
    public Transform m_whatToMove;
    public float m_rotationPerSecond = 60;
    public float m_speedPerSeconds = 0.3f;

    //private float m_variableCacheToutLeMonde = 20;
    //[SerializeField]
    //private  float m_variableCacherAuDev = 20;
    //public int m_frame;
    //void Start()
    //{
    //    Debug.Log("Hello World"); 
    //}

    void Update()
    {
        //m_frame = m_frame + 1;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_whatToMove.Translate(Vector3.forward * m_speedPerSeconds * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_whatToMove.Translate(-1 * Vector3.forward * m_speedPerSeconds * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_whatToMove.Rotate(-1*Vector3.up * m_rotationPerSecond * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_whatToMove.Rotate(  Vector3.up * m_rotationPerSecond * Time.deltaTime);

        }

    }
}
