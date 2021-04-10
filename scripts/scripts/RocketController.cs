using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class RocketController : MonoBehaviour
{
    public float speed;
    public float rotationOffset;
    public ParticleSystem rocketExplode;
    public GameObject gameOver;
    public GameObject nextLevel;

    public AudioSource youWinSound;
    public AudioSource youLoseSound;

    public GameObject rocketSprite;
    public GameObject rocketShadow;

    bool canMove;
    bool canBeHurt;

    BoxCollider2D box;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        canMove = true;
        canBeHurt = true;
        gameOver.SetActive(false);
        nextLevel.SetActive(false);
        box.isTrigger = false;
    }

    void Update()
    {
        if (canMove)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 0;
            Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
            mousePosition.x -= objectPosition.x;
            mousePosition.y -= objectPosition.y;

            float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            UtilsClass.ShakeCamera(0.01f, 0.01f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Meterorite")
        {
            if(canBeHurt == true)
            {
                Instantiate(rocketExplode, transform.position, transform.rotation);
                gameOver.SetActive(true);
                UtilsClass.ShakeCamera(0.2f, 0.2f);
                canMove = false;
                youLoseSound.Play();
                Destroy(rocketSprite.gameObject);
                Destroy(rocketShadow.gameObject);
                box.isTrigger = true;
            }
            
        }

        if (col.gameObject.tag == "Threat")
        {
            if (canBeHurt == true)
            {
                Instantiate(rocketExplode, transform.position, transform.rotation);
                gameOver.SetActive(true);
                UtilsClass.ShakeCamera(0.2f, 0.2f);
                canMove = false;
                youLoseSound.Play();
                Destroy(rocketSprite.gameObject);
                Destroy(rocketShadow.gameObject);
                box.isTrigger = true;
            }

        }

        if (col.gameObject.tag == "o")
        {
            canMove = false;
            canBeHurt = false;
            nextLevel.SetActive(true);
            youWinSound.Play();
            UtilsClass.ShakeCamera(0.2f, 0.2f);
            Destroy(rocketSprite.gameObject);
            Destroy(rocketShadow.gameObject);
            box.isTrigger = true;
        }
    }
}
