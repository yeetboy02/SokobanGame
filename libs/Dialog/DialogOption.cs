namespace libs;

public class DialogOption {
    public string text;
    public Answer[] options;

    public DialogOption(string text, Answer[] options) {
        this.text = text;
        this.options = options;
    }
}