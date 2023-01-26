using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ConnectedRuleTile : RuleTile
{
    
    public enum SiblingGroup
    {
        Poles,
        Terrain,
    }
    public SiblingGroup siblingGroup;
    
    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is RuleOverrideTile)
            other = (other as RuleOverrideTile).m_InstanceTile;

        switch (neighbor)
        {
            case TilingRule.Neighbor.This:
            {
                return other is ConnectedRuleTile
                       && (other as ConnectedRuleTile).siblingGroup == this.siblingGroup;
            }
            case TilingRule.Neighbor.NotThis:
            {
                return !(other is ConnectedRuleTile
                         && (other as ConnectedRuleTile).siblingGroup == this.siblingGroup);
            }
        }

        return base.RuleMatch(neighbor, other);
    }
}
