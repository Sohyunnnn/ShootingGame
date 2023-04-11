using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;

    //GameObject[] bulletObjectPool; -> 정적배열
    public List<GameObject> bulletObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        //bulletObjectPool = new GameObject[poolSize];
        bulletObjectPool = new List<GameObject>();

        for (int i=0; i<poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            //bulletObjectPool[i] = bullet;
            bulletObjectPool.Add(bullet);

            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //GameObject bullet = Instantiate(bulletFactory);

            //bullet.transform.position = firePosition.transform.position;

           // for(int i=0; i<poolSize; i++)
            //{
                //GameObject bullet = bulletObjectPool[i];

                /*(if (bullet.activeSelf==false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = transform.position;
                    break;
                }    */
            //}
            if(bulletObjectPool.Count>0)
            {
                GameObject bullet = bulletObjectPool[0];
                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);

                bullet.transform.position = transform.position;
            }
        }
    }
}
