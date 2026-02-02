namespace Q3_Stream_Buzz
{
	/// <summary>
	/// Represents a content creator's engagement statistics
	/// </summary>
	public class CreatorStats
	{
		public string CreatorName { get; set; } = string.Empty;
		public double[] WeeklyLikes { get; set; } = Array.Empty<double>();
	}

	/// <summary>
	/// StreamBuzz engagement tracker for managing creator statistics
	/// </summary>
	public class Program
	{
		// Global list to store all creator records
		public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

		public static void Main(string[] args)
		{
			Program app = new Program();
			bool running = true;

			// Main application loop
			while (running)
			{
				// Display menu options
				Console.WriteLine("1. Register Creator");
				Console.WriteLine("2. Show Top Posts");
				Console.WriteLine("3. Calculate Average Likes");
				Console.WriteLine("4. Exit");
				Console.WriteLine("Enter your choice:");

				string choice = Console.ReadLine() ?? string.Empty;

				switch (choice)
				{
					case "1":
						// Register new creator with weekly likes data
						Console.WriteLine("Enter Creator Name:");
						string name = Console.ReadLine() ?? string.Empty;

						Console.WriteLine("Enter weekly likes (Week 1 to 4):");
						double[] likes = new double[4];
						for (int i = 0; i < 4; i++)
						{
							likes[i] = double.Parse(Console.ReadLine() ?? "0");
						}

						app.RegisterCreator(new CreatorStats { CreatorName = name, WeeklyLikes = likes });
						Console.WriteLine("Creator registered successfully");
						Console.WriteLine();
						break;

					case "2":
						// Show creators who met the like threshold
						Console.WriteLine("Enter like threshold:");
						double threshold = double.Parse(Console.ReadLine() ?? "0");

						Dictionary<string, int> topCounts = app.GetTopPostCounts(EngagementBoard, threshold);
						if (topCounts.Count == 0)
						{
							Console.WriteLine("No top-performing posts this week");
						}
						else
						{
							foreach (var kvp in topCounts)
							{
								Console.WriteLine($"{kvp.Key} - {kvp.Value}");
							}
						}
						Console.WriteLine();
						break;

					case "3":
						// Calculate and display average likes across all creators
						double avg = app.CalculateAverageLikes();
						Console.WriteLine($"Overall average weekly likes: {avg}");
						Console.WriteLine();
						break;

					case "4":
						// Exit the application
						Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
						running = false;
						break;
				}
			}
		}

		/// <summary>
		/// Registers a new creator to the engagement board
		/// </summary>
		/// <param name="record">Creator statistics record</param>
		public void RegisterCreator(CreatorStats record)
		{
			EngagementBoard.Add(record);
		}

		/// <summary>
		/// Counts the number of weeks each creator met or exceeded the like threshold
		/// </summary>
		/// <param name="records">List of creator records</param>
		/// <param name="likeThreshold">Minimum likes threshold</param>
		/// <returns>Dictionary of creator names and their count of weeks meeting threshold</returns>
		public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
		{
			Dictionary<string, int> result = new Dictionary<string, int>();

			foreach (var creator in records)
			{
				int count = 0;
				// Count weeks where likes meet or exceed threshold
				foreach (double like in creator.WeeklyLikes)
				{
					if (like >= likeThreshold)
					{
						count++;
					}
				}

				// Only include creators with at least one week meeting threshold
				if (count > 0)
				{
					result[creator.CreatorName] = count;
				}
			}

			return result;
		}

		/// <summary>
		/// Calculates the overall average weekly likes across all creators
		/// </summary>
		/// <returns>Average likes per week</returns>
		public double CalculateAverageLikes()
		{
			double total = 0;
			int count = 0;

			// Sum all weekly likes across all creators
			foreach (var creator in EngagementBoard)
			{
				foreach (double like in creator.WeeklyLikes)
				{
					total += like;
					count++;
				}
			}

			// Return average or 0 if no data
			return count == 0 ? 0 : total / count;
		}
	}
}
