namespace Q2_Flip_Key
{
	/// <summary>
	/// Flip Key Generator - Transforms words by removing even ASCII characters and reversing
	/// </summary>
	public class Program
	{
		public static void Main(string[] args)
		{
			// Prompt for input word
			Console.WriteLine("Enter the word");
			string input = Console.ReadLine() ?? string.Empty;

			// Process and display result
			string key = new Program().CleanseAndInvert(input);
			Console.WriteLine(string.IsNullOrEmpty(key) ? "Invalid Input" : $"The generated key is - {key}");
		}

		/// <summary>
		/// Cleanses input by removing even ASCII characters and inverts the result
		/// </summary>
		/// <param name="input">Input word to transform</param>
		/// <returns>Generated key or empty string if invalid</returns>
		public string CleanseAndInvert(string input)
		{
			// Validate input length (must be at least 6 characters)
			if (string.IsNullOrEmpty(input) || input.Length < 6)
			{
				return string.Empty;
			}

			// Validate input contains only letters (no spaces, digits, or special characters)
			foreach (char c in input)
			{
				if (!char.IsLetter(c))
				{
					return string.Empty;
				}
			}

			// Convert to lowercase for processing
			string lower = input.ToLower();
			List<char> filtered = new List<char>();

			// Remove characters with even ASCII values (keep only odd ASCII)
			foreach (char c in lower)
			{
				if (((int)c % 2) != 0)
				{
					filtered.Add(c);
				}
			}

			// Reverse the filtered characters
			filtered.Reverse();

			// Convert even-positioned characters (0-based index) to uppercase
			for (int i = 0; i < filtered.Count; i++)
			{
				if (i % 2 == 0)
				{
					filtered[i] = char.ToUpper(filtered[i]);
				}
			}

			// Return the final generated key
			return new string(filtered.ToArray());
		}
	}
}
