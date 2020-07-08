using System.Collections.Generic;
public interface IAttributeData : IViewData {
    Dictionary<string, float[]> AttributeDictionary { get; }
}

