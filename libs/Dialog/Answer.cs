namespace libs;

public class Answer {
    public string text;
    public DialogOption? nextNode;

    public Answer(string text, DialogOption? nextNode) {
        this.text = text;
        this.nextNode = nextNode;
    }
}