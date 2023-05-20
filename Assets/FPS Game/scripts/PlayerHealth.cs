using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int HP = 100;
    public Slider PlayerHP;
    public GameObject gameoverWindow;
    public GameObject backToMainMenu;

 

    void Start()
    {
        PlayerHP.value = HP;
        gameoverWindow.SetActive(false);
        backToMainMenu.SetActive(false);

    }
    private void Update()
    {
       PlayerHP.value = HP;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log("take damage");

        if (HP <= 0)
        {
            Debug.Log("Enemy died");

            DisplayGameOver();

        }
    }

    public void DisplayGameOver()
    {
        gameoverWindow.SetActive(true);
        backToMainMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }


}
