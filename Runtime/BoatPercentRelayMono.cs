using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoatPercentRelayMono : MonoBehaviour
{

    [Range(-1f,1f)]
    public float m_givenPercent;
    public bool m_useClamp;

    public UnityEvent<float> m_onPercentChanged;


    public void SetPercent(float percent)
    {
        if(m_useClamp)
        {
            percent = Mathf.Clamp(percent, -1f, 1f);
        }
        if(percent == m_givenPercent)
        {
            return;
        }
        m_givenPercent = percent;
        m_onPercentChanged.Invoke(percent);
    }
}
