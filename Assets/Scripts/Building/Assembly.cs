using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Assembly : MonoBehaviour
{
    //Test
    /*private void Start()
    {
        PartInfo[,] parts = new PartInfo[,] {
            { new PartInfo("Driver", "top", "debug", "driver"),
              null,
              new PartInfo("Weapon", "top", "debug", "weapon")
            },
            { new PartInfo("Struct", "all", "debug", "construction"), 
              new PartInfo("Struct", "all", "debug", "construction"),
              new PartInfo("Struct", "all", "debug", "construction")
            },
            { 
              new PartInfo("Suspension", "wheels", "debug", "suspension"),
              null,
              new PartInfo("Suspension", "wheels", "debug", "suspension")
            },
            {
              new PartInfo("Wheel", "joints", "debug", "wheel"),
              null,
              new PartInfo("Wheel", "joints", "debug", "wheel")
            }
        };
        Build(parts, new Vector2(-5, 3), "Test");
    }*/

    public void Build(PartInfo[,] parts, Vector2 spawnPoint, string name)
    {
        List<WheelJoint2D> wheelJoints = new List<WheelJoint2D>();
        int rows = parts.GetUpperBound(0) + 1;
        int cols = parts.Length / rows;
        GameObject vehicle = new GameObject(name);
        VehicleMovement movement = vehicle.AddComponent<VehicleMovement>();
        vehicle.AddComponent<VehicleAttack>();
        movement.wheelSpeed = 400;
        vehicle.SetActive(false);
        vehicle.SetActive(true);
        vehicle.transform.position = spawnPoint;
        GameObject hull = new GameObject("Hull");
        vehicle.AddComponent<Player>();
        hull.transform.position = vehicle.transform.position;
        hull.transform.SetParent(vehicle.transform);
        //float mass = 0f;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {


                PartInfo part = parts[row, col];
                if (part != null)
                {
                    if (part.type == "construction" || part.type == "driver" || part.type == "armor")
                    {
                        GameObject newPart = (GameObject)Resources.Load($"prefabs/carParts/{part.type}/{part.level}/{part.name}");
                        newPart = Instantiate(newPart);
                        if (CheckNeighbors(row, col, "all") != null)
                        {
                            newPart.transform.SetParent(hull.transform);
                            Debug.Log($"{col}, {row}");
                            newPart.transform.localPosition = new Vector2(col, - row);
                            //mass += part.mass
                        }
                        else newPart.transform.parent = null;

                    }
                    if (part.type == "suspension")
                    {
                        if (CheckNeighbors(row, col, "all") != null)
                        {
                            WheelJoint2D wheelJoint = hull.AddComponent<WheelJoint2D>();
                            wheelJoints.Add(wheelJoint);
                            wheelJoint.anchor = new Vector2(col, - row);
                            Tuple<int, int> closestWheel = (CheckNeighbors(row, col, "joints"));
                            if (closestWheel != null)
                            {
                                PartInfo wheelInfo = parts[closestWheel.Item1, closestWheel.Item2];
                                GameObject wheelPrefab = (GameObject)Resources.Load($"prefabs/carParts/{wheelInfo.type}/{wheelInfo.level}/{wheelInfo.name}");
                                GameObject wheel = Instantiate(wheelPrefab);
                                wheel.transform.SetParent(vehicle.transform);
                                wheel.transform.localPosition = new Vector2(col, - row);
                                wheelJoint.connectedBody = wheel.GetComponent<Rigidbody2D>();
                            }
                        }
                    }
                    if (part.type == "weapon")
                    {
                        GameObject weaponPrefab = (GameObject)Resources.Load($"prefabs/carParts/{part.type}/{part.level}/{part.name}");
                        GameObject weapon = Instantiate(weaponPrefab);
                        if (part.bindingType == "side")
                        {
                            if (col > 0)
                            {
                                if (parts[row, col - 1] != null)
                                {
                                    if (parts[row, col - 1].bindingType == "all")
                                    {
                                        weapon.transform.SetParent(hull.transform);
                                        weapon.transform.localPosition = new Vector2(col, -row);
                                        //mass += part.mass
                                    }
                                }
                                
                            }
                        }
                        if (part.bindingType == "top")
                        {
                            if (row < rows)
                            {
                                if (parts[row + 1, col] != null)
                                {
                                    if (parts[row + 1, col].bindingType == "all")
                                    {
                                        weapon.transform.SetParent(hull.transform);
                                        weapon.transform.localPosition = new Vector2(col, -row);
                                    }
                                }
                            }
                        }
                    }
                }

       
            }
        }
        movement.wheels = wheelJoints.ToArray();
        Rigidbody2D rb = hull.GetComponent<Rigidbody2D>();
        //rb.mass = mass
        rb.mass = 5f;



        Tuple<int, int> CheckNeighbors(int row, int col, string bindingType)
        {
            if (row > 0)
            {
                var neighbor = parts[row - 1, col];
                if (neighbor != null) {
                    if (neighbor.bindingType == bindingType)
                    {
                        return new Tuple<int, int>(row - 1, col);
                    }
                }
            }
            if (col > 0)
            {
                var neighbor = parts[row, col - 1];
                if (neighbor != null)
                {
                    if (neighbor.bindingType == bindingType)
                    {
                        return new Tuple<int, int>(row, col - 1);
                    }
                }
            }
            if (row < rows - 1)
            {
                var neighbor = parts[row + 1, col];
                if (neighbor != null)
                {
                    if (neighbor.bindingType == bindingType)
                    {
                        return new Tuple<int, int>(row + 1, col);
                    }
                }
            }
            if (col < cols - 1)
            {
                var neighbor = parts[row, col + 1];
                if (neighbor != null)
                {
                    if (neighbor.bindingType == bindingType)
                    {
                        return new Tuple<int, int>(row, col + 1);
                    }
                }
            }
            return null;
        }

        
    }
}
