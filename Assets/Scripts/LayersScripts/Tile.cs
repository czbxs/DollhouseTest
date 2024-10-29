/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour 
{
    public TILE_TYPE type;
    public Node node;

    float borderPosition = 0.55f;

    public void SetBorder()
    {
        SetBorderTop();

        SetBorderBottom();

        SetBorderLeft();

        SetBorderRight();
    }

    void SetBorderTop()
    {
        // if this tile is none/pass then do not set border
        if (NoTile()) return;

        var name = "";

        Node top = node.TopNeighbor();

        // this node is able to set top border
        if (!TileNode(top))
        {
            //print("Node: " + node.name);

            name += "top_";

            // left
            Node topLeft = node.TopLeftNeighbor();
            if (TileNode(topLeft))
            {
                name += "left_bevel_";
            }
            else
            {
                Node left = node.LeftNeighbor();
                if (TileNode(left))
                {
                    name += "top_";
                }
                else
                {
                    name += "left_corner_";
                }
            }

            // right
            Node topRight = node.TopRightNeighbor();
            if (TileNode(topRight))
            {
                name += "right_bevel";
            }
            else
            {
                Node right = node.RightNeighbor();
                if (TileNode(right))
                {
                    name += "top";
                }
                else
                {
                    name += "right_corner";
                }
            }
        }

        if (name != "")
        {
            var border = Instantiate(Resources.Load(Configuration.TileBorderTop() + name)) as GameObject;
            border.name = name;
            border.transform.position = gameObject.transform.position + new Vector3(0, borderPosition, 0);
            border.transform.SetParent(gameObject.transform);
        }
    }

    void SetBorderBottom()
    {
        if (NoTile()) return;

        var name = "";
        Node bottom = node.BottomNeighbor();

        if (!TileNode(bottom))
        {
            name += "bottom_";

            Node bottomLeft = node.BottomLeftNeighbor();
            if (TileNode(bottomLeft))
            {
                name += "left_bevel_";
            }
            else
            {
                Node left = node.LeftNeighbor();
                if (TileNode(left))
                {
                    name += "bottom_";
                }
                else
                {
                    name += "left_corner_";
                }
            }

            Node bottomRight = node.BottomRightNeighbor();
            if (TileNode(bottomRight))
            {
                name += "right_bevel";
            }
            else
            {
                Node right = node.RightNeighbor();
                if (TileNode(right))
                {
                    name += "bottom";
                }
                else
                {
                    name += "right_corner";
                }
            }
        }

        if (name != "")
        {
            var border = Instantiate(Resources.Load(Configuration.TileBorderBottom() + name)) as GameObject;
            border.name = name;
            border.transform.position = gameObject.transform.position + new Vector3(0, -borderPosition, 0);
            border.transform.SetParent(gameObject.transform);
        }
    }

    void SetBorderLeft()
    {
        if (NoTile()) return;

        var name = "";

        Node left = node.LeftNeighbor();

        if (!TileNode(left))
        {
            name += "left_";

            // top
            Node topLeft = node.TopLeftNeighbor();
            if (TileNode(topLeft))
            {
                name += "top_bevel_";
            }
            else
            {
                Node top = node.TopNeighbor();
                if (TileNode(top))
                {
                    name += "left_";
                }
                else
                {
                    name += "top_corner_";
                }
            }

            // bottom
            Node bottomLeft = node.BottomLeftNeighbor();
            if (TileNode(bottomLeft))
            {
                name += "bottom_bevel";
            }
            else
            {
                Node bottom = node.BottomNeighbor();
                if (TileNode(bottom))
                {
                    name += "left";
                }
                else
                {
                    name += "bottom_corner";
                }
            }
        }

        if (name != "")
        {
            var border = Instantiate(Resources.Load(Configuration.TileBorderLeft() + name)) as GameObject;
            border.name = name;
            border.transform.position = gameObject.transform.position + new Vector3(-borderPosition, 0, 0);
            border.transform.SetParent(gameObject.transform);
        }
    }

    void SetBorderRight()
    {
        if (NoTile()) return;

        var name = "";

        Node right = node.RightNeighbor();

        if (!TileNode(right))
        {
            name += "right_";

            // top
            Node topRight = node.TopRightNeighbor();
            if (TileNode(topRight))
            {
                name += "top_bevel_";
            }
            else
            {
                Node top = node.TopNeighbor();
                if (TileNode(top))
                {
                    name += "right_";
                }
                else
                {
                    name += "top_corner_";
                }
            }

            // bottom
            Node bottomRight = node.BottomRightNeighbor();
            if (TileNode(bottomRight))
            {
                name += "bottom_bevel";
            }
            else
            {
                Node bottom = node.BottomNeighbor();
                if (TileNode(bottom))
                {
                    name += "right";
                }
                else
                {
                    name += "bottom_corner";
                }
            }
        }

        if (name != "")
        {
            var border = Instantiate(Resources.Load(Configuration.TileBorderRight() + name)) as GameObject;
            border.name = name;
            border.transform.position = gameObject.transform.position + new Vector3(borderPosition, 0, 0);
            border.transform.SetParent(gameObject.transform);
        }
    }

    public bool NoTile()
    {
        if (type == TILE_TYPE.NONE || type == TILE_TYPE.PASS_THROUGH)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TileNode(Node check)
    {
        if (check != null)
        {
            if (check.tile.type == TILE_TYPE.LIGHT_TILE || check.tile.type == TILE_TYPE.DARD_TILE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
