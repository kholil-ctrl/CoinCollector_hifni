using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Sistem Koin")]
    public int totalKoin;
    private int koinTerkumpul = 0;
    public TMP_Text teksSkor;     
    public TMP_Text teksMenang;   

    [Header("Sistem Kematian Zombie")]
    [SerializeField] private int skorZombie = 0;

    void OnEnable()
    {
        Enemy.OnZombieMati += TambahSkorSaatZombieMati;
    }

    void OnDisable()
    {
        Enemy.OnZombieMati -= TambahSkorSaatZombieMati;
    }

    void TambahSkorSaatZombieMati(Enemy zombieYangMati)
    {
        skorZombie += 10;
        Debug.Log("Skor Zombie: " + skorZombie + " | Zombie dikalahkan: " + zombieYangMati.name);
    }

    void Start()
    {
        Time.timeScale = 1f; 
        totalKoin = GameObject.FindGameObjectsWithTag("Coin").Length;

        if (teksMenang != null)
        {
            teksMenang.gameObject.SetActive(false);
        }

        UpdateSkorUI();
    }

    public void AmbilKoin()
    {
        koinTerkumpul++;
        UpdateSkorUI();
        
        if (koinTerkumpul >= totalKoin && totalKoin > 0) 
        {
            Menang();
        }
    }

    void UpdateSkorUI()
    {
        if (teksSkor != null)
        {
            teksSkor.text = "Koin: " + koinTerkumpul + " / " + totalKoin;
        }
    }

    void Menang()
    {
        if (teksMenang != null)
        {
            teksMenang.gameObject.SetActive(true);
        }
        Time.timeScale = 0f; 
    }
}