using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameObjectPool : MonoBehaviour
{
    public GameObject objectToPool;
    [Tooltip("Initial poolsize")]
    public uint poolSize;  // entero sin signo
    [Tooltip("If true, size increments")]
    public bool shouldExpand = false;

    private List<GameObject> _pool;

    // Start is called before the first frame update
    void Start()
    {
        _pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            AddGameObjectToPool();
        }
    }

    public GameObject GimmeInactiveGameObject()
    {
        foreach (GameObject obj in _pool)
        {
            if (!obj.activeSelf) //desactivado = guardado 
            {
                return obj;
            }
        }

        if (shouldExpand)
        {
            return AddGameObjectToPool();
        }

        return null;
    }
    private GameObject AddGameObjectToPool()
    {
        GameObject clone = Instantiate(objectToPool);
        clone.SetActive(false);  // se desactiva para que pueda ser usado
        _pool.Add(clone);
        return clone;        
    }
}