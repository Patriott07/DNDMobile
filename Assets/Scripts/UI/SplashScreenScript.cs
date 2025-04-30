using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

// Script ini digunakan di scene SplashScreen,
public class SplashScreenScript : MonoBehaviour
{
    [Space(10)]
    [ProgressBar("Base Logic", 1, EColor.Red)] public float heading1 = 1;
    [Space(10)]
    float LongTimeMultiple = 3f;
    [SerializeField] TMP_Text textPresent;
    [SerializeField] RectTransform rectTransformRedText;
    [SerializeField] RectTransform rectTransformRiftStudioText;
    [SerializeField] RectTransform rectTransformLogo;
    [SerializeField] CanvasGroup canvasGroupBarcode;
    [SerializeField] CanvasGroup canvasGroupLogo;
    [SerializeField] CanvasGroup canvasGroupTextRed;
    [SerializeField] CanvasGroup canvasGroupTextPleaseWait;
    [SerializeField] CanvasGroup canvasGroupBgBlack;

    const string PRESENT_WORD = "PRESENT.";

    void Start()
    {
        InitPositionUiSplashScreen();

    }

    void StartAnimatingUI()
    {
        // Sebelum pndah ke home screen kasi animasi dlu kepada pemain
        // Langkah
        // logo dari tengah (150) ke posisi x "-408" sambil fade masuk | 0.3f
        // Text Red dari fade masuk lalu Scale 3 ke 1 | 0.2f -
        // Text riftstudio dari x -680 ke -255 | 0.35f -
        // Show Please Wait | 0.4f --
        // fade out barcode | 0.2 --
        // Text Present Writing Effect | 0.6f 
        // wait 1f
        // fade bg ke hitam
        // Pindah Scene

        // -- logo
        rectTransformLogo.DOLocalMoveX(-408, 0.3f * LongTimeMultiple);
        canvasGroupLogo.DOFade(1, 0.3f).OnComplete(() =>
        {
            // -- Text Red
            canvasGroupTextRed.DOFade(1, 0.3f * LongTimeMultiple);
            rectTransformRedText.DOScale(1, 0.3f * LongTimeMultiple);

            // -- Text Rift Studio
            rectTransformRiftStudioText.DOLocalMoveX(-255f, 0.5f * LongTimeMultiple).OnComplete(() =>
            {

                // Text Please Wait & Barcode
                canvasGroupTextPleaseWait.DOFade(1, 0.4f * LongTimeMultiple);
                canvasGroupBarcode.DOFade(1, 0.5f * LongTimeMultiple).OnComplete(() =>
                {
                    // Text Present
                    StartCoroutine(TextWriting(0.6f * LongTimeMultiple));

                    Invoke("GoToSceneHome", 1.2f * LongTimeMultiple);
                });
            });
        });


    }

    IEnumerator TextWriting(float duration)
    {
        foreach (char letter in PRESENT_WORD)
        {
            textPresent.text += letter;  // Menambahkan satu karakter pada satu waktu
            yield return new WaitForSeconds(duration / 8);  // Tunggu sejenak sebelum menampilkan karakter berikutnya
        }
    }

    void GoToSceneHome()
    {
        canvasGroupBgBlack.DOFade(1, 0.6f * LongTimeMultiple).OnComplete(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
    void InitPositionUiSplashScreen()
    {
        // Ui Logo
        UiLogoInitVisualPositionUI();

        // Text Red
        TextRedInitVisualPositionUI();

        // Text Rift Studio
        TextRiftStudioInitVisualPositionUI();

        // Text Please Wait
        TextPleaseWaitInitVisualPositionUI();

        // Barcode
        BarcodeInitVisualPositionUI();

        // Text Present 
        TextPresentInitVisualPositionUI();

        // Bg black
        BackgroundBlackInitVisualPositionUI();

        // Start animating
        StartAnimatingUI();
    }

    void UiLogoInitVisualPositionUI()
    {
        canvasGroupLogo.alpha = 0;
        Vector3 vector3 = rectTransformLogo.transform.localPosition;
        vector3.x = 150;
        rectTransformLogo.localPosition = vector3;

    }
    void TextRedInitVisualPositionUI()
    {
        canvasGroupTextRed.alpha = 0;
        rectTransformRedText.localScale = new Vector3(3, 3, 3);

    }
    void TextRiftStudioInitVisualPositionUI()
    {

        Vector3 vector3 = rectTransformRiftStudioText.transform.localPosition;
        vector3.x = -680;
        rectTransformRiftStudioText.localPosition = vector3;

    }

    void TextPleaseWaitInitVisualPositionUI()
    {
        canvasGroupTextPleaseWait.alpha = 0;
    }
    void BarcodeInitVisualPositionUI()
    {
        canvasGroupBarcode.alpha = 0;
    }
    void TextPresentInitVisualPositionUI()
    {
        textPresent.text = "";
    }

    void BackgroundBlackInitVisualPositionUI()
    {
        canvasGroupBgBlack.alpha = 0;
    }
}
