using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Pieces;
using UnityEngine;
using UnityEngine.TestTools;


public class Chess960Tester
{
    [Test]
    public void Chess960ValidRandomPlacement()
    {
        var pieceManager = new PiecesManager960();
        var piecePlacement = pieceManager.RandomizeStart();

        int indexOfRook1 = piecePlacement.IndexOf(('R', 'W'));
        int indexOfRook2 = piecePlacement.LastIndexOf(('R', 'W'));
        int indexOfKing = piecePlacement.IndexOf(('K', 'W'));
        int indexOfBishop1 = piecePlacement.IndexOf(('B', 'W'));
        int indexOfBishop2 = piecePlacement.LastIndexOf(('B', 'W'));

        Assert.IsTrue(indexOfRook1 < indexOfKing && indexOfKing < indexOfRook2);
        Assert.IsTrue(indexOfBishop1 % 2 != indexOfBishop2 % 2);
    }

    [Test]
    public void Chess960CorrectPieceCount()
    {
        var pieceManager = new PiecesManager960();
        var piecePlacement = pieceManager.RandomizeStart();
        var blackPlacement = pieceManager.BlackSideFromWhiteSide(piecePlacement);


        Assert.IsTrue(piecePlacement.Count == 8);
        Assert.IsTrue(blackPlacement.Count == 8);
    }

    [Test]
    public void Chess960BlackRowSameAsWhite()
    {
        var pieceManager = new PiecesManager960();
        var piecePlacement = pieceManager.RandomizeStart();
        var blackPlacement = pieceManager.BlackSideFromWhiteSide(piecePlacement);

        for (int i = 0; i < piecePlacement.Count; i++)
        {
            Assert.IsTrue(piecePlacement[i].Item1 == blackPlacement[i].Item1);
        }
    }

    [Test]
    public void Chess960RevalidateBishop()
    {
        List<char> remainingPieces = new List<char> { 'R', 'H', 'H', 'Q', 'B' };
        List<char> validPieces = new List<char> { 'R', 'H', 'Q' };
        List<(char, char)> startingRowPlacementsOddBishop = new List<(char, char)> { ('R', 'W'), ('B', 'W'), ('K', 'W') };

        PiecesManager960.BishopRevalidation(startingRowPlacementsOddBishop, remainingPieces, validPieces);
        Assert.IsTrue(validPieces.Contains('B') == false);

        remainingPieces = new List<char> { 'R', 'H', 'H', 'Q', 'B' };
        validPieces = new List<char> { 'R', 'H', 'Q' };
        List<(char, char)> startingRowPlacementsEvenBishop = new List<(char, char)> { ('R', 'W'), ('K', 'W'), ('B', 'W') };
        PiecesManager960.BishopRevalidation(startingRowPlacementsEvenBishop, remainingPieces, validPieces);
        Assert.IsTrue(validPieces.Contains('B'));        
    }

    [Test]
    public void Chess960PieceInvalidation()
    {
        List<char> remainingPieces = new List<char> { 'R', 'H', 'H', 'Q', 'B', 'B' };
        List<char> validPieces = new List<char> { 'R', 'H', 'Q', 'B' };
        char randomPiece = 'Q';
        //var pieceManager = new PiecesManager960();
        PiecesManager960.PieceInvalidation(remainingPieces, validPieces, randomPiece);
        Assert.IsTrue(validPieces.Contains('Q') == false);
        Assert.IsTrue(remainingPieces.Contains('Q') == false);
    }
}
