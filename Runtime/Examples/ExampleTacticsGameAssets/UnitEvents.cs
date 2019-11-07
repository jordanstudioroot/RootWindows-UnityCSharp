public enum Types {
    OnUnitSelected,
    OnUnitDeselected,
    OnUnitStartAbility,
    OnUnitEndAbility
}

public static class UnitEvents {
    public static Event<Unit> OnUnitSelected = new Event<Unit>();
    public static Event<Unit> OnUnitDeselected = new Event<Unit>();
    public static Event<Unit> OnUnitStartAbility = new Event<Unit>();
    public static Event<Unit> OnUnitEndAbility = new Event<Unit>();
}

public class Event<T> {
    public delegate void OnEventDelegate(T arg);
    public event OnEventDelegate OnEvent;
    public void Invoke(T arg) {
        if (OnEvent != null) {
            OnEvent(arg);
        }
    }

    public void AddListener(OnEventDelegate listener) {
        OnEvent += listener;
    }

    public void RemoveListener(OnEventDelegate listener) {
        OnEvent -= listener;
    }
}

public interface IEventHandler<T> { }