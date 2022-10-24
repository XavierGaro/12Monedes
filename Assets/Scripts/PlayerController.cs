using UnityEngine;

/* Víctor Hernández 7-07-2022
 * 
 * Aquest script controla els moviments del jugador. 
 * 
 * - Utilitzem el InputGetAxis per controlar la posició en l'eix horitzontal i vertical. Amb
 * el mètode transform. Translate desplacem el jugador per la pantalla.
 *
 */
public class PlayerController : MonoBehaviour
{
    private float _x;
    private float _y;
    private int _speed = 5;
    private Renderer _quadrat;

    [SerializeField]
    private Color _color = Color.white;
    
    private void Start()
    {
        // Guardem la referència al Renderer, que en aques cas 
        // serà un Sprite Renderer. Això ens permetrà modificar
        // el seu color
        _quadrat = GetComponent<Renderer>();        
        ChangeColor(_color);        
    }
    
    private void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
        transform.Translate(_x * _speed * Time.deltaTime, _y * _speed * Time.deltaTime, 0);
    }

    public void ChangeColor(Color color)
    {
        _quadrat.material.SetColor("_Color", color);
    }    
}
