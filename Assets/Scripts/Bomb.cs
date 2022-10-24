using UnityEngine;



public class Bomb : GameEntity
{    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {       
            Explode();
        }

    }

    private void Explode()
    {
        GameManager.Impact();
        Destroy(gameObject);
    }

}
