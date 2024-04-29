using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public int health = 3;
    public float timer = 0;
    public ManagerScene scene;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("enemy") && timer <= 0)
        {
            health -= 1;
            timer = 1;
        }
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }

        if (health <= 0)
        {
            scene.Lose();
        }
    }
}
