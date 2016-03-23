
// Originally written by Lasse Makholm, I believe.
// Changed a bit for non-Team-license systems by Jamie Fristrom ( happionlabs.com / @happionlabs ) - without Team license, it'll post an error message
// if you try to save to a readonly file. With Team license, it will prevent you from editing a readonly file.

// I'm pretty sure Unity intended to release this into the wild but not positive.

/*
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;

public class RespectReadOnly : UnityEditor.AssetModificationProcessor
{
	// Known issues:
	// You can still apply changes to prefabs of locked files (but the prefabs wont be saved)
	// You can add add components to prefabs (but the prefabs wont be saved)
	// IsOpenForEdit might get called a few too many times per object selection, so try and cache the result for performance (i.e called in same frame)

	public static void OnWillCreateAsset (string path)
	{
		Debug.Log ("OnWillCreateAsset " + path);
	}

	public static string[] OnWillSaveAssets (string[] paths)
	{
		List<string> result = new List<string>();
		foreach( var path in paths )
		{
			if( IsUnlocked(path))
				result.Add ( path );
			else
				Debug.LogError ( path + " is read-only.");
		}
		return result.ToArray();
	}

	public static AssetMoveResult OnWillMoveAsset (string oldPath, string newPath)
	{
		AssetMoveResult result = AssetMoveResult.DidNotMove;
		if (IsLocked (oldPath)) {
			Debug.LogError (string.Format ("Could not move {0} to {1} because {0} is locked!", oldPath, newPath));
			result = AssetMoveResult.FailedMove;
		} else if (IsLocked (newPath)) {
			Debug.LogError (string.Format ("Could not move {0} to {1} because {1} is locked!", oldPath, newPath));
			result = AssetMoveResult.FailedMove;
		}
		return result;
	}

	public static AssetDeleteResult OnWillDeleteAsset (string assetPath, RemoveAssetOptions option)
	{
		if (IsLocked (assetPath)) {
			Debug.LogError (string.Format ("Could not delete {0} because it is locked!", assetPath));
			return AssetDeleteResult.FailedDelete;
		}
		return AssetDeleteResult.DidNotDelete;
	}

//	public static bool IsOpenForEdit (string assetPath, out string message)
//	{
//		if (IsLocked (assetPath)) {
//			message = "File is locked for editing!";
//			return false;
//		} else {
//			message = null;
//			return true;
//		}
//	}

	static bool IsUnlocked (string path)
	{
		return !IsLocked (path);
	}

	static bool IsLocked (string path)
	{
		if (!File.Exists (path))
			return false;
		FileInfo fi = new FileInfo (path);
		return fi.IsReadOnly;
	}
}
