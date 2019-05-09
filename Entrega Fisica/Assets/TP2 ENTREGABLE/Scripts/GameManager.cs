using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    bool _turn; //TRUE->PLAYER1     FALSE->PLAYER2
    [SerializeField] Tanque _p1;
    [SerializeField] Tanque _p2;
    Vida _vidaP1;
    Vida _vidaP2;
    bool _gameOver = false;

    void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance!=this){
            Destroy(gameObject);
        }
    }

    void Start() {
        _turn = true;
        _vidaP1=_p1.GetComponent<Vida>();
        _vidaP2=_p2.GetComponent<Vida>();
    }

    void Update(){
        if (Input.GetButtonDown("Fire1"))
        {
            _turn = !_turn;
        }
        Debug.Log(_turn);

        if (_vidaP1.Life<=0 || _vidaP1.Life <= 0)
        {
            _gameOver = true;
        }
    }
    public bool SetTurn {
        get { return _turn; }
        set { _turn = !value; Debug.Log("set"); }
    }
    public bool GameOver {
        get { return _gameOver; }
    }
}
