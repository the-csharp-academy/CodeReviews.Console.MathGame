public class GameData
{
	private GameState gameType;
	private int numberOfRoundsToPlay;
	private int playerScore;
	public GameData(int roundNumber, GameState gameType)
	{
        numberOfRoundsToPlay = roundNumber;
		this.gameType = gameType;
    }
	public int GetNumberOfRoundsToPlay()
	{
		return numberOfRoundsToPlay;
	}

	public int GetPlayerScore()
	{
		return playerScore;
	}

	public void IncreasePlayerScore()
	{
		playerScore++;
	}

	public GameState GetGameType()
	{
		return gameType;
	}
}
