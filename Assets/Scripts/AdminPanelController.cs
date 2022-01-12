using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using SimpleFileBrowser;

public class AdminPanelController : MonoBehaviour {

	public Dropdown branch;
	public Dropdown gender;
	public Dropdown session;
	
	public GameObject simpleFileBrowserCanvas;
	
	private Vector3 simpleFileBrowserStartPos = new Vector3(0.1f, 1, -6.4f);

	void Awake() {

		PlayerPrefs.SetInt("Branch", 0);
		PlayerPrefs.SetInt("Gender", 0);
		PlayerPrefs.SetInt("Session", 0);
		
		//simpleFileBrowserCanvas.SetActive(true);
		if (simpleFileBrowserCanvas == null) {
			simpleFileBrowserCanvas = GameObject.Find("SimpleFileBrowserCanvas");
			simpleFileBrowserCanvas = FindObjectOfType<FileBrowser>().gameObject;
		}
		simpleFileBrowserCanvas.transform.position = new Vector3(170200, 740000, 0);
		
		UpdateSelection();
	}

	public void UpdateSelection() {
		int b, g, s;
		b = PlayerPrefs.GetInt("Branch", 0);
		g = PlayerPrefs.GetInt("Gender", 0);
		s = PlayerPrefs.GetInt("Session", 0);
		branch.value = b;
		gender.value = g;
		session.value = s;

	}

	public void SelectBranch() {
		PlayerPrefs.SetInt("Branch", branch.value);
		UpdateSelection();
	}

	public void SelectGender() {
		PlayerPrefs.SetInt("Gender", gender.value);
		UpdateSelection();
	}

	public void SelectSession() {
		PlayerPrefs.SetInt("Session", session.value);
		UpdateSelection();
	}
	
	public void ResetPrefabs() {
		PlayerPrefs.DeleteAll();
		UpdateSelection();
	}

	public void SelectVideo() {
		
		//FileBrowser.SetFilters( true, new FileBrowser.Filter( "Videos", ".mp4", ".mkv" ));
		FileBrowser.SetDefaultFilter( ".mp4" );
		FileBrowser.AddQuickLink( "Home", "/storage/emulated/0/", null );
		FileBrowser.AddQuickLink( "HOME2", "file:///storage/emulated/0/", null );
		
		/*NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) => {
			if (path != null) {
			}
		}, "Seans videosu seçin", "video/mp4");*/

		StartCoroutine(ShowLoadDialogCoroutine());
	}
	
	IEnumerator ShowLoadDialogCoroutine()
	{
		// Show a load file dialog and wait for a response from user
		// Load file/folder: both, Allow multiple selection: true
		// Initial path: default (Documents), Initial filename: empty
		// Title: "Load File", Submit button text: "Load"
		//simpleFileBrowserCanvas.SetActive(true);
		
		simpleFileBrowserCanvas.transform.position = simpleFileBrowserStartPos;
		yield return FileBrowser.WaitForLoadDialog( FileBrowser.PickMode.FilesAndFolders, true, null, null, "Video Seçin", "Seç" );

		// Dialog is closed
		// Print whether the user has selected some files/folders or cancelled the operation (FileBrowser.Success)
		Debug.Log( FileBrowser.Success );

		if( FileBrowser.Success )
		{
			// Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
			for( int i = 0; i < FileBrowser.Result.Length; i++ )
				Debug.Log( FileBrowser.Result[i] );

			// Read the bytes of the first file via FileBrowserHelpers
			// Contrary to File.ReadAllBytes, this function works on Android 10+, as well
			byte[] bytes = FileBrowserHelpers.ReadBytesFromFile( FileBrowser.Result[0] );

			// Or, copy the first file to persistentDataPath
			/*string destinationPath = Path.Combine( Application.persistentDataPath, FileBrowserHelpers.GetFilename( FileBrowser.Result[0] ) );
			FileBrowserHelpers.CopyFile( FileBrowser.Result[0], destinationPath );*/
			string path = FileBrowser.Result[0];
			if (path != null || path != "") {
				int b, g, s;
				b = PlayerPrefs.GetInt("Branch", 0); //0: football, 1: volleyball, 2:basketball
				g = PlayerPrefs.GetInt("Gender", 0); //0:male, 1:female
				/*
				volleyball
					f: 0
					m: 1
				basketball
					f: 2
					m: 3
				football
					f: 4
					m: 5
				 */
				s = PlayerPrefs.GetInt("Session", 0);
				if (b == 0) {
					if (g == 0) { //football male 5
						VideoManager.instance.UpdateVideos(5, s, path);
					} else { //football female 4
						VideoManager.instance.UpdateVideos(4, s, path);
					}
				} else if (b == 1) {
					if (g == 0) {//volleyball male 1
						VideoManager.instance.UpdateVideos(1, s, path);
					} else {//volleyball female 0
						VideoManager.instance.UpdateVideos(0, s, path);
					}
				} else if (b == 2) {
					if (g == 0) {//basketball male 3
						VideoManager.instance.UpdateVideos(3, s, path);
					} else {//basketball female 2
						VideoManager.instance.UpdateVideos(2, s, path);
					}
				}
				
				simpleFileBrowserCanvas.transform.position = new Vector3(170200, 740000, 0);
				//simpleFileBrowserCanvas.SetActive(true);
			}
			
		}
	}

}