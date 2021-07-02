using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecFile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    // Update is called once per frame

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Tags.Enemy.ToString()))
        {
            Destroy(col.gameObject);
            gameObject.SetActive(false);
        }
    }
}
