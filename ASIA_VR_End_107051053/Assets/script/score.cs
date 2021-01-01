using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    [Header("txet")]
    public Text text;
    [Header("score")]
    public int hp = 50;
    [Header("ball in")]
    public int hit = 10;

    public Animator anim;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "atk")
        {
            addi();
        }
    }

    private void addi()
    {
        hp -= hit;
    }       
}
