using El_reto_de_las_8_piezas;
using System;



class Piece
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Piece(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public virtual bool IsSafe(Piece[] pieces, int currentRow, int currentColumn)
    {
        foreach (Piece piece in pieces)
        {
            if (piece != null &&
                (piece.Row == currentRow || piece.Column == currentColumn))
            {
                return false;
            }
        }
        return true;
    }
}

class Queen : Piece
{
    public Queen(int row, int column) : base(row, column) { }

    public override bool IsSafe(Piece[] pieces, int currentRow, int currentColumn)
    {
        if (base.IsSafe(pieces, currentRow, currentColumn))
        {
            for (int i = 0; i < currentRow; i++)
            {
                if (pieces[i] != null &&
                    Math.Abs(pieces[i].Row - currentRow) == Math.Abs(pieces[i].Column - currentColumn))
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}

class Rook : Piece
{
    public Rook(int row, int column) : base(row, column) { }

    public override bool IsSafe(Piece[] pieces, int currentRow, int currentColumn)
    {
        if (base.IsSafe(pieces, currentRow, currentColumn))
        {
            for (int i = 0; i < currentRow; i++)
            {
                if (pieces[i] != null && pieces[i].Column == currentColumn)
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}

class Bishop : Piece
{
    public Bishop(int row, int column) : base(row, column) { }

    public override bool IsSafe(Piece[] pieces, int currentRow, int currentColumn)
    {
        if (base.IsSafe(pieces, currentRow, currentColumn))
        {
            for (int i = 0; i < currentRow; i++)
            {
                if (pieces[i] != null &&
                    Math.Abs(pieces[i].Row - currentRow) == Math.Abs(pieces[i].Column - currentColumn))
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}

class Program
{
    static int N = 8;

    static void SolvePieces(int currentRow, Piece[] pieces)
    {
        if (currentRow == N)
        {
            PrintBoard(pieces);
            throw new SinSolucionException();
            //return;
        }

        for (int column = 0; column < N; column++)
        {
            bool pieceSafe = true;

            foreach (Piece piece in pieces)
            {
                if (piece != null && !piece.IsSafe(pieces, currentRow, column))
                {
                    pieceSafe = false;
                    break;
                }
            }

            if (pieceSafe)
            {
                pieces[currentRow] = new Bishop(currentRow, column);
                SolvePieces(currentRow + 1, pieces);
                pieces[currentRow] = null;
            }
        }
    }

    static void PrintBoard(Piece[] pieces)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                bool pieceFound = false;
                foreach (Piece piece in pieces)
                {
                    if (piece != null && piece.Row == i && piece.Column == j)
                    {
                        Console.Write("B ");
                        pieceFound = true;
                        break;
                    }
                }

                if (!pieceFound)
                    Console.Write(". ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Piece[] pieces = new Piece[N];
        for (int i = 0; i < N; i++)
        {
            pieces[i] = null;
        }

        try {
            SolvePieces(0, pieces);
        } catch (SinSolucionException ex){
            Console.WriteLine("Error: " + ex.Message);
            Console.WriteLine("Stack Trace: " + ex.StackTrace);
        }
    }
}
