using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Cauldron : MonoBehaviour
{
    private int food_need = 3;
    public bool solved = false;
    public GameObject filled;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("food")) 
        { 
            collision.gameObject.SetActive(false);
            food_need--;
            if (food_need == 0) 
            {
                solved = true;
                this.gameObject.SetActive(false);
                filled.SetActive(true);
            }
        }
    }
}
