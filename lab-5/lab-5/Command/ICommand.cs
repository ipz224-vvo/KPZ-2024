namespace lab_5.Command;

public interface ICommand<T>
{
    void Execute(T node);
}