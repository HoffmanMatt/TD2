using UnityEngine;
using System.Collections;
using System;

public class ClickManager : MonoBehaviour {

    public const double MAX_TIME_TO_CLICK = 0.4f;
    public const double MIN_TIME_TO_CLICK = 0.05;

    private TimeSpan maxDuration = TimeSpan.FromSeconds(MAX_TIME_TO_CLICK);
    private TimeSpan minDuration = TimeSpan.FromSeconds(MIN_TIME_TO_CLICK);

    private System.Diagnostics.Stopwatch timer;
    private bool ClickedOnce = false;

    // Use this for initialization

    public bool DoubleClick()
    {
        if (!ClickedOnce)
        {
            timer = System.Diagnostics.Stopwatch.StartNew();
            ClickedOnce = true;
        }
        if (ClickedOnce)
        {
            if (timer.Elapsed > minDuration && timer.Elapsed < maxDuration)
            {
                //Debug.Log("Double Click");
                ClickedOnce = false;
                return true;
            }
            else if (timer.Elapsed > maxDuration)
            {
                ClickedOnce = false;
                //Debug.Log("Time out");
                return false;
            }
        }
        return false;
    }
}
