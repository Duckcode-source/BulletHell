using UnityEngine;
using System; // [THÊM VÀO] Khai báo thư viện System để dùng Action

public class PlayerHealth : MonoBehaviour
{
    [Header("Chỉ số Sinh tồn")]
    public int maxHealth = 3;
    public int currentHealth;

    // [THÊM VÀO] Loa phát thanh: Gửi đi 2 con số (Máu hiện tại, Máu tối đa)
    public static event Action<int, int> OnHealthChanged; 

    private PlayerController playerController;

    void Start()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerController>();
        
        // [THÊM VÀO] Phát thông báo lần đầu tiên khi vào game để UI vẽ trái tim
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        if (playerController != null && playerController.isRolling) return; 

        currentHealth -= damageAmount;
        
        // [THÊM VÀO] Phát thông báo máu đã giảm
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0) Die();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        
        // [THÊM VÀO] Phát thông báo máu đã tăng
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void IncreaseMaxHealth(int extraHealth)
    {
        maxHealth += extraHealth;
        currentHealth += extraHealth; 
        
        // [THÊM VÀO] Phát thông báo giới hạn máu đã tăng
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void Die()
    {
        gameObject.SetActive(false); 
    }
    
    // (Giữ nguyên các hàm OnTriggerEnter2D và OnCollisionEnter2D)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) TakeDamage(1);
    }
}