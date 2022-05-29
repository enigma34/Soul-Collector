using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBulletsPickup : MonoBehaviour
{
    public int extraBulletsWithPickup = 15;
    Player player;

    void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
        
    }

    void Start()
    {
        try
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            Destroy(gameObject, 6.0f);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Game Over");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var currentBullets = player.nosOfProjectile;
            var bulletsAdded = currentBullets + extraBulletsWithPickup;
            if (bulletsAdded > player.maxNosOfProjectile)
                player.nosOfProjectile = player.maxNosOfProjectile;
            else
                player.nosOfProjectile = bulletsAdded;
            Debug.Log("You currently have " + player.nosOfProjectile + " Bullets.");
            Destroy(gameObject);
        }
        //else if (collision.CompareTag("Border"))
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
