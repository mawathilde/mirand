using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public float invisiblityFlashDelay = 0.2f;
    public float invisiblityDuration = 2.5f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvisibilityFlash());
            StartCoroutine(HandleInvisibilityDelay());
        }
    }

    public IEnumerator InvisibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invisiblityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invisiblityFlashDelay);
        }
    }

    public IEnumerator HandleInvisibilityDelay()
    {
        yield return new WaitForSeconds(invisiblityDuration);
        isInvincible = false;
    }

}
