namespace libs;

public class DialogOption {
    public string text;
    public List<Answer> options = new List<Answer>();

    public DialogOption(string text) {
        this.text = text;
    }

    public void AddAnswer(Answer answer) {
        this.options.Add(answer);
    }
}