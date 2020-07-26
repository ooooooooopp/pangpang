using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// 에디터에서 씬을 빠르고 쉽게 열어서 작업할수 있도록 도와줍니다.

public class EditorSceneOpen
{
	[MenuItem( "Scenes/Lobby" )]
	public static void SceneOpen_LobbyScene()
	{
		// 현재 씬이 수정중인지 확인 후 저장 요청.
		if ( EditorSceneManager.GetActiveScene().isDirty == true ) {
			EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
		}
		EditorSceneManager.OpenScene( "Assets/LeeByeongCheol/Lobby.unity" ); // 에디터에 씬 열기.
	}

	[MenuItem( "Scenes/Play" )]
	public static void SceneOpen_Play()
	{
		if ( EditorSceneManager.GetActiveScene().isDirty == true ) {
			EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
		}
		EditorSceneManager.OpenScene( "Assets/LeeByeongCheol/Play.unity" );
	}

	[MenuItem( "Scenes/Choice" )]
	public static void SceneOpen_Choice()
	{
		if ( EditorSceneManager.GetActiveScene().isDirty == true ) {
			EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
		}
		EditorSceneManager.OpenScene( "Assets/LeeByeongCheol/Choice.unity" );
	}

	[RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
	static void FirstLoad()
	{
		string Lobby = "Lobby";
		string Choice = "Choice";
		string Play = "Play";

		if ( UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.CompareTo( Lobby ) != 0 ) {
			if ( UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.CompareTo( Choice ) == 0 ) {
				UnityEngine.SceneManagement.SceneManager.LoadScene( Lobby );
			} else if ( UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.CompareTo( Play ) == 0 ) {
				UnityEngine.SceneManagement.SceneManager.LoadScene( Lobby );
			}
		}
	}
}
