using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void Start()
    {
        Destroy(gameObject, 0.75f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("UI")){
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.55f);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("perna"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.55f);
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Victory");
        }
        if (collision.gameObject.CompareTag("protetor"))
        {
            Destroy(collision.gameObject);
        }
    }
    void OnDestroy()
    {   
        
    }
}
