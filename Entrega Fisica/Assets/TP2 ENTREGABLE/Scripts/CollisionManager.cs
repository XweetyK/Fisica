using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] int _LayerCount;
    public static CollisionManager instance = null;
    List<List<CollisionBox>> colliders;
    Vector2 _dif;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        colliders = new List<List<CollisionBox>>();
        for (int i = 0; i < _LayerCount; i++)
        {
            colliders.Add(new List<CollisionBox>());
        }
    }

    void Update()
    {
        RemoveEntity();
    }

    public void AddEntity(int layer, CollisionBox boxCollider)
    {
        if (layer <= _LayerCount)
        {
            colliders[layer].Add(boxCollider);
        }
    }
    void RemoveEntity()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            for (int j = 0; j < colliders[i].Count; j++)
            {
                if (colliders[i][j] == null)
                {
                    colliders[i].RemoveAt(j);
                }
            }
        }
    }

    public bool CheckCollisions(int layer, ref CollisionBox collision)
    {
        for (int i = 0; i < colliders[layer].Count; i++)
        {
            CollisionBox other = colliders[layer][i];
            _dif = new Vector2(Mathf.Abs(other.transform.position.x - collision.transform.position.x), Mathf.Abs(other.transform.position.y - collision.transform.position.y));
            if (_dif.x <= (collision.Width + other.Width) / 2.0f && _dif.y <= (collision.Height + other.Height) / 2.0f)
            {
                return true;
            }
        }
        return false;
    }
}
