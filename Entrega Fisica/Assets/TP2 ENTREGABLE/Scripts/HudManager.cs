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
    [SerializeField] Tanque _tankP1;
    [SerializeField] Tanque _tankP2;
    [SerializeField] Text _velP1;
    [SerializeField] Text _velP2;
    [SerializeField] Vida _vidaP1;
    [SerializeField] Vida _vidaP2;
    [SerializeField] Image _lifeP1;
    [SerializeField] Image _lifeP2;
    [SerializeField] GameObject _end;
    [SerializeField] Text _winner;
    GameManager _GM;
    float _lifePerP1;
    float _lifePerP2;

    private void Start()
    {
        _GM = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        _angleP1.text = "Angle: " + Mathf.FloorToInt(_cannonP1.eulerAngles.z).ToString();
        _angleP2.text = "Angle: " + Mathf.FloorToInt(_cannonP2.eulerAngles.z).ToString();
        _velP1.text = "Vel: " + (_tankP1.Vel2).ToString();
        _velP2.text = "Vel: " + (_tankP2.Vel1).ToString();

        _lifePerP1 = (float)_vidaP1.Life / 50f;
        _lifeP1.fillAmount = _lifePerP1;
        _lifePerP2 = (float)_vidaP2.Life / 50f;
        _lifeP2.fillAmount = _lifePerP2;

        if (_GM.GameOver)
        {
            _end.SetActive(true);
            if (_GM.SetTurn==true)
            {
                _winner.text = "Winner RIGHT";
            }
            if (_GM.SetTurn == false)
            {
                _winner.text = "Winner LEFT";
            }
        }
    }
}
