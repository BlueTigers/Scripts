using UnityEngine;
using System.Collections;

public class DropZone : MonoBehaviour {

    public GameObject droppedItemPrefab;

    public UISprite eatricebtn;

    public int foodNum;

    void Start ()
    {
        foodNum = PlayerPrefs.GetInt("FOODSCENEMANAGER");
    }

    public void OnDrop(GameObject dropped)
    {
        // 드롭된 게임오브젝트에 Z_Item 컴포넌트가 있는지 확인하다.
        MouseEvent droppedItem = dropped.GetComponent<MouseEvent>();
        // 컴포넌트가 없다면, 즉 아이템이 아니라면 더 이상 진행할 필요가 없다.
        if (droppedItem == null) return;

        droppedItemPrefab.transform.parent = eatricebtn.transform;
        droppedItemPrefab.transform.localPosition = new Vector3(0, 0, 0);
        foodNum--;
        PlayerPrefs.SetInt("FOODSCENEMANAGER", foodNum);
        
        // 드롭된 아이템 프리팹의 인스턴스를 생성한다.
        /*GameObject newPower = NGUITools.AddChild(this.gameObject,
                                                 droppedItemPrefab);*/
        // 드롭된 게임오브젝트는 삭제한다.
        //Destroy(dropped);
    }
}
