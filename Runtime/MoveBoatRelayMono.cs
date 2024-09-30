using UnityEngine;
using UnityEngine.Events;

public class MoveBoatRelayMono : MonoBehaviour {

    [Range(-1f,1f)]
    public float m_percentBackForward;

    [Range(-1f, 1f)]
    public float m_percentLeftRight;

    public UnityEvent<float> m_onPercentBackForward;
    public UnityEvent<float> m_onPercentLeftRight;

    public bool m_useUpdate = true;

    public void Update()
    {
        if (m_useUpdate)
        {
            SetLeftRightPercent(m_percentLeftRight);
            SetBackForwardPercent(m_percentBackForward);
        }
    }

    public void SetLeftRightPercent(float percent)
    {
        m_percentLeftRight = percent;
        m_onPercentLeftRight.Invoke(percent);
    }
    public void SetBackForwardPercent(float percent)
    {
        m_percentBackForward = percent;
        m_onPercentBackForward.Invoke(percent);
    }

}
