using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _cars;
    [SerializeField] private int _initY;
    [SerializeField] private float _interval;
    int _randCar;
    float _randX;
    float _randInter;
    Vector3 _pos;
    Quaternion _rot = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        _randInter = Random.Range((_interval - 3f), (_interval));
        InvokeRepeating("Randomizer", _randInter, _randInter);
    }

    private void Update()
    {
        _randCar = Random.Range(0, 6);
        _randX = Random.Range(-3.5f, 3.5f);
        _randInter = Random.Range((_interval - 3f), (_interval));
    }

    void Randomizer()
    {
        _pos = new Vector3(_randX, _initY, 0);
        switch (_randCar)
        {
            case 0:
                Instantiate(_cars[0],_pos,_rot);
                break;
            case 1:
                Instantiate(_cars[1], _pos, _rot);
                break;
            case 2:
                Instantiate(_cars[2], _pos, _rot);
                break;
            case 3:
                Instantiate(_cars[3], _pos, _rot);
                break;
            case 4:
                Instantiate(_cars[4], _pos, _rot);
                break;
            case 5:
                Instantiate(_cars[5], _pos, _rot);
                break;
        }
    }
}


