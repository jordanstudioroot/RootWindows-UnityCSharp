using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using RootExtensions;
using RootUtils.ScreenSpace;

public class ActionBarView : View
{
// FIELDS ~~~~~~~~~~

// ~ Static

// ~~ public

// ~~ private
    HorizontalFlexibleRect _rootFlexRectMono;

// ~ Non-Static

// ~~ public

// ~~ private

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
    public static ActionBarView GetView(
        Canvas canvas,
        ViewSizes size = ViewSizes.Medium,
        CardinalDirections location = CardinalDirections.South
    ) {
        GameObject result = new GameObject("Action Bar View");
        
        ActionBarView resultMono = result.AddComponent<ActionBarView>();
        resultMono.Initialize(canvas);

        resultMono.ViewData.MinTotalWidth = AppWindowMetrics.BarSmall.x;
        resultMono.ViewData.MinTotalHeight = AppWindowMetrics.BarSmall.y;
        
        resultMono.SetSize(size);
        resultMono.SetLocation(location);

        return resultMono;
    }

// ~~ private

// ~ Non-Static

// ~~ public
    public override void SetSize(ViewSizes size)
    {
        switch (size) {
            case ViewSizes.Small:
                ViewData.InnerSize = AppWindowMetrics.BarSmall;
                break;
            case ViewSizes.Medium:
                ViewData.InnerSize = AppWindowMetrics.BarMedium;
                break;
            case ViewSizes.Large:
                ViewData.InnerSize = AppWindowMetrics.BarLarge;
                break;
            case ViewSizes.Maximum:
                ViewData.InnerSize = AppWindowMetrics.BarMax;
                break;
            default:
                ViewData.InnerSize = AppWindowMetrics.BarSmall;
                break;
       } 
    }
    
    public void Refresh(
        List<Action> selfAbilities = null, 
        Dictionary<Action, Action<Vector3>> locationAbilities = null, 
        Dictionary<Action, Action<GameObject[]>> objectAbilities = null
    )
    {
        Clear();

        _rootFlexRectMono = 
            HorizontalFlexibleRect.GetRect(ViewData);
        
        _rootFlexRectMono.transform.SetParent(ContentRect.transform, false);

        _rootFlexRectMono.SizeDelta = new Vector2(ContentRect.SizeDelta.x, ContentRect.SizeDelta.y);

        if (selfAbilities != null && selfAbilities.Count > 0) {
            CreateSelfAbilityBar(
                selfAbilities, 
                ViewData.SelfActionBGColor
            ).transform.SetParent(_rootFlexRectMono.transform, false);
        }

        if (locationAbilities != null && locationAbilities.Count > 0) {
            CreateLocationAbilityBar(
                locationAbilities, 
                ViewData.LocationActionBGColor
            ).transform.SetParent(_rootFlexRectMono.transform, false);
        }

        if (objectAbilities != null && objectAbilities.Count > 0) {
            CreateObjectAbilityBar(
                objectAbilities, 
                ViewData.ObjectActionBGColor
            ).transform.SetParent(_rootFlexRectMono.transform, false);
        }

        _rootFlexRectMono.Refresh();
    }

// ~~ private
    private HorizontalFlexibleRect CreateSelfAbilityBar(
        List<Action> selfAbilities, 
        Color buttonColor
    )
    {
        HorizontalFlexibleRect child = HorizontalFlexibleRect.GetRect(ViewData);

        foreach (Action ability in selfAbilities) {
            GameObject leafObj = new GameObject(ability.Method.Name + " Button");

            leafObj.SetActive(false);
            Image image = leafObj.AddComponent<Image>();
            Button button = leafObj.AddComponent<Button>();
            button.onClick.AddListener(() => button.Deselect());
            AddSelfInstantButtonListener(button, ability);
            ColorBlock cBlock = button.colors;
            cBlock.normalColor = buttonColor;
            cBlock.pressedColor = buttonColor;
            cBlock.selectedColor = buttonColor;
            cBlock.highlightedColor = cBlock.normalColor.GetHighlightedColor(.75f);
            button.colors = cBlock;
            leafObj.SetActive(true);
            
            GameObject textObj = new GameObject(ability.Method.Name + " Text");
            textObj.transform.SetParent(leafObj.transform, false);
            TextMeshProUGUI buttonText = textObj.AddComponent<TextMeshProUGUI>();
            buttonText.enableAutoSizing = true;
            buttonText.margin = new Vector4(10f, 10f, 10f, 10f);
            buttonText.text = ability.Method.Name;
            buttonText.alignment = TextAlignmentOptions.Center;
            buttonText.color = buttonColor.GetInvertedColor();

            leafObj.transform.SetParent(child.transform, false);
        }

        return child;
    }

    private HorizontalFlexibleRect CreateLocationAbilityBar(
        Dictionary<Action, Action<Vector3>> abilities, 
        Color buttonColor
    )
    {
        HorizontalFlexibleRect child = HorizontalFlexibleRect.GetRect(ViewData);

        foreach (KeyValuePair<Action, Action<Vector3>> pair in abilities) {
            GameObject leafObj = new GameObject(pair.Value.Method.Name + " Button");

            leafObj.SetActive(false);
            Image image = leafObj.AddComponent<Image>();
            Button button = leafObj.AddComponent<Button>();
            button.onClick.AddListener(() => button.Deselect());
            AddWaitClickLocationButtonListener(button, pair.Key, pair.Value);
            ColorBlock cBlock = button.colors;
            cBlock.normalColor = buttonColor;
            cBlock.pressedColor = buttonColor;
            cBlock.selectedColor = buttonColor;
            cBlock.highlightedColor = cBlock.normalColor.GetHighlightedColor(.75f);
            button.colors = cBlock;
            leafObj.SetActive(true);

            GameObject textObj = new GameObject(pair.Value.Method.Name + " Text");
            textObj.transform.SetParent(leafObj.transform, false);
            TextMeshProUGUI buttonText = textObj.AddComponent<TextMeshProUGUI>();
            buttonText.enableAutoSizing = true;
            buttonText.margin = new Vector4(10f, 10f, 10f, 10f);
            buttonText.text = pair.Value.Method.Name;
            buttonText.alignment = TextAlignmentOptions.Center;
            buttonText.color = buttonColor.GetInvertedColor();

            leafObj.transform.SetParent(child.transform, false);
        }

        return child;
    }

    private HorizontalFlexibleRect CreateObjectAbilityBar(
        Dictionary<Action, Action<GameObject[]>> abilities, 
        Color buttonColor
    )
    {
        HorizontalFlexibleRect child = HorizontalFlexibleRect.GetRect(ViewData);

        foreach (KeyValuePair<Action, Action<GameObject[]>> pair in abilities) {
            GameObject leafObj = new GameObject(pair.Value.Method.Name + " Button");

            leafObj.SetActive(false);
            Image image = leafObj.AddComponent<Image>();
            Button button = leafObj.AddComponent<Button>();
            button.onClick.AddListener(() => button.Deselect());
            AddWaitClickObjectButtonListener(button, pair.Key, pair.Value);
            ColorBlock cBlock = button.colors;
            cBlock.normalColor = buttonColor;
            cBlock.pressedColor = buttonColor;
            cBlock.selectedColor = buttonColor;
            cBlock.highlightedColor = cBlock.normalColor.GetHighlightedColor(.75f);
            button.colors = cBlock;
            leafObj.SetActive(true);

            GameObject textObj = new GameObject(pair.Value.Method.Name + " Text");
            textObj.transform.SetParent(leafObj.transform, false);
            TextMeshProUGUI buttonText = textObj.AddComponent<TextMeshProUGUI>();
            buttonText.enableAutoSizing = true;
            buttonText.margin = new Vector4(10f, 10f, 10f, 10f);
            buttonText.text = pair.Value.Method.Name;
            buttonText.alignment = TextAlignmentOptions.Center;
            buttonText.color = buttonColor.GetInvertedColor();

            leafObj.transform.SetParent(child.transform, false);
        }

        return child;
    }

    private void AddSelfInstantButtonListener(Button button, Action ability) {
        button.onClick.AddListener(() => { ability(); });
    }

    private void AddWaitClickLocationButtonListener(
        Button button,
        Action onClick,
        Action<Vector3> onConfirm
    ) {
        button.onClick.AddListener(
            delegate {
                onClick();
            }
        );

        button.onClick.AddListener(
            delegate { 
                StartCoroutine(
                    WaitForClickLocation(onConfirm)
                );
            }
        );
    }

    private void AddWaitClickObjectButtonListener(
        Button button,
        Action onClick,
        Action<GameObject[]> onConfirm
    ) {
        button.onClick.AddListener(
            delegate {
                onClick();
            }
        );

        button.onClick.AddListener(
            delegate { 
                StartCoroutine(
                    WaitForClickObject(onConfirm)
                );
            }
        );
    }

    private IEnumerator WaitForClickLocation(Action<Vector3> ability) {
        while (!Input.GetKeyDown(KeyCode.Mouse0)) {
            yield return null;
        }
        
        ability(ScreenPoint.GetWorldPosition(Camera.main, Input.mousePosition));
    }

    private IEnumerator WaitForClickObject(Action<GameObject[]> ability) {
        Debug.Log("waiting for obj click");
        while (!Input.GetKeyDown(KeyCode.Mouse0)) {
            yield return null;
        }
        
        ability(ScreenPoint.GetObjectsUnder(Camera.main, Input.mousePosition));
    }

    protected override void HandleViewDataChanged(ViewData viewData) {
        base.HandleViewDataChanged(viewData);
        if (_rootFlexRectMono) {
            _rootFlexRectMono.SizeDelta = new Vector2(
                viewData.ContentWidth,
                viewData.ContentHeight
            );
            _rootFlexRectMono.Refresh();
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