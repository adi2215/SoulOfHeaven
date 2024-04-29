using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 2;
    public GameObject effect;


    public float Health
    {
        set {
            health = value;

            if (health <= 0)
                Defeated();
        }

        get {
            return health;
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    private void Defeated()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private float distance;
    public float speed;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero");
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
