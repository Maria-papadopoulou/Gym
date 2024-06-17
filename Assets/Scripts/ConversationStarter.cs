using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    public void Resume(NPCConversation myConversation)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        ConversationManager.Instance.StartConversation(myConversation);
    }
}
