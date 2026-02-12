using System.Collections;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private string prefix = "$ ";
    [SerializeField] private float countDuration = 0.25f;

    private Coroutine anim;
    private int shownValue;

    private void Reset()
    {
        label = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        Debug.Log("[MoneyUI] OnEnable on: " + gameObject.name);
        StartCoroutine(BindWhenReady());
    }

    private IEnumerator BindWhenReady()
    {
        while (Wallet.Instance == null)
            yield return null;

        Debug.Log("[MoneyUI] Bound to Wallet. Current = " + Wallet.Instance.Money);

        Wallet.Instance.OnMoneyChanged += HandleMoneyChanged;

        shownValue = Wallet.Instance.Money;
        Render(shownValue);
    }

    private void OnDisable()
    {
        if (Wallet.Instance != null)
            Wallet.Instance.OnMoneyChanged -= HandleMoneyChanged;
    }

    private void HandleMoneyChanged(int newValue)
    {
        Debug.Log("[MoneyUI] Money changed event received: " + newValue);
        if (anim != null) StopCoroutine(anim);
        anim = StartCoroutine(AnimateTo(newValue));
    }


    private IEnumerator AnimateTo(int target)
    {
        int start = shownValue;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.unscaledDeltaTime / Mathf.Max(0.01f, countDuration);
            float eased = 1f - Mathf.Pow(1f - t, 3f); // easeOutCubic
            shownValue = Mathf.RoundToInt(Mathf.Lerp(start, target, eased));
            Render(shownValue);
            yield return null;
        }

        shownValue = target;
        Render(shownValue);
        anim = null;
    }

    private void Render(int value)
    {
        // N0 adds thousand separators: 12,345
        label.text = prefix + value.ToString("N0");
    }
}
