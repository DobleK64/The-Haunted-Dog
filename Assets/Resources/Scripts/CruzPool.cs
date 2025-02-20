using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzPool : MonoBehaviour
{
    public GameObjectPool bulletPool;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject obj = bulletPool.GimmeInactiveGameObject();

            if (obj)
            {
                obj.SetActive(true); // ya no esta disponible en la pool
                Vector3 cruzpos = new Vector3(transform.position.x, transform.position.y, transform.position.z * 1);
                obj.transform.rotation = Quaternion.LookRotation(cruzpos);
                obj.transform.position = cruzpos;
                obj.GetComponent<Cruz>().SetDirection(transform.forward);
            }
            
        }
    }
}
