using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueControllerUI : MonoBehaviour
{
    private List<DialogueLine> dialogues;
    private int currentIndex = 0;

    [Header("Speaker Positions")]
    public Transform playerPoint;
    public Transform shadowPoint;

    [Header("UI References")]
    public TextMeshProUGUI dialogueText;
    public Vector3 offset = new Vector3(0, 2f, 0);

    private Transform currentTarget;

    // 自动打字机
    public float typeSpeed = 0.04f;
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    // 两个角色的 PlayerController（放 Player 和 ShadowPlayer）
    [Header("Players Movement Scripts")]
    public PlayerController[] players;


    // ===========================
    // 开始对话
    // ===========================
    public void StartDialogue(List<DialogueLine> lines)
    {
        if (lines == null || lines.Count == 0) return;

        dialogues = lines;
        currentIndex = 0;

        FreezeMovement();   // 停止两个角色

        ShowDialogue();
    }


    private void Update()
    {
        if (dialogues == null || dialogues.Count == 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                // 跳过剩余打字
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogues[currentIndex].text;
                isTyping = false;
            }
            else
            {
                NextDialogue();
            }
        }

        // 让文字跟随头顶
        if (dialogueText != null && currentTarget != null)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(currentTarget.position + offset);
            dialogueText.transform.position = pos;
        }
    }


    // ===========================
    // 下一句
    // ===========================
    private void NextDialogue()
    {
        currentIndex++;

        if (currentIndex < dialogues.Count)
        {
            ShowDialogue();
        }
        else
        {
            EndDialogue();
        }
    }


    // ===========================
    // 显示一句话
    // ===========================
    private void ShowDialogue()
    {
        DialogueLine line = dialogues[currentIndex];

        currentTarget = (line.speaker == Speaker.Player) ? playerPoint : shadowPoint;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(line.text));
    }


    // ===========================
    // 自动打字机协程
    // ===========================
    IEnumerator TypeText(string fullText)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in fullText)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        isTyping = false;
    }


    // ===========================
    // 结束对话
    // ===========================
    private void EndDialogue()
    {
        dialogueText.text = "";
        dialogues = null;
        currentIndex = 0;
        currentTarget = null;

        UnfreezeMovement();  // 恢复两个角色
    }


    // ===========================
    // 冻结移动（适配你的 PlayerController）
    // ===========================
    private void FreezeMovement()
    {
        foreach (var pc in players)
        {
            if (pc == null) continue;

            pc.SetCanMove(false); // 禁止移动

            // 停止滑动
            if (pc.TryGetComponent<Rigidbody2D>(out var rb))
                rb.linearVelocity = Vector2.zero;
        }
    }

    // ===========================
    // 恢复移动
    // ===========================
    private void UnfreezeMovement()
    {
        foreach (var pc in players)
        {
            if (pc == null) continue;

            pc.SetCanMove(true); // 恢复移动
        }
    }
}
