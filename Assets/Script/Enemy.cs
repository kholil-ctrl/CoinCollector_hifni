using System;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Config Data Musuh")]
    [SerializeField] protected ZombieConfig config; 

    private int hp;
    public float ms;
    private float jarakdeteksi;
    private float jarakserang;
    private float jedaserang;

    protected Transform player;
    
    [Header("Pengaturan State Machine")]
    private StateZombie State = StateZombie.IDLE;
    private float WaktuSerangTerakhir;

    public static event Action<Enemy> OnZombieMati;
    [SerializeField] private UnityEvent onZombieMatiVisual;

    protected virtual void Start()
    {
        if (config != null)
        {
            hp = config.hp;
            ms = config.kecepatan;
            jarakdeteksi = config.jarakDeteksi;
            jarakserang = config.jarakSerang;
            jedaserang = config.jedaSerang;
        }
        else
        {
            Debug.LogWarning("ZombieConfig belum dimasukkan ke " + gameObject.name);
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    public float JarakKePlayer()
    {
        if (player == null) return Mathf.Infinity;
        return Vector2.Distance(transform.position, player.position);
    }

    void Update()
    {
        PeriksaTransisi();

        switch (State)
        {
            case StateZombie.IDLE: PerilakuIdle(); break;
            case StateZombie.PATROL: PerilakuPatrol(); break;
            case StateZombie.CHASE: PerilakuChase(); break;
            case StateZombie.ATTACKk: PerilakuAttack(); break; 
        }
    }

    void PeriksaTransisi()
    {
        float jarak = JarakKePlayer();

        if (jarak <= jarakserang)
        {
            State = StateZombie.ATTACKk; 
        } 
        else if (jarak <= jarakdeteksi)
        {
            State = StateZombie.CHASE;
        }
        else 
        {
            State = StateZombie.PATROL;
        }
    }
    
    void PerilakuIdle()
    {
         Debug.Log(name + ": IDLE");
    }

    void PerilakuPatrol()
    {
         Debug.Log(name + ": PATROL");
    }

    void PerilakuChase()
    {
        Kejar();
    }
    
    void PerilakuAttack()
    {
        Serang();
    }

    public void Kejar()
    {
        if (player == null) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            ms * Time.deltaTime
        );
    }

    public virtual void Serang()
    {
        Debug.Log("Enemy menyerang!");
    }

    public void KenaDamage(int jumlah)
    {
        hp -= jumlah;
        Debug.Log($"{gameObject.name} kena damage {jumlah}, HP sisa: {hp}");

        if (hp <= 0)
        {
            Mati();
        }
    }

    protected virtual void Mati() 
    {
        Debug.Log(name + " kalah!");
        onZombieMatiVisual?.Invoke();
        OnZombieMati?.Invoke(this);
        Destroy(gameObject);
    }
}