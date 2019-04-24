using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField] Transform _cannonP1;
    [SerializeField] Transform _cannonP2;
    [SerializeField] Text _angleP1;
    [SerializeField] Text _angleP2;


    // Update is called once per frame
    void Update()
    {
        _angleP1.text ="Angle: " + Mathf.FloorToInt(_cannonP1.eulerAngles.z).ToString();
        _angleP2.text ="Angle: " + Mathf.FloorToInt(_cannonP2.eulerAngles.z).ToString();
    }
}
