using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] private float stamina = 5f; // выносливость свиньи
    public GameObject onCollectEffect;

    private void OnCollisionEnter2D(Collision2D collision) // метод для столкновения
    {
        if (collision.relativeVelocity.magnitude > stamina) // если сила удара больше, чем выносливость
        {
            Destroy(gameObject); // то объект удаляется
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}
