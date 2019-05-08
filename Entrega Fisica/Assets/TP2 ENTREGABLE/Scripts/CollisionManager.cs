using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] int _LayerCount;
    public static CollisionManager instance = null;
    List<List<CollisionBox>> colliders;

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

    void Start() {
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
        else
        {
            Debug.Log("ERROR LAYER EXCEEDS LAYERCOUNT");
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

    public bool CheckCollisions(ref CollisionBox objectToCheck, int layer, ref CollisionBox collision)
    {
        for (int i = 0; i < colliders[layer].Count; i++)
        {
            CollisionBox other = colliders[layer][i];
            if (other == objectToCheck)
            {
                break;
            }
            Vector3 diff = objectToCheck.transform.position - other.transform.position;
            diff = new Vector3(Mathf.Abs(diff.x), Mathf.Abs(diff.y), Mathf.Abs(diff.z));
            if (diff.x <= (objectToCheck.Width + other.Width) / 2.0f &&
               diff.y <= (objectToCheck.Height + other.Height) / 2.0f)
            {
                collision = other;
                return true;
            }
        }
        return false;
    }
    public bool CheckCollisions(ref CollisionBox objectToCheck, int layer)
    {
        for (int i = 0; i < colliders[layer].Count; i++)
        {
            CollisionBox other = colliders[layer][i];
            if (other == objectToCheck)
            {
                break;
            }
            Vector3 diff = objectToCheck.transform.position - other.transform.position;
            diff = new Vector3(Mathf.Abs(diff.x), Mathf.Abs(diff.y), Mathf.Abs(diff.z));
            if (diff.x <= (objectToCheck.Width + other.Width) / 2.0f &&
               diff.y <= (objectToCheck.Height + other.Height) / 2.0f)
            {
                return true;
            }
        }
        return false;
    }
}
