using UnityEngine;

public class GameEntity : MonoBehaviour
{

    protected GameManager GameManager;

    public void Initialize(GameManager gameManager)
    {
        GameManager = gameManager;
    }

    
}
