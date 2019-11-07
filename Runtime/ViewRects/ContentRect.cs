using UnityEngine;

public class ContentRect : ViewRect
{
    protected override void HandleViewDataChanged(ViewData viewData) {
        RectTransform.anchorMin = new Vector2(0.5f, viewData.PercentContentCenterY);
        RectTransform.anchorMax = RectTransform.anchorMin;

        RectTransform.sizeDelta = new Vector2(
            viewData.InnerWidth, 
            viewData.InnerHeight - viewData.MoveHandleHeight
        );

        BGColor = viewData.ContentBGColor;
    }

    public static ContentRect GetRect(ViewData viewData) {
        GameObject resultObj = new GameObject("Content");
        ContentRect resultMono = resultObj.AddComponent<ContentRect>();
        resultMono.ViewData = viewData;
        return resultMono;
    }

    public void Clear() {
        Transform[] children = this.transform.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < children.Length; i++) {
            if (children[i].gameObject != this.gameObject) {
                Destroy(children[i].gameObject);
            }
        }
    }
}
