namespace libs;

public class Dialog {
    public DialogOption currentNode;
    public DialogOption startNode;

    public Dialog(DialogOption startNode) {
        this.startNode = startNode;
        this.currentNode = startNode;
    }

    public void Run() {
        while (this.currentNode != null) {
            Console.WriteLine(this.currentNode.text);
            
            if (this.currentNode.options == null || this.currentNode.options.Length == 0) {
                break;
            }

            for (int i = 0; i < this.currentNode.options.Length; i++) {
                Console.WriteLine($"{i + 1}. {this.currentNode.options[i].text}");
            }

            int choice = Convert.ToInt32(Console.ReadLine());
            this.currentNode = this.currentNode.options[choice - 1].nextNode;
            GameEngine.Instance.Render();
        }
        Thread.Sleep(500);

    }
}