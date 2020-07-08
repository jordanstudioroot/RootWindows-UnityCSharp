using NSubstitute;
using System;
using System.Collections.Generic;
using UnityEngine;
public static class ValueSourceCommon {
    private const int NUM_ATTRIB_TYPES = 10;

    public static string GetUniqueID() {
        return Guid.NewGuid().ToString();
    }

    public static IEnumerable<IViewData> AllDetailViewDataTypes() {
        IViewData[] result = new IViewData[3];
        IAttributeData subAttribData = Substitute.For<IAttributeData>();
        subAttribData.AttributeDictionary.Returns(
            delegate {
                return GetStubAttributeDict();
        });

        result[0] = subAttribData;

        IPortraitData subPortraitData = Substitute.For<IPortraitData>();
        subPortraitData.Portrait.Returns(
            delegate {
                return GetStubPortraitData();
            }
        );

        result[1] = subPortraitData;

        IDescriptionData subDescriptionData = Substitute.For<IDescriptionData>();
        subDescriptionData.Description.Returns(
            delegate {
                return StringPlaceholders.GetLoremIpsumAsParagraphs(1);
            }
        );

        result[2] = subDescriptionData;

        return result;
    }

    public static Dictionary<string, float[]> GetStubAttributeDict() {
        return new Dictionary<string, float[]>() {
            {"Attrib1", new float[] {0, 0, 0}},
            {"Attrib2", new float[] {0, 0, 0}},
            {"Attrib3", new float[] {0, 0, 0}},
            {"Attrib4", new float[] {0, 0, 0}},
            {"Attrib5", new float[] {0, 0, 0}},
            {"Attrib6", new float[] {0, 0, 0}},
            {"Attrib7", new float[] {0, 0, 0}},
            {"Attrib8", new float[] {0, 0, 0}},
            {"Attrib9", new float[] {0, 0, 0}},
            {"Attrib10", new float[] {0, 0, 0}}
        };
    }

    public static string GetStubDescriptionData() {
        return StringPlaceholders.GetLoremIpsumAsParagraphs(3);
    }

    public static Sprite GetStubPortraitData() {
        return Resources.Load<Sprite>("guyface");
    }

    public static IEnumerable<CardinalDirections> AllViewLocations() {
        return (IEnumerable<CardinalDirections>)Enum.GetValues(typeof(CardinalDirections));
    }

    public static IEnumerable<ViewSizes> AllViewSizes() {
        return (IEnumerable<ViewSizes>)Enum.GetValues(typeof(ViewSizes));
    }

    public static IAttributeData GetSubAttributeData() {
        IAttributeData result = Substitute.For<IAttributeData>();
        result.AttributeDictionary.Returns(GetStubAttributeDict());
        return result;
    }

    public static IPortraitData GetSubPortraitData() {
        IPortraitData result = Substitute.For<IPortraitData>();
        result.Portrait.Returns(Resources.Load<Sprite>("guyface"));
        return result;
    }

    public static IDescriptionData GetSubDescriptionData() {
        IDescriptionData result = Substitute.For<IDescriptionData>();
        result.Description.Returns(GetStubDescriptionData());
        return result;
    }

    public static List<Action> StubNoArgActionList(int actions) {
        List<Action> result = new List<Action>();
        for (int i = 0; i < actions; i++)
            result.Add(GetStubNoArgAction());
        return result;
    }

    public static List<Action<Vector3>> StubV3ArgActionList(int actions) {
        List<Action<Vector3>> result = new List<Action<Vector3>>();
        for (int i = 0; i < actions; i++)
            result.Add(GetStubV3ArgAction());
        return result;
    }

    public static Dictionary<Action, Action<Vector3>> StubV3ArgActionDict(int actions) {
        Dictionary<Action, Action<Vector3>> result = 
            new Dictionary<Action, Action<Vector3>>();
        for (int i = 0; i < actions; i++)
            result.Add(GetStubNoArgAction(), GetStubV3ArgAction());
        return result;
    }

    public static List<Action<GameObject[]>> StubGameObjectArgActionList(int actions) {
        List<Action<GameObject[]>> result = new List<Action<GameObject[]>>();
        for (int i = 0; i < actions; i++)
            result.Add(GetStubGameObjectArrAction());
        return result;
    }

    public static Dictionary<Action, Action<GameObject[]>> StubGameObjectArgActionDict(int actions) {
        Dictionary<Action, Action<GameObject[]>> result = 
            new Dictionary<Action, Action<GameObject[]>>();
        for (int i = 0; i < actions; i++)
            result.Add(GetStubNoArgAction(), GetStubGameObjectArrAction());
        return result;
    }

    public static Action GetStubNoArgAction() {
        Action result = Substitute.For<Action>();
        return result;
    }

    public static Action<Vector3> GetStubV3ArgAction() {
        Action<Vector3> result = Substitute.For<Action<Vector3>>();
        return result;
    }

    public static Action<GameObject[]> GetStubGameObjectArrAction() {
        Action<GameObject[]> result = Substitute.For<Action<GameObject[]>>();
        return result;
    }
}