using System.Text;
namespace csharpos;

class Csos
{
    static bool hadError = false;
    static void Main(string[] args)
    {
        if(args.Length > 1) {
            Console.WriteLine("Usage: csharpos [script]");
            Environment.Exit(64);
        } else if(args.Length == 1) {
            runFile(args[0]);
        } else {
            runPrompt();
        }
    }

    private static void runFile(string path) {
        byte[] bytes = File.ReadAllBytes(path);
        string text = Encoding.UTF8.GetString(bytes);
        run(text);
        if (hadError) Environment.Exit(65);
    }


    private static void runPrompt() {
        while(true) {
            Console.Write("> ");
            string line = Console.ReadLine();
            if (line == null) break;
            run(line);
            hadError = false;
        }
    }

    private static void run(string source) {
        Scanner scanner = new Scanner(source);
        List<Token> tokens = scanner.scanTokens();


        foreach (Token token in tokens) {
            Console.WriteLine(token.toString());
        }
    }

    public static void error(int line, string message) {
        report(line, "", message);
    }

    private static void report(int line, string where, string message) {
        Console.Error.WriteLine($"[line {line}] Error{where}: {message}");
        hadError = true;
    }

}
