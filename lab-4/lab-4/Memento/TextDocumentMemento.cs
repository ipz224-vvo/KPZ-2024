namespace lab_4.Memento;

public class TextDocumentMemento
{
    private string _text;

    public TextDocumentMemento(string text)
    {
        _text = text;
    }

    public string GetSavedText()
    {
        return _text;
    }
}