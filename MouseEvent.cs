using UnityEngine;
using System.Collections;

public class MouseEvent : MonoBehaviour {

    void OnPress(bool pressed)
    {

        // 아이템을 누르고 있는 동안은 충돌체를 비활성화한다.
        GetComponent<Collider>().enabled = !pressed;
        if (!pressed)
        {

            // UICamera가 감지한 충돌체를 찾는다.
            Collider col = UICamera.lastHit.collider;
            // 감지한 충돌체가 없거나, 드롭 영역이 아니면
            if (col == null || col.GetComponent<DropZone>() == null)
            {
                // 부모인 Grid를 찾아서
                UISprite EatRiceBTN = NGUITools.FindInParents<UISprite>(gameObject);
                // 원래 위치로 돌아온다.
                if (EatRiceBTN != null) EatRiceBTN.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}
