using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    enum BulletType { Deflectable, Damage, Heal, PowerUp }

    [SerializeField] private BulletType bulletType;
    public float bulletLife = 1.0f;
    public float rotation = 0.0f;
    public float speed = 1.0f;
    private bool deflected = false;
    private Vector2 spawnPoint;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;

        transform.position = Movement(timer, deflected);
    }

    private Vector2 Movement(float timer, bool deflected)
    {
        if (deflected)
        {
            // Sends the bullet back
            float x = timer * -speed * transform.right.x;
            float y = timer * -speed * transform.right.y;
            return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
        }
        else
        {
            // Moves right according to the bullet's rotation
            float x = timer * speed * transform.right.x;
            float y = timer * speed * transform.right.y;
            return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
        }
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (bulletType == BulletType.Deflectable && other.CompareTag("Player"))
        {
            deflected = true;
        }
    }
}
