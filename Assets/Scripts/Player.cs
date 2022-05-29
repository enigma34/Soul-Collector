using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float playerSpeed;
    Rigidbody2D rb;
    Vector2 playerDirection;
    public Transform mProjectile;
    public float mProjectileSpeed = 8f;
    public int nosOfProjectile = 20;
    public int maxNosOfProjectile = 80;
    //public BackgroundMusic sfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // sfx = gameObject.GetComponent<BackgroundMusic>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;

        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        if (nosOfProjectile>0)
        {
            var clone = Instantiate(mProjectile, rb.transform.position, Quaternion.Euler(new Vector2(0, 0)));
            //sfx.BulletFireSFX();
            clone.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(mProjectileSpeed, 0);
            nosOfProjectile--;
        }
        Debug.Log($"Bullets remaing: {nosOfProjectile}");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);    
    }
}
