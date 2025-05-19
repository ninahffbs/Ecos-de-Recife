using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    float direcao = 0;
    private bool facingR = true;
    public GameObject lama1Prefab;
    public float bulletforce = 20f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        direcao = Input.GetAxisRaw("Horizontal");
        if(direcao > 0 && !facingR)
        {
            flip();
        }
        if (direcao < 0 && facingR)
        {
            flip();
        }
    }
    void Shoot()
    {
        GameObject lama1 = Instantiate(lama1Prefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = lama1.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.transform.localScale * bulletforce, ForceMode2D.Impulse);
    }
    void flip()
    {
        Vector3 currentScale = firepoint.transform.localScale;
        currentScale.x *= -1;
        firepoint.transform.localScale = currentScale;
        facingR = !facingR;
    }
}
