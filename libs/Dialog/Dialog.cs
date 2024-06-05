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
            
            if (this.currentNode.options == null || this.currentNode.options.Count == 0) {
                break;
            }

            for (int i = 0; i < this.currentNode.options.Count; i++) {
                Console.WriteLine($"{i + 1}. {this.currentNode.options[i].text}");
            }

            int choice;
            while (true)
            {
                Console.Write("Choose an option: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= this.currentNode.options.Count)
                {
                    break;
                }
                Console.WriteLine("Invalid choice, please try again.");
            }
            this.currentNode = this.currentNode.options[choice - 1].nextNode;
            GameEngine.Instance.Render();
        }
        Thread.Sleep(1000);

    }
}