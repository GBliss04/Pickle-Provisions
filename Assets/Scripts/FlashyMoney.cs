using System.Collections;
using UnityEngine;
using TMPro;

public class FlashyMoney : MonoBehaviour, IObserver
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private Color addColor = Color.green;
    [SerializeField] private Color subtractColor = Color.yellow;
    [SerializeField] private Color insufficientColor = Color.red;
    [SerializeField] private float flashDuration = 0.3f;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip insufficientFundsClip;
    [SerializeField] private AudioClip spendMoneyClip;
    [SerializeField] private AudioClip gainMoneyClip;
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
            case WalletActions.AddMoney:
                StartCoroutine(FlashColor(addColor));
                PlayGainMoneySound();
                break;

            case WalletActions.SubtractMoney:
                StartCoroutine(FlashColor(subtractColor));
                PlaySpendMoneySound();
                break;

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

    private void PlaySpendMoneySound()
    {
        if (audioSource != null && spendMoneyClip != null)
        {
            audioSource.PlayOneShot(spendMoneyClip);
        }
    }

    private void PlayGainMoneySound()
    {
        if (audioSource != null && gainMoneyClip != null)
        {
            audioSource.PlayOneShot(gainMoneyClip);
        }
    }
}
