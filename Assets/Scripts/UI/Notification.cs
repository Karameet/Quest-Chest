using TMPro;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] TMP_Text MessageText;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            this.gameObject.SetActive(false);
    }

    public void SetMessage(string Message)
    {
        MessageText.text = Message;
        this.gameObject.SetActive(true);
    }
}
