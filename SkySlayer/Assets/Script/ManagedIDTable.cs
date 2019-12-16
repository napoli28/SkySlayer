using System.Collections.Generic;

public class AutoIDTable<TValue> : Dictionary<int, TValue>
{
    public AutoIDTable()
    {
        removed = new List<int>();
        next = 0;
    }
    
    private List<int> removed;
    private int next;

    public int Add(TValue value)
    {
        int _key = NewKey();
        base.Add(_key, value);
        return _key;
    }

    public new bool Remove(int key)
    {
        bool _result = base.Remove(key);
        if (_result)
        {
            removed.Add(key);
        }
        return _result;
    }

    private int NewKey()
    {
        int _key;
        if (removed.Count == 0)
        {
            _key = next;
            next += 1;
        }
        else
        {
            _key = removed[0];
            removed.RemoveAt(0);
        }
        return _key;
    }
}
