﻿namespace RandomSquares;

public class VirtualScreenRow
{
    private readonly VirtualScreenCell[] _cells;

    public VirtualScreenRow(int screenWidth)
    {
        _cells = new VirtualScreenCell[screenWidth];
        for (var i = 0; i < screenWidth; i++)
        {
            _cells[i] = new VirtualScreenCell();
        }
    }

    public void AddBoxTopRow(int boxX, int boxWidth)
    {
        _cells[boxX].AddUpperLeftCorner();
        for (var i = 1; i < boxWidth - 1; i++)
        {
            _cells[boxX + i].AddHorizontal();
        }
        _cells[boxX + boxWidth - 1].AddUpperRightCorner();
    }

    public void AddBoxBottomRow(int boxX, int boxWidth)
    {
        _cells[boxX].AddLowerLeftCorner();
        for (var i = 1; i < boxWidth - 1; i++)
        {
            _cells[boxX + i].AddHorizontal();
        }
        _cells[boxX + boxWidth - 1].AddLowerRightCorner();
    }

    public void AddBoxMiddleRow(int boxX, int boxWidth)
    {
        _cells[boxX].AddVertical();
        _cells[boxX + boxWidth - 1].AddVertical();
    }
    public void Show()
    {
        var chars = _cells.Select(cell => cell.GetCharacter()).ToList();
        Console.WriteLine($"{string.Join("", chars)}");
    }
}