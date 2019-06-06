using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float _limitY;
    [SerializeField] float _restartY;

    void Update()
    {
        Mov();
        if (transform.position.y<_limitY){
            transform.position = new Vector3(0,_restartY, 0);
        }
    }
    void Mov(){
        transform.Translate(-Vector3.up * Time.deltaTime);
    }
}
