using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PositionPlayerInGame : MonoBehaviour
{
    [Header("Player e Oponents")]
    public Transform player, opponent, opponent2;
    public int currentposition;
    int finalPosition;
    public Text positionText;
    public Text currentpositionText;
    public Text titulo;
    public SystemMainSwimmingV4 swimmingV4;
    public string sceneName;
    string vitoria = "Você Ganhou!";
    string derrota = "Você Perdeu!";
    bool finaldojogo;
    void Start()
    {
        
    }
    void Update()
    {
        if(player.position.z > opponent.position.z && player.position.z > opponent2.position.z)
        {
            currentposition = 1;   
            currentpositionText.text = currentposition.ToString();
        }
        if (player.position.z < opponent.position.z && player.position.z > opponent2.position.z && opponent2.position.z < opponent.position.z || player.position.z > opponent.position.z && player.position.z < opponent2.position.z && opponent2.position.z > opponent.position.z)
        {
            currentposition = 2;
            currentpositionText.text = currentposition.ToString();
        }
        if (player.position.z < opponent.position.z && player.position.z < opponent2.position.z)
        {
            currentposition = 3;
            currentpositionText.text = currentposition.ToString();
        }
        positionText.text = finalPosition.ToString();
        Debug.Log(finalPosition);
        finalPosition = currentposition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && finalPosition >= 1)
        {
            titulo.text = derrota;
            //DERROTA
            swimmingV4.GameOver();
            Debug.Log("Derrota");
            Debug.Log("Player foi");
        }
        if(other.gameObject.CompareTag("Player") && finalPosition <=1)
        {
            titulo.text = vitoria;
            //vitoria
            swimmingV4.Victory();
            Debug.Log("Vitoria");
        }
        if (other.gameObject.CompareTag("Opponent"))
        {
            finalPosition++;
            Debug.Log("Opponent foi");
        }

    }
    public void SairDoJogo()
    {
        SceneManager.LoadScene(sceneName);
    }
}
