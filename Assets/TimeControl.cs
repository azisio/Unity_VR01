using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    [SerializeField]
    private GameObject hourObj,minuteObj,secondObj;

    private const float secRotateRatio = 6.0f;
    private const float minRotateRatio = 6.0f;
    private const float hourRotateRatio = 30.0f;
    private const float hourminRotateRatio = 0.5f;

    void Start()
    {
        InvokeRepeating(nameof(RotateClockHands), 0.0f, 1.0f);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }

    private void RotateClockHands()
    {
        var nowTime = DateTime.Now;

        secondObj.transform.rotation = Quaternion.Euler(nowTime.Second * secRotateRatio, 0.0f, 0.0f);
        minuteObj.transform.rotation = Quaternion.Euler(nowTime.Minute * minRotateRatio, 0.0f, 0.0f);
        hourObj.transform.rotation   = Quaternion.Euler(nowTime.Hour   * hourRotateRatio + nowTime.Minute * hourminRotateRatio, 0.0f, 0.0f);
    }
}
