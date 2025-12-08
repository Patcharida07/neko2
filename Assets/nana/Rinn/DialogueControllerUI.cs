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

    [Header("Word Position Offset")]
    public Vector3 offset = new Vector3(0, 0.1f, 0);

    private Transform currentTarget;

    public float typeSpeed = 0.04f;
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    [Header("Players Movement Scripts")]
    public PlayerController[] players;

    public void StartDialogue(List<DialogueLine> lines)
    {
        if (lines == null || lines.Count == 0) return;

        dialogues = lines;
        currentIndex = 0;

        FreezeMovement();

        ShowDialogue();
    }


    private void Update()
    {
        if (dialogues == null || dialogues.Count == 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogues[currentIndex].text;
                isTyping = false;
            }
            else
            {
                NextDialogue();
            }
        }

        if (dialogueText != null && currentTarget != null)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(currentTarget.position + offset);
            dialogueText.transform.position = pos;
        }
    }


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

    private void ShowDialogue()
    {
        DialogueLine line = dialogues[currentIndex];

        currentTarget = (line.speaker == Speaker.Player) ? playerPoint : shadowPoint;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(line.text));
    }

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

    private void EndDialogue()
    {
        dialogueText.text = "";
        dialogues = null;
        currentIndex = 0;
        currentTarget = null;

        UnfreezeMovement();
    }

    // ============================================================
    // TRUE FREEZE MOVEMENT
    // ============================================================
    private void FreezeMovement()
    {
        foreach (var pc in players)
        {
            if (pc == null) continue;

            pc.SetCanMove(false);

            if (pc.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.linearVelocity = Vector2.zero;      // ← 正确字段 !!!
                rb.angularVelocity = 0f;

                rb.constraints = RigidbodyConstraints2D.FreezeAll; // ★★★ 完全冻结
            }
        }
    }

    private void UnfreezeMovement()
    {
        foreach (var pc in players)
        {
            if (pc == null) continue;

            pc.SetCanMove(true);

            if (pc.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
