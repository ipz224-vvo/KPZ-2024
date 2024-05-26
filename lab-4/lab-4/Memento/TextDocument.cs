namespace lab_4.Memento;

public class TextDocument
{
    private string _text;

    public TextDocument(string text)
    {
        _text = text;
    }

    public string GetText()
    {
        return _text;
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public TextDocumentMemento Save()
    {
        return new TextDocumentMemento(_text);
    }

    public void Restore(TextDocumentMemento memento)
    {
        _text = memento.GetSavedText();
    }
}