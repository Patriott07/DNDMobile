using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using DG.Tweening;
using TMPro;

// Script ini digunakan di scene HomeScreen_UI,
public class MenuManager : MonoBehaviour
{
    [Space(10)]
    [ProgressBar("MENU GAME", 1, EColor.Red)] public int heading1 = 1; // gaperlu di rubah apapun, karena untuk bikin Penghalang dan header
    [Space(10)]
    [SerializeField] CanvasGroup menuHomeCanvasGroup;
    [SerializeField] CanvasGroup menuCreditCanvasGroup;

    // ---

    [Space(10)]
    [ProgressBar("CREDIT MENU ", 1, EColor.Blue)] public int heading2 = 1; // gaperlu di rubah apapun, karena untuk bikin Penghalang dan header
    [Space(10)]
    [SerializeField] CanvasGroup contentCreditCanvasGroup;
    [SerializeField] RectTransform contentCreditRectTransform;

    // ---

    [Space(10)]
    [ProgressBar("CREDIT MENU ", 1, EColor.Blue)] public int heading3 = 1; // gaperlu di rubah apapun, karena untuk bikin Penghalang dan header
    [Space(10)]
    [SerializeField] CanvasGroup contentHomeCanvasGroup;
    [SerializeField] RectTransform contentHomeRectTransform;

    // ---

    [Space(10)]
    [ProgressBar("Information User", 1, EColor.Blue)] public int heading4 = 1; // gaperlu di rubah apapun, karena untuk bikin Penghalang dan header
    [Space(10)]
    [SerializeField] TMP_Text textUsername;


    /// <summary>
    /// Fungsi yang akan dijalankan pertama kali saat game dimulai.
    /// </summary>
    void Start()
    {
        openMenuHome();
        if (textUsername != null)
        {
            // jika terdapat referensi textmeshpro untuk menampilkan nama
            textUsername.text = PlayerPrefs.GetString("username");
        }
    }

    /// <summary>
    /// Berfungsi untuk membuka home screen dan menutup semua menu/scene selain home
    /// </summary>
    public void openMenuHome()
    {
        HideMenuCredit();

        menuHomeCanvasGroup.interactable = true;
        menuHomeCanvasGroup.blocksRaycasts = true;

        menuHomeCanvasGroup.DOFade(1, 0.8f).OnComplete(() =>
        {
            // Berikan Animasi untuk content dari kiri ke tengah
            contentHomeCanvasGroup.DOFade(1, 0.4f);
            contentHomeRectTransform.DOLocalMoveX(-6, 0.4f);
        });

    }

    /// <summary>
    /// Berfungsi untuk membuka menu credit screen dan menutup semua menu/scene selain di credit
    /// </summary>
    public void openMenuCredit()
    {

        HideMenuHome();

        menuCreditCanvasGroup.interactable = true;
        menuCreditCanvasGroup.blocksRaycasts = true;

        menuCreditCanvasGroup.DOFade(1, 0.8f).OnComplete(() =>
        {
            // Berikan Animasi untuk content dari kiri ke tengah
            contentCreditCanvasGroup.DOFade(1, 0.4f);
            contentCreditRectTransform.DOLocalMoveX(-6, 0.4f);

        });
    }


    /// <summary>
    /// Berfungsi untuk memberikan efek animasi pada content menu credit (fade out left)
    /// Lalu Ia akan menutup tab menu credit  dan memngatur menu untuk tidak bisa di interaksi kembali
    /// </summary>
    void HideMenuCredit()
    {
        // Berikan Animasi untuk content dari tengah ke kiri
        contentCreditCanvasGroup.DOFade(0, 0.4f);
        contentCreditRectTransform.DOLocalMoveX(-200, 0.4f).OnComplete(() =>
        {
            menuCreditCanvasGroup.interactable = false;
            menuCreditCanvasGroup.blocksRaycasts = false;
            menuCreditCanvasGroup.DOFade(0, 0.4f);
        });
    }

    /// <summary>
    /// Berfungsi untuk memberikan efek animasi pada content menu home (fade out left)
    /// Lalu Ia akan menutup tab menu home dan memngatur menu untuk tidak bisa di interaksi
    /// </summary>
    void HideMenuHome()
    {
        // Berikan Animasi untuk content dari tengah ke kiri
        contentCreditCanvasGroup.DOFade(0, 0.4f);
        contentCreditRectTransform.DOLocalMoveX(-200, 0.4f).OnComplete(() =>
        {
            menuHomeCanvasGroup.alpha = 0;
            menuHomeCanvasGroup.interactable = false;
            menuHomeCanvasGroup.blocksRaycasts = false;
        });

    }

    /// <summary>
    /// Fungsi yang akan berjalan ketika tombol start game ditekan
    /// </summary>
    public void HandleStartGameButton()
    {
        CancelInvoke();
        StopAllCoroutines();
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Fungsi yang akan berjalan ketika button Quit game di tekan.
    /// Akan menghentikan semua Invoke, Coroutine
    /// Dan Akan Mengeluarkan user dari aplikasi
    /// </summary>
    public void HandleQuitGame()
    {
        CancelInvoke();
        StopAllCoroutines();
        Application.Quit();
    }
}
