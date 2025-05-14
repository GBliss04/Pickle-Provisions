using System.Collections;
using UnityEngine;
using TMPro;

public class Broke : MonoBehaviour, IObserver
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private Color insufficientColor = Color.red;
    [SerializeField] private float flashDuration = 0.3f;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip insufficientFundsClip;
    [SerializeField] private AudioSource audioSource;

    private Color originalColor;

    private void Start()
    {
        if (moneyText != null)
        {
            originalColor = moneyText.color;
        }

        if (WalletManager.Instance != null)
        {
            WalletManager.Instance.AddObserver(this);
        }
    }

    public void OnNotify(WalletActions action)
    {
        if (moneyText == null) return;

        switch (action)
        {
            case WalletActions.InsufficientFunds:
                StartCoroutine(FlashColor(insufficientColor));
                PlayInsufficientFundsSound();
                break;
        }
    }

    private IEnumerator FlashColor(Color flashColor)
    {
        Color colorWithAlpha = new Color(flashColor.r, flashColor.g, flashColor.b, originalColor.a);
        moneyText.color = colorWithAlpha;

        yield return new WaitForSeconds(flashDuration);

        moneyText.color = originalColor;
    }

    private void PlayInsufficientFundsSound()
    {
        if (audioSource != null && insufficientFundsClip != null)
        {
            audioSource.PlayOneShot(insufficientFundsClip);
        }
    }
}
