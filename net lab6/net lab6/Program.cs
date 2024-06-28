using System;
using System.Collections.Generic;

class Player
{
    public char Symbol { get; private set; }

    public Player(char symbol)
    {
        Symbol = symbol;
    }
}

class Board
{
    private char[] cells = new char[9];

    public Board()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = ' ';
        }
    }

    public char Get(int position)
    {
        return cells[position];
    }

    public void Set(int position, char symbol)
    {
        cells[position] = symbol;
    }

    public bool CheckWin()
    {
        int[][] winCombinations = new int[][]
        {
            new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 },
            new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 },
            new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 }
        };

        foreach (var combo in winCombinations)
        {
            if (cells[combo[0]] == cells[combo[1]] && cells[combo[1]] == cells[combo[2]] && cells[combo[0]] != ' ')
            {
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        foreach (var cell in cells)
        {
            if (cell == ' ')
            {
                return false;
            }
        }
        return true;
    }

    public void Display()
    {
        for (int i = 0; i < cells.Length; i += 3)
        {
            Console.WriteLine($"{cells[i]} | {cells[i + 1]} | {cells[i + 2]}");
            if (i < 6)
            {
                Console.WriteLine("---------");
            }
        }
    }
}

interface ICommand
{
    void Execute();
    void Undo();
}

class MoveCommand : ICommand
{
    private Board board;
    private Player player;
    private int position;

    public MoveCommand(Board board, Player player, int position)
    {
        this.board = board;
        this.player = player;
        this.position = position;
    }

    public void Execute()
    {
        board.Set(position, player.Symbol);
    }

    public void Undo()
    {
        board.Set(position, ' ');
    }
}

class GameHistory
{
    private Stack<ICommand> commands = new Stack<ICommand>();

    public void AddCommand(ICommand command)
    {
        commands.Push(command);
    }

    public ICommand Undo()
    {
        if (commands.Count > 0)
        {
            return commands.Pop();
        }
        return null;
    }
}

class TicTacToe
{
    private Board board;
    private GameHistory history;
    private Player currentPlayer;

    public TicTacToe()
    {
        board = new Board();
        history = new GameHistory();
        currentPlayer = new Player('X');
    }

    private void SwitchPlayer()
    {
        currentPlayer = currentPlayer.Symbol == 'X' ? new Player('O') : new Player('X');
    }

    public void Move(int position)
    {
        if (board.Get(position) == ' ')
        {
            var command = new MoveCommand(board, currentPlayer, position);
            command.Execute();
            history.AddCommand(command);
            if (!board.CheckWin() && !board.IsFull())
            {
                SwitchPlayer();
            }
        }
    }

    public void Undo()
    {
        ICommand command = history.Undo();
        if (command != null)
        {
            command.Undo();
            SwitchPlayer();
        }
    }

    public void Display()
    {
        board.Display();
    }

    public bool CheckWin()
    {
        return board.CheckWin();
    }

    public bool IsFull()
    {
        return board.IsFull();
    }

    public char CurrentPlayerSymbol()
    {
        return currentPlayer.Symbol;
    }
}

class Program
{
    static void Main(string[] args)
    {
        TicTacToe game = new TicTacToe();
        while (!game.CheckWin() && !game.IsFull())
        {
            game.Display();
            Console.WriteLine($"Гравець {game.CurrentPlayerSymbol()}, введіть позицію (1-9):");
            int position = (int.Parse(Console.ReadLine()))-1;
            game.Move(position);
        }

        game.Display();

        if (game.CheckWin())
        {
            Console.WriteLine($"Гравець {game.CurrentPlayerSymbol()} виграв!");
        }
        else
        {
            Console.WriteLine("Нічия!");
        }

        Console.WriteLine("\nВідмінити останній хід:");
        game.Undo();
        game.Display();

        Console.WriteLine("\nВідмінити ще один хід:");
        game.Undo();
        game.Display();
    }
}
