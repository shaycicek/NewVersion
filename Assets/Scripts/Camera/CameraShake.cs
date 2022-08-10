using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private void Update()
    {
        if(shakeTimer >0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer<=0f)
            {
                //BURADA KALDIN

                CinemachineBasicMultiChannelPerlin cinemachinePerlin =
                    cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachinePerlin.m_AmplitudeGain = 0f;
            }
        }
    }

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

    }

    public void ShakeCamera(float intensity , float time)
    {
        CinemachineBasicMultiChannelPerlin cmPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cmPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    

}
