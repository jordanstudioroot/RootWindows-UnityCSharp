using UnityEngine;

public interface ISubject {
    void ShowDetail(
        bool sizeLocked = true,
        bool positionLocked = true
    );
    
    void ShowDetail(
        CardinalDirections location,
        ViewSizes size,
        bool sizeLocked = true, 
        bool positionLocked = true
    );

    void ShowDetail(
        Vector2 position,
        ViewSizes size = ViewSizes.Medium,
        bool sizeLocked = true, 
        bool positionLocked = true
    );

    void ShowTooltip(
        ViewSizes size = ViewSizes.Medium
    );

    void ShowActionBar(
        bool sizeLocked = true,
        bool positionLocked = true
    );

    void ShowActionBar(
        CardinalDirections location,
        ViewSizes size,
        bool sizeLocked = true, 
        bool positionLocked = true
    );

    void HideActionBar();
    
    void HideTooltip();

    void HideDetail();   
}