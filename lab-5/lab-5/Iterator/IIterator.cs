namespace lab_5.Iterator;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
}