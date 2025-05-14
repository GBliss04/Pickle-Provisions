using System.Collections;
using UnityEngine;
using TMPro;

public class Spender : MonoBehaviour, IObserver
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private Color subtractColor = Color.yellow;
    [SerializeField] private float flashDuration = 0.3f;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip spendMoneyClip;
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
            case WalletActions.SubtractMoney:
                StartCoroutine(FlashColor(subtractColor));
                PlaySpendMoneySound();
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
    private void PlaySpendMoneySound()
    {
        if (audioSource != null && spendMoneyClip != null)
        {
            audioSource.PlayOneShot(spendMoneyClip);
        }
    }
}
