using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                    // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    private Rigidbody2D rb2d;
    public int damage = 10;
    Animator anim;                                              // Reference to the Animator component.
    //AudioSource playerAudio;                                           // Whether the player is dead.
    bool damaged;     
    void Awake()
    {
        currentHealth = startingHealth;
        healthSlider.value = (startingHealth * 1.00f) / startingHealth;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (damaged)
        {
            damageImage.color = Color.clear;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, flashColour, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = (currentHealth * 1.00f) / startingHealth;
        rb2d.AddForce(new Vector2(-200, 300));
        //playerAudio.Play();
        if (currentHealth > 0)
            anim.SetTrigger("TakeDamage");
        if (currentHealth <= 0 && GameControl.instance.IsAlive())
            Death();
    }
    void Death()
    {
        GameControl.instance.NotAlive();
        anim.SetTrigger("Die");
    }
    public int attack()
    {
        return damage;
    }
}