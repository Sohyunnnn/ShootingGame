using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float speed = 5;

    Vector3 dir;

    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        int randValue = Random.Range(0, 10);


        if(randValue<3)
        {
            GameObject target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.down;

        transform.position += dir * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        //GameObject smObject = GameObject.Find("ScoreManager");
        // ScoreManager sm = smObject.GetComponent<ScoreManager>();
        //sm.SetScore(sm.GetScore() + 1);

        //ScoreManager.Instance.SetScore(ScoreManager.Instance.GetScore() + 1);
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);

        explosion.transform.position = transform.position;

        //Destroy(other.gameObject);

        if(other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();

            player.bulletObjectPool.Add(other.gameObject);
        }    
        else
        {
            Destroy(other.gameObject);
        }
        //Destroy(gameObject);
        gameObject.SetActive(false);

        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        manager.enemyObjectPool.Add(gameObject);
    }
}
