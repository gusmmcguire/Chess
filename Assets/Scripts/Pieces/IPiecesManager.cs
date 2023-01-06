using Pieces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPiecesManager
{
    public List<GameObject> FindKings();
    public GameObject FindKing(Piece.Team team);
    public bool IsEnemy(Vector2Int vect, Piece.Team myTeam);
    public Vector3 GetTarget(Vector2Int poss);
    public bool Animations();
    public List<Vector2Int> GetOccupied();
    public List<Vector2Int> GetOccupied(Piece.Team team);
    public List<Vector2Int> GetValidVectors();
    public (int, int) GetDimensions();
    public void PromotePawn(Vector3 poss, Vector2Int boardIndex, Piece.Team team);
    public (List<Vector2Int> movements, List<Vector2Int> enemies) AllMovements(Piece.Team team);
    public void KillPiece(GameObject piece, Vector2Int poss);
    public void HighlightTile(bool state, Vector2Int poss);
    public Piece.Team Turn();
    public void SelectTarget(GameObject target, (List<Vector2Int> movements, List<Vector2Int> enemies) moves);
    public void DropTarget();
}
