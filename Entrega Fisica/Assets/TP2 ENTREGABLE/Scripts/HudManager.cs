﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField] Transform _cannonP1;
    [SerializeField] Transform _cannonP2;
    [SerializeField] Text _angleP1;
    [SerializeField] Text _angleP2;
    [SerializeField] Tanque _tankP1;
    [SerializeField] Tanque _tankP2;
    [SerializeField] Text _velP1;
    [SerializeField] Text _velP2;


    void Update()
    {
        _angleP1.text = "Angle: " + Mathf.FloorToInt(_cannonP1.eulerAngles.z).ToString();
        _angleP2.text = "Angle: " + Mathf.FloorToInt(_cannonP2.eulerAngles.z).ToString();
        _velP1.text = "Vel: " + (_tankP1.Vel2).ToString();
        _velP2.text = "Vel: " + (_tankP2.Vel1).ToString();
    }
}
