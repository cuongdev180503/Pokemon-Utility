﻿using Avalonia.Controls;
using System;
using System.Linq;

public class SortingButton : Button
{
    // Constructor
    public SortingButton()
    {
        this.Content = "Sort";
    }

    // Method to sort the 2D array by name
    public void SortingByName(string[,] pokemonList)
    {
        SortArray(pokemonList, 1); // Sort by name (index 1)
    }

    // Method to sort the 2D array by ID
    public void SortingById(string[,] pokemonList)
    {
        SortArray(pokemonList, 0); // Sort by ID (index 0)
    }

    // Generic method to sort the array by a specified column index
    private void SortArray(string[,] pokemonList, int columnIndex)
    {
        // Get the length of the second dimension 
        int numColumns = pokemonList.GetLength(1);

        // Sort the array by the values 
        var sortedList = Enumerable.Range(0, pokemonList.GetLength(0))
            .Select(i => new
            {
                Id = pokemonList[i, 0],
                Name = pokemonList[i, 1],
                Type = pokemonList[i, 2]
            })
            .OrderBy(item => columnIndex == 0 ? item.Id : item.Name)
            .ToArray();

        // Update the original array with the sorted values
        for (int i = 0; i < sortedList.Length; i++)
        {
            pokemonList[i, 0] = sortedList[i].Id;
            pokemonList[i, 1] = sortedList[i].Name;
            pokemonList[i, 2] = sortedList[i].Type;
        }
    }
}
