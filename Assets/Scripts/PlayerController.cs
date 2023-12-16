/*  Amal Presingu
 *  9/17/2021
 *  Programming gameplay features
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    private int count;
 
    public Text winText;
    public Text overText;
    public Button restartButton;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //after game ends, it will start again
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = " "; //empty for now
        overText.text = " ";
        restartButton.gameObject.SetActive(false); //hide button

        Invoke("winCondition", 60); //calling on winCondition after 60 seconds 
    }

    // FixedUpdate is in sync with physics engine
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = (movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); //disappear from scene
            count++;

        }
        if (count >= 1)
        {
            overText.text = "Game Over"; //display text 
            restartButton.gameObject.SetActive(true); //show button after game ends
            //object collisions may still happen (instructions)
            Time.timeScale = 0; //freezing game for effect; player can hit restart button after
        }
        
    }

    public void winCondition()
    {
        winText.text = "You win";
        restartButton.gameObject.SetActive(true);
        Time.timeScale = 0; //freezing game for effect; player can hit restart button after
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene"); //restart the game
    }
}
