namespace lab_4.Memento;

public class TextEditor
{
    private TextDocument _document;
    private Stack<TextDocumentMemento> _history;

    public TextEditor(TextDocument document)
    {
        _document = document;
        _history = new Stack<TextDocumentMemento>();
    }

    public void Type(string words)
    {
        _history.Push(_document.Save());
        _document.SetText(_document.GetText() + words);
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            TextDocumentMemento memento = _history.Pop();
            _document.Restore(memento);
        }
    }

    public void Print()
    {
        Console.WriteLine("Current Text: " + _document.GetText());
    }
}