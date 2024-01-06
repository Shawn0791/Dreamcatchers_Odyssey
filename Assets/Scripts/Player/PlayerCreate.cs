using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCreate : MonoBehaviour
{
    public GameObject inputField;
    public Transform faceObj;
    public GameObject[] itemPrefabs;
    private bool isShow;
    private InputField inputF;
    private PlayerMovement PM;
    private GameObject houseMonster;
    public GameObject mom;
    public GameObject dad;
    public GameObject snowMonster;
    public GameObject snowMonsterTrigger;
    void Start()
    {
        inputField.SetActive(isShow);
        inputF = inputField.GetComponent<InputField>();
        PM = GetComponent<PlayerMovement>();
        houseMonster = GameObject.FindGameObjectWithTag("HouseMonster");
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCreatBar();
    }

    private void SwitchCreatBar()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isShow = !isShow;
            inputField.SetActive(isShow);
        }

        PM.canMove = !inputF.isFocused;
    }

    public void ReceiveKey(string key)
    {
        switch (key)
        {
            case "Torch":
                CreateItem("Torch");
                inputF.text = null;
                break;
            case "Trap":
                CreateItem("Trap");
                inputF.text = null;
                break;
            case "Time":
                if (Vector3.Distance(transform.position, mom.transform.position) < 30)
                {
                    mom.SetActive(true);
                }
                break;
            case "Secretive":
                if (Vector3.Distance(transform.position, dad.transform.position) < 30)
                {
                    dad.SetActive(false);
                    snowMonster.SetActive(true);
                    snowMonsterTrigger.SetActive(true);
                }
                break;
            case "True":
                if (Vector3.Distance(transform.position,houseMonster.transform.position)<30)
                {
                    houseMonster.GetComponent<HouseMonster>().BackToNormal();
                }
                break;
            case "Door":
                CreateItem("Door");
                inputF.text = null;
                break;
            default:
                inputF.text = null;
                break;
        }

        PM.canMove = !inputF.isFocused;
    }

    private void CreateItem(string itemName)
    {
        if (itemName == "Door")
        {
            for (int i = 0; i < itemPrefabs.Length; i++)
            {
                if (itemPrefabs[i].name == itemName)
                {
                    Transform pos = transform.Find("HoldPos");
                    for (int j = 0; j < pos.childCount; j++)
                    {
                        Destroy(pos.GetChild(j));
                    }
                    GameObject item = Instantiate(itemPrefabs[i], transform.position + transform.right * 5, Quaternion.identity);
                    item.transform.parent = transform.parent;
                    //FacingCamera.instance.RefreshFacing();
                    GameManager.instance.RefreshObjFacing();
                    return;
                }
            }
        }

        for (int i = 0; i < itemPrefabs.Length; i++)
        {
            if (itemPrefabs[i].name == itemName)
            {
                Transform pos = transform.Find("HoldPos");
                for (int j = 0; j < pos.childCount; j++)
                {
                    Destroy(pos.GetChild(j));
                }
                GameObject item = Instantiate(itemPrefabs[i], pos.position-Camera.main.transform.forward*0.1f, Quaternion.identity);
                item.transform.parent = pos;
                //FacingCamera.instance.RefreshFacing();
                GameManager.instance.RefreshObjFacing();
                return;
            }
        }
    }
}
