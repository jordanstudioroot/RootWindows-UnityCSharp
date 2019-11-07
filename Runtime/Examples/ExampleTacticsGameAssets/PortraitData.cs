using UnityEngine;

public class PortraitData : IPortraitData
{
    private Sprite _portrait;
    public Sprite Portrait { 
        get { 
            return _portrait; 
        } 
        set { 
            _portrait = value;
            OnDataChanged(this); 
        }
    }

    public PortraitData(Sprite portrait) {
        _portrait = portrait;
    }

    public event DataChangedDelegate OnDataChanged;
}