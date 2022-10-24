using UnityEngine;
using TMPro;
using UnityEngine.UI;

/* Víctor Hernández 7-07-2022
 * 
 * Aquest script controla la mecànica principal, la dificultat i la puntuació a partir de les 
 * col·lisions dels elements.
 * 
 * - Si el quadrat col·lisiona amb un cercle VERD, se sumen els punt si es generen nou cercles vermells.
 * El nombre de cercles dependrà dels punts que tingui el jugador. Com més punts, més en sortiran.
 * 
 * - Si el quadrat col·lisiona amb un cercle VERMELL, es resten dos punts i el cercle desapareix.
 *
 * - Si el jugador arriba a 12, guanya. Si té una puntuació inferior a 0, perd. 
 * 
 */
public class GameManager : MonoBehaviour
{
    // Elements de la interfície
    [Header("Interface")]

    [SerializeField]
    private GameObject GameOver;

    [SerializeField]
    private GameObject HUD;

    [SerializeField]
    private TMP_Text GameOverText;

    [SerializeField]
    private TMP_Text ScoreText;


    // Prefabs per instanciar
    [Header("Prefabs")]
    [SerializeField]
    private GameObject BombPrefab;

    [SerializeField]
    private GameObject CoinPrefab;


    // Referència al jugador
    [Header("Player")]
    [SerializeField]
    private GameObject Prefab;

    // Altres propietats

    private int _points;

    public void IncreasePoints(int points)
    {
        _points += points;

        CheckGameOver();
        SpawnBombs();
    }

    public void Impact()
    {
        _points -= 2;

        CheckGameOver();
        SpawnBombs();

    }

    private void CheckGameOver()
    {
        if (IsGameOver())
        {
            Destroy(Prefab);
            DisplayGameOver();
        }
        else
        {
            ScoreText.text = _points.ToString();
        }
    }

    private bool IsGameOver()
    {
        if (_points < 0 || _points >= 12)
        {
            return true;
        }

        return false;
    }

    private void DisplayGameOver()
    {
        Color color = Color.green;
        string text = "YOU WIN!";


        if (_points < 12)
        {
            text = "YOU LOSE!";
            color = Color.white;
        }

        GameOverText.text = text;
        GameOverText.color = color;

        HUD.SetActive(false);
        GameOver.SetActive(true);
        
    }

    private void SpawnBombs()
    {
        /* Hem creat una fórmula per determinar quantes instàncies VERMELLES noves crearem,
         * segons la puntuació del joc.
         * Utilitzem un bucle per crear les instàncies noves.
         */
        int repeticions = Mathf.RoundToInt(_points / 3) + 1;

        for (int i = 0; i < repeticions; i++)
        {
            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        var position = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0);
        GameObject bomb = Instantiate(BombPrefab, position, Quaternion.identity);
        InitializeEntity(bomb);
    }

    private void InitializeEntity(GameObject entity)
    {
        GameEntity entityComponent = entity.GetComponent<GameEntity>();

        // Inicialitzem el component
        if (entityComponent != null)
        {
            entityComponent.Initialize(this);
        }
    }

    private void SpawnCoin()
    {
        var position = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0);
        GameObject coin = Instantiate(CoinPrefab, position, Quaternion.identity);
        InitializeEntity(coin);
    }


    void Start()
    {
        SpawnCoin();
    }

}
