using UnityEngine;

// [Langkah 5] Membuat aset config di Unity
[CreateAssetMenu(fileName = "ZombieConfig", menuName = "PvZ/Zombie Config")]
public class ZombieConfig : ScriptableObject
{
    public int hp = 100;
    public float kecepatan = 2f;
    public float jarakDeteksi = 6f;
    public float jarakSerang = 1.2f;
    public float jedaSerang = 1f; // Menambahkan jeda serang menyesuaikan script lamamu
}