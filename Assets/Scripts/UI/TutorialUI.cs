using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText; 
    [SerializeField] private TextMeshProUGUI keyMoveDownText; 
    [SerializeField] private TextMeshProUGUI keyMoveLeftText; 
    [SerializeField] private TextMeshProUGUI keyMoveRightText; 
    [SerializeField] private TextMeshProUGUI keyInteractText; 
    [SerializeField] private TextMeshProUGUI keyInteractAlternateText; 
    [SerializeField] private TextMeshProUGUI keyPauseText;
    /*[SerializeField] private TextMeshProUGUI keyMoveGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyMoveGamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyMoveGamepadPauseText;*/

    private void Start()
    {
        GameInput.Instance.OnBinderRebind += GameInput_OnBinderRebind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        UpdateVisual();
        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountdownTpStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBinderRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = GameInput.Instance.GetBundingText(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBundingText(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = GameInput.Instance.GetBundingText(GameInput.Binding.Move_Left);
        keyMoveRightText.text = GameInput.Instance.GetBundingText(GameInput.Binding.Move_Right);
        keyInteractText.text = GameInput.Instance.GetBundingText(GameInput.Binding.Interact);
        keyInteractAlternateText.text = GameInput.Instance.GetBundingText(GameInput.Binding.InteractAlternate);
        keyPauseText.text = GameInput.Instance.GetBundingText(GameInput.Binding.Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
