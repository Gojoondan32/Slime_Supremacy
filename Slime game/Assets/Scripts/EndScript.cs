using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    
    public GameManager scoreFinal;
    [SerializeField] Text endScore;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Load the win screen
        SceneManager.LoadScene("Win Screen");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //endScore.text = scoreFinal.score.ToString("0");
    }
}
