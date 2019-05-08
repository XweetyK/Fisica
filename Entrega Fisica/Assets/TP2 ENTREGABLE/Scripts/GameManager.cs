using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    bool _turn; //TRUE->PLAYER1     FALSE->PLAYER2
    Tanque[] _tank;

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
        _tank = FindObjectsOfType<Tanque>();
    }

    void Update(){
        if (Input.GetButtonDown("Fire1"))
        {
            _turn = !_turn;
        }
        TurnUpdate();
    }
    void TurnUpdate() {
        Debug.Log("turn change");
        foreach (var tank in _tank)
        {
            tank.Turn = _turn;
        }
    }
}
