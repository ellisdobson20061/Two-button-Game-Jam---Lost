using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    private Transform Player;

    public float lineOfSite;

    public float speedMin;
    public float speedMax;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = Random.Range(speedMin, speedMax);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(Player.position, transform.position);

        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.position, speed * Time.deltaTime);
            UtilsClass.ShakeCamera(0.07f, 0.2f);
        }

    }
}
