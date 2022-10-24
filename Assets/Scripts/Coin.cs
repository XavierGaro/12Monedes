using UnityEngine;


public class Coin : GameEntity
{

    // Nombre de punts que rebrà el jugador en tocar aquest objecte
    [SerializeField]
    private int Points = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Pickup();
        }

    }

    protected void Pickup()
    {
        GameManager.IncreasePoints(Points);

        // Canviem la posició a un punt aleatori dins de la pantalla
        Vector3 newPosition = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0);
        transform.localPosition = newPosition;
    }

}
