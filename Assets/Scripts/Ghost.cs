using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public static int totalSouls = 0;
    bool freeSoul=false;
    public Sprite[] soulSprites = new Sprite[2];
    bool ghostJudged = false;

    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    void Start()
    {
        Destroy(gameObject, 6.0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && freeSoul)
        {
            totalSouls++;
            //Debug.Log("You currently have "+Ghost.totalSouls + " Souls.");
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Ghost Shoot");
            if(!ghostJudged) 
                GhostJudge(collision.gameObject);
        }
    }

    bool GhostJudge(GameObject go)
    {
        int randomBinary = Random.Range(0, 2);
        if (randomBinary == 1 && ghostJudged == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = soulSprites[1];
            gameObject.GetComponent<Transform>().localScale = new Vector3(1.4f,1.4f,0);
            freeSoul = true;
            ghostJudged = true;
        }
        else if (randomBinary == 0 && ghostJudged == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = soulSprites[0];
            gameObject.GetComponent<Transform>().localScale = new Vector3(1.4f, 1.4f, 0);
            freeSoul = false;
            ghostJudged = true;
        }
        Destroy(go);
        //Destroy(gameObject);
        return ghostJudged;
    }
}
