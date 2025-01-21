using UnityEngine;


public class UI : MonoBehaviour
{
    [SerializeField] private GameObject characterUI;
    [SerializeField] private GameObject craftUI;
    [SerializeField] private GameObject skillsUI;
    [SerializeField] private GameObject optionsUI;
    
    
    public UI_ItemInfoTip itemInfoTip;
    public UI_StatInfoTip statInfoTip;
    public UI_CraftWindow craftWindow;
    public UI_SkillInfoTip skillInfoTip;

    public void Start()
    {
        SwitchTo(null);
        
        itemInfoTip.gameObject.SetActive(false);
        //statInfoTip.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SwitchWithKeyTo(optionsUI);
        
        if (Input.GetKeyDown(KeyCode.C))
            SwitchWithKeyTo(characterUI);
        
        if (Input.GetKeyDown(KeyCode.K))
            SwitchWithKeyTo(skillsUI);
        
        if (Input.GetKeyDown(KeyCode.B))
            SwitchWithKeyTo(craftUI);
    }

    public void SwitchTo(GameObject _menu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        
        if(_menu != null)
            _menu.SetActive(true);
    }

    public void SwitchWithKeyTo(GameObject menu)
    {
        if (menu != null && menu.activeSelf)
        {
            menu.SetActive(false);
            return;
        }
        
        SwitchTo(menu);
    }
}
