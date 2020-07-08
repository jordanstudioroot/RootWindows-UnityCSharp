using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubjectDetailView : View {
// FIELDS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
    ColumnGridFlexibleRect _rootFlexRect;

// CONSTRUCTORS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// DESTRUCTORS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// DELEGATES ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// EVENTS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// ENUMS

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// INTERFACES ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// PROPERTIES ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// INDEXERS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// METHODS ~~~~~~~~~

// ~ Static

// ~~ public
    public static SubjectDetailView GetView(
        Canvas canvas,
        ViewSizes size = ViewSizes.Medium, 
        CardinalDirections location = CardinalDirections.West
    ) {
        GameObject result = new GameObject("Detail View");
        SubjectDetailView resultMono = result.AddComponent<SubjectDetailView>();
        resultMono.Initialize(canvas);
        resultMono.SetSize(size);
        resultMono.SetLocation(location);
        return resultMono;
    }
// ~~ private

// ~ Non-Static

// ~~ public
    public void Refresh(
        IAttributeData aData = null,
        IPortraitData pData = null,
        IDescriptionData dData = null
    ) {
        Clear();

        _rootFlexRect = ColumnGridFlexibleRect.GetRect(ViewData, 2);
        _rootFlexRect.transform.SetParent(ContentRect.transform, false);

        bool showPortrait = pData == null ? false : true;
        bool showAttributes = aData == null ? false : true;
        bool showDescription = dData == null ? false : true;

        if (showPortrait) {
            RefreshPortrait(pData, _rootFlexRect);
        }

        if (showAttributes) {
            RefreshAttributes(aData, _rootFlexRect);
        }

        if (showDescription) {
            RefreshDescription(dData, _rootFlexRect);
        }

        _rootFlexRect.Refresh();
    }

    public override void SetSize(ViewSizes size) {
        switch (size) {
            case ViewSizes.Small:
                ViewData.InnerSize = AppWindowMetrics.EighthAppWindowSquare;
                break;
            case ViewSizes.Medium:
                ViewData.InnerSize = AppWindowMetrics.FourthAppWindowSquare;
                break;
            case ViewSizes.Large:
                ViewData.InnerSize = AppWindowMetrics.HalfAppWindowSquare;
                break;
        }

        Snap();
    }

// ~~ private
    private void RefreshAttributes(IAttributeData data, ColumnGridFlexibleRect root) {
        VerticalFlexibleRect child = VerticalFlexibleRect.GetRect(ViewData);
        child.transform.SetParent(root.transform, false);

        foreach (KeyValuePair<string, float[]> pair in data.AttributeDictionary) {

            HorizontalFlexibleRect grandchild = HorizontalFlexibleRect.GetRect(ViewData);
            grandchild.transform.SetParent(child.transform, false);

            GameObject keyLeafObj = new GameObject(pair.Key.ToString());
            TextMeshProUGUI keyTextMesh = keyLeafObj.AddComponent<TextMeshProUGUI>();
            keyTextMesh.text = pair.Key;
            keyTextMesh.color = Color.black;
            keyTextMesh.enableAutoSizing = true;
            keyTextMesh.fontSizeMin = TextConstants.BODY_TEXT_SIZE;
            keyTextMesh.fontSizeMax = TextConstants.BODY_TEXT_SIZE_LARGE;
            keyTextMesh.ForceMeshUpdate();

            keyLeafObj.transform.SetParent(grandchild.transform, false);

            GameObject valueLeafObj = new GameObject(pair.Value.ToString());
            TextMeshProUGUI valueTextMesh = valueLeafObj.AddComponent<TextMeshProUGUI>();
            valueTextMesh.text = pair.Value[0].ToString();
            valueTextMesh.color = Color.black;
            valueTextMesh.enableAutoSizing = true;
            valueTextMesh.fontSizeMin = TextConstants.BODY_TEXT_SIZE;
            valueTextMesh.fontSizeMax = TextConstants.BODY_TEXT_SIZE_LARGE;
            valueTextMesh.ForceMeshUpdate();
            
            valueLeafObj.transform.SetParent(grandchild.transform, false);              
        }
    }

    private void RefreshPortrait(IPortraitData data, ColumnGridFlexibleRect root) {
        GameObject leafObj = new GameObject("Portrait");
        Image portrait = leafObj.AddComponent<Image>();
        portrait.sprite = data.Portrait;
        leafObj.transform.SetParent(root.transform, false);
    }

    private void RefreshDescription(IDescriptionData data, ColumnGridFlexibleRect root) {
        GameObject leafObj = new GameObject("Description");
        Text descriptionText = leafObj.AddComponent<Text>();
        descriptionText.text = data.Description;
        descriptionText.color = Color.black;
        descriptionText.font = UnityBuiltin.Font("Arial");
        leafObj.transform.SetParent(root.transform, false);
    }

    protected override void HandleViewDataChanged(ViewData viewData) {
        base.HandleViewDataChanged(viewData);
        if (_rootFlexRect) {
            _rootFlexRect.Refresh();
        }
    }

// STRUCTS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private

// CLASSES ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private

// ~ Non-Static

// ~~ public

// ~~ private
}