// Created by Jay Johnson 9/27/2025
// This program prompts the user for a numerator and denominator,
// constructs a Lab05.RationalNumber and prints the reduced fraction.

// Note: Rhys told me my naming system was awful, so this is more descriptive
// She also told me to stop adding so many comments. *Sigh*
using System;
using Lab05;

namespace Lab05.Main;

public static class Program
{
	public static void Main()
	{
		Console.Write("Enter numerator: ");
		string? numText = Console.ReadLine();
		if (!int.TryParse(numText, out int numerator))
		{
			Console.WriteLine("Invalid numerator. Please enter a whole number.");
			return;
		}

		Console.Write("Enter denominator: ");
		string? denText = Console.ReadLine();
		if (!int.TryParse(denText, out int denominator))
		{
			Console.WriteLine("Invalid denominator. Please enter a whole number.");
			return;
		}

		if (denominator == 0)
		{
			Console.WriteLine("Denominator cannot be zero.");
			return;
		}

		var r = new RationalNumber(numerator, denominator);
		Console.WriteLine($"Reduced fraction: {r.Numerator}/{r.Denominator}");
	}
}


