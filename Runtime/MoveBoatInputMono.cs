using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class MoveBoatInputMono : MonoBehaviour
{
    public InputActionReference m_moveBackForward;
    public InputActionReference m_rotateLeftRight;
    public InputActionReference m_singleJoystick;

    [Range(-1, 1)]
    public float m_percentBackForward11;
    [Range(-1,1)]
    public float m_percentRotateLeftRight11;

    public UnityEvent<float> m_onLeftRightPercentChanged;
    public UnityEvent<float> m_onBackForwardPercentChanged;

    public void OnEnable()
    {
        if(m_moveBackForward)
        m_moveBackForward.action.Enable();
        if(m_rotateLeftRight)
        m_rotateLeftRight.action.Enable();
        if(m_singleJoystick)
        m_singleJoystick.action.Enable();

        if (m_moveBackForward) { 
            m_moveBackForward.action.performed += OnMoveBackForward;
            m_moveBackForward.action.canceled += OnMoveBackForward;
        }
        if (m_rotateLeftRight) { 
            m_rotateLeftRight.action.performed += OnRotateLeftRight;
            m_rotateLeftRight.action.canceled += OnRotateLeftRight;
        
        }
        if(m_singleJoystick)
        {
            m_singleJoystick.action.performed += OnSingleJoystick;
            m_singleJoystick.action.canceled += OnSingleJoystick;
        }
    }

    public void OnDisable()
    {
        if(m_moveBackForward)
            m_moveBackForward.action.Disable();
        if(m_rotateLeftRight)
            m_rotateLeftRight.action.Disable();
        if(m_singleJoystick)
            m_singleJoystick.action.Disable();

        if(m_moveBackForward)
        {
            m_moveBackForward.action.performed -= OnMoveBackForward;
            m_moveBackForward.action.canceled -= OnMoveBackForward;
        }
        if(m_rotateLeftRight)
        {
            m_rotateLeftRight.action.performed -= OnRotateLeftRight;
            m_rotateLeftRight.action.canceled -= OnRotateLeftRight;

        }
        if(m_singleJoystick)
        {
            m_singleJoystick.action.performed -= OnSingleJoystick;
            m_singleJoystick.action.canceled -= OnSingleJoystick;
        }
    }

    private void OnSingleJoystick(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        float x = value.x;
        float y = value.y;
        if (m_percentRotateLeftRight11 != x)
        {
            m_percentRotateLeftRight11 = x;
            m_onLeftRightPercentChanged.Invoke(m_percentRotateLeftRight11);
        }
        if (m_percentBackForward11 != y)
        {
            m_percentBackForward11 = y;
            m_onBackForwardPercentChanged.Invoke(m_percentBackForward11);
        }

    }

    private void OnRotateLeftRight(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (m_percentRotateLeftRight11 != value)
        {
            m_percentRotateLeftRight11 = value;
            m_onLeftRightPercentChanged.Invoke(m_percentRotateLeftRight11);
        }
       
    }

    private void OnMoveBackForward(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (m_percentBackForward11 != value)
        {
            m_percentBackForward11 = value;
            m_onBackForwardPercentChanged.Invoke(m_percentBackForward11);
        }
    }




    // Could be the solution but it's not the best one
    //void Update()
    //{
    //    float valueBackForward = m_moveBackForward.action.ReadValue<float>();
    //    float valueRotateLeftRight = m_rotateLeftRight.action.ReadValue<float>();
    //    if (m_percentBackForward11 != valueBackForward)
    //    {
    //        m_percentBackForward11 = valueBackForward;
    //        m_onBackForwardPercentChanged.Invoke(m_percentBackForward11);
    //    }
    //    if (m_percentRotateLeftRight11 != valueRotateLeftRight)
    //    {
    //        m_percentRotateLeftRight11 = valueRotateLeftRight;
    //        m_onLeftRightPercentChanged.Invoke(m_percentRotateLeftRight11);
    //    }
    //}
}
