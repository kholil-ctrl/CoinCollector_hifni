# Project Game - CoinCollector_Hifni

## Identitas Pembuat
* **Nama:Muhammad Hifni Bika Nashif
* **Kelas:[11 PPLG 2]
* **NIS:[06269]

## Fitur & Arsitektur Kode
1. **GameManager:** Mengatur alur permainan dengan 4 State (`MainMenu`, `Playing`, `Paused`, `GameOver`).
2. **PlayerMovement:** Mengontrol pergerakan karakter utama 2D.
3. **Penerapan OOP:**
   * **Abstraction:** Menggunakan interface `IDamageable`.
   * **Inheritance:** Class `FastZombie` mewarisi sifat dari `ZombieBase`.
   * **Polymorphism:** Method `Attack()` pada `FastZombie` menggunakan keyword `override` untuk mengubah perilaku serangan kelas induk (`virtual`).
4. **Delegate & Events:** 
   * **Pemancar Event:** Script `ZombieEvents` memicu event `OnZombieKilled` saat zombie mati.
   * **Penerima Event:** Script `GameManager` mendengarkan (subscribe) event untuk menambah skor.