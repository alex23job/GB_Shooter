using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private UI_Control ui_Control;

    private bool isKey = false;
    public bool IsKey { get => isKey; }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Hint", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Hint()
    {
        ViewHintPanel("Чтобы пройти уровень найдите ключ, соберите все бонусы, уничтожте танк, подожгите бочки. Вообщем развлекайтесь !");
    }

    public void ViewHintPanel(string hint)
    {
        ui_Control.ViewHint(hint);
    }

    public void ViewEndPanel()
    {
        ui_Control.ViewEndPanel();
    }

    public void TakeKey()
    {
        isKey = true;
    }
}
