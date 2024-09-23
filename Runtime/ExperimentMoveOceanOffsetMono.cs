using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentMoveOceanOffsetMono : MonoBehaviour
{

    public Material m_material;
    public AnimationCurve m_moveOffsetX;
    public AnimationCurve m_moveOffsetY;
    public AnimationCurve m_moveTillngX;
    public AnimationCurve m_moveTillngY;


    public Vector3 m_tilingScale= Vector3.one*2f;

    public float m_timeModulo = 5;
    public string m_textureName= "_BaseMap";

    public void Update()
    {
        
        float time = Time.time % m_timeModulo;
        float percent = time / m_timeModulo;
        m_material.SetTextureOffset("_BaseMap", new Vector2(m_moveOffsetX.Evaluate(percent), m_moveOffsetY.Evaluate(percent)));
        m_material.SetTextureScale("_BaseMap", new Vector2(m_moveTillngX.Evaluate(percent)* m_tilingScale.x, m_moveTillngY.Evaluate(percent) * m_tilingScale.y));
    }




}
