public class DescriptionData : IDescriptionData
{
    private string _description;
    public string Description {
        get {
            return _description;
        }

        set {
            _description = value;
            OnDataChanged(this);
        }
    }

    public DescriptionData(string description) {
        _description = description;
    }

    public event DataChangedDelegate OnDataChanged;
}