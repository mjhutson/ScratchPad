using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ConnectFour{
    const int TIE = 0;
    const int PLAYER1 = 1;
    const int PLAYER2 = 2;
    const int COLUMNS = 7;

    GameBoard _board;

    public ConnectFour(){
        _board = new GameBoard();
    }

    public string play(){
        var gameOver = false;
        var player = PLAYER1;
        var winner = TIE;
        
        while(!gameOver){
            if(_board.isBoardFull()){
                gameOver = true;
                break;
            }
            var move = pickAColumn();
            var wonMaybe = _board.insert(move, player);
            if(wonMaybe){
                winner = player;
                gameOver = true;
            }
            if(!gameOver){ player = switchPlayer(player); }
        }

        return winningPlayerMessage(winner);
    }

    public string winningPlayerMessage(int player){
        return player == 0 ? $"Tie Game" : $"Player {player} Won!";
    }

    public int switchPlayer(int previousPlayer){
        int nextPlayer = previousPlayer == PLAYER1 ? nextPlayer = PLAYER2 : nextPlayer = PLAYER1;
        Console.WriteLine($"Player {nextPlayer}");
        return nextPlayer;
    }

    public int pickAColumn(){
        var random = new Random();
        var validMove = false;
        var move = 0;

        while(!validMove){
            move = random.Next(0, COLUMNS);
            if (!_board.isColumnFull(move)){ validMove = true; }
        }

        return move;
    }
}

public class GameBoard{

    const int COLUMNS = 7;
    const int ROWS = 6;
    const int WIN = 4;
    const int NEIGHBORINGTOKENS = 3;
    const int BOARDWIDTH = 29;
    const string NEWLINE = "\n";

    List<int> col1;
    List<int> col2;
    List<int> col3;
    List<int> col4;
    List<int> col5;
    List<int> col6;
    List<int> col7;
    List<List<int>> _board;
    string _divider;

    public GameBoard(){
        col1 = new List<int>(){0,0,0,0,0,0};
        col2 = new List<int>(){0,0,0,0,0,0};
        col3 = new List<int>(){0,0,0,0,0,0};
        col4 = new List<int>(){0,0,0,0,0,0};
        col5 = new List<int>(){0,0,0,0,0,0};
        col6 = new List<int>(){0,0,0,0,0,0};
        col7 = new List<int>(){0,0,0,0,0,0};
        _board = new List<List<int>>{col1, col2, col3, col4, col5, col6, col7};
        var sB = new StringBuilder();
        sB.Append('-', BOARDWIDTH);
        _divider = sB.ToString();
    }
    
    public void printBoard(){
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"{_divider}{NEWLINE}");
        for(int j = 1; j <= ROWS; j++){
            stringBuilder.Append("|");
            for(int i = 0; i < COLUMNS; i++){
                var token = _board[i][ROWS - j] > 0 ? $"{_board[i][ROWS - j]}" : " ";
                stringBuilder.Append($" {token} |");
            }
            stringBuilder.Append($"{NEWLINE}{_divider}{NEWLINE}");
        }
        stringBuilder.Append(NEWLINE);
        Console.Write(stringBuilder.ToString());
        
    }

    public bool insert(int column, int player){
        if (!isColumnFull(column)){
            var row = getNextFreeSpace(column);
            _board[column][row] = player;
            printBoard();
            if(checkIfPieceWon(column, row, player)) { return true;}
        }
        return false;
    }

    public bool isColumnFull(int column){
        return _board[column].Where(x => x == 0).Count() == 0;
    }

    public bool isBoardFull(){
        var fullColumns = 0;
        foreach(var column in _board){
            if(isColumnFull(_board.IndexOf(column))){
                fullColumns ++;
            }
        }

        return fullColumns == COLUMNS;
    }

    public int getNextFreeSpace(int column){
        var columnSpaces = _board[column];
        for(int i = ROWS - 1; i >= 0; i--){
            if(columnSpaces[i] != 0){
                return i + 1;
            }
        }
        return 0;
    }

    public bool checkIfPieceWon(int column, int row, int player){
        var horz = searchHorizontal(column, row, player);
        var vert = seachVertical(column, row, player);
        var lR = seachLRDiagonal(column, row, player);
        var rL = seachRLDiagonal(column, row, player);

        return Math.Max(rL, Math.Max(lR, Math.Max(vert, Math.Max(horz, 1)))) >= WIN;
    }

    public int seachRLDiagonal(int column, int row, int player){
        var total = 1;

        for(int i = 1; i <= NEIGHBORINGTOKENS; i++){
            if((row + i < ROWS) && (column + i < COLUMNS) && (_board[column + i][row + i] == player)){
                total++;
            }
            if((row - i >= 0) && (column - i >= 0) && (_board[column - i][row - i] == player)){
                total++;
            }
            else {break; }  
        }

        return total;
    }

    public int seachLRDiagonal(int column, int row, int player){
        var total = 1;

        for(int i = 1; i <= NEIGHBORINGTOKENS; i++){
            if((row + i < ROWS) && (column - i >= 0) && (_board[column - i][row + i] == player)){
                total++;
            }
            else if((row - i >= 0) && (column + i < COLUMNS) && (_board[column + i][row - i] == player)){
                total++;
            }
            else { break; }
        }

        return total;
    }

    public int seachVertical(int column, int row, int player){
        var total = 1;

        for (int i = 1; i <= NEIGHBORINGTOKENS; i++) {
            if ((row + i < ROWS) && (_board[column][row + i] == player)) {
                total++;
            }
            else if ((row - i >= 0) && (_board[column][row - i] == player)) {
                total++;
            }
            else { break; }
        }

        return total;
    }

    public int searchHorizontal(int column, int row, int player){
        var total = 1;
        
        for(int i = 1; i <= NEIGHBORINGTOKENS; i++){
            if((column + i < COLUMNS) && (_board[column + i][row] == player)){
                total++;
            }
            else if((column - i >= 0) && (_board[column - i][row] == player)){
                total++;
            }
            else { break; }
        }
        return total;
    }
}