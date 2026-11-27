using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

	[SerializeField]
	private ChapterData[] chapters;


	[SerializeField]
	private EnemySpawner enemySpawner;

	[SerializeField]
	private TextMeshPro textStageNumber;

	[SerializeField]
	private float enemyCountScale = 0.15f;


	private int currentChapter;
	private int maxStage;
	private int currentStage = 0;
	private int baseEnemyCount = 10;


	private void Start()
	{

		currentChapter = PlayerPrefs.GetInt(Constants.ChapterIndex);
		maxStage = chapters[currentChapter].StageDataTable.maxStage;

		// 현재 스테이지에 남아있는 적 숫자가 0이면 다음 스테이지로 넘어가도록 설정
		EnemySpawner.exitEvent.AddListener(SetupStage);

		// 스테이지 설정, 스테이지에 등장하는 적 생성
		SetupStage();
	}

	public void SetupStage()
	{
		currentStage++;

		if (currentStage > maxStage)
		{
			Logger.Log("챕터 클리어");
			// GameClear();
			return;
		}

		// 맵에 출력하는 currentStage Text UI 갱신
		textStageNumber.text = $"STAGE {currentStage:D2}";

		// 스테이지에 따라 등장하는 적 숫자 연산/생성
		enemySpawner.SpawnEnemys((int)(baseEnemyCount + currentStage * enemyCountScale));
	}

	public void SetTimeScale(float scale)
	{
		Time.timeScale = scale;
	}
}

