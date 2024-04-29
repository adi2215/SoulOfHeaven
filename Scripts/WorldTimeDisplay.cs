using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldTimeDisplay : MonoBehaviour
{
    [SerializeField]
    private TimerDay worldTime;
    private Text text;
    public ManagerScene scene;

    private void Awake()
    {
        text = GetComponent<Text>();
        worldTime.WorldTimeChanged += OnWorldTimeChanged;
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        text.text = newTime.ToString(@"hh\:mm");
        if (text.text == "23:59")
        {
            //scene.Win();
        }
    }
}
