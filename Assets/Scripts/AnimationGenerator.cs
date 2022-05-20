using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections.Generic;

public class SpriteGenerator : EditorWindow
{
    List<Sprite> sprites;
    int numOfSprites = 1;
    float timeBetweenFrames = 0.1f;
    int FPS = 60;
    string fileName = "";
    Inversion inverted = Inversion.none;
    [MenuItem("Window/2D/Sprite Generator")]
    public static void ShowWindow()
    {
        var wnd = GetWindow<SpriteGenerator>("Sprite Generator");
    }

    private void OnGUI()
    {
        if (sprites == null)
            sprites = new List<Sprite>();

        fileName = EditorGUILayout.TextField("Name", fileName);

        timeBetweenFrames = EditorGUILayout.FloatField("Time between frames", timeBetweenFrames);
        inverted = (Inversion)EditorGUILayout.EnumPopup("Inversion", inverted);

        numOfSprites = EditorGUILayout.IntField("Number of Sprites", numOfSprites);

        if (numOfSprites > sprites.Count)
        {
            for(int i = sprites.Count; i < numOfSprites; i++)
            {
                sprites.Add(null);
            }
        }
        else if (numOfSprites <= sprites.Count)
        {
            var oldSprites = sprites.ToArray();
            sprites.Clear();
            for (int i = 0; i < numOfSprites; i++)
            {
                sprites.Add(oldSprites[i]);
            }
        }

        for(int i = 0; i < numOfSprites; i++)
        {
            
            sprites[i] = (Sprite)EditorGUILayout.ObjectField(sprites[i], typeof(Sprite), allowSceneObjects: true);
        }
        
        if (GUILayout.Button("Generate"))
        {
            FunctionToRun();
        }
    }

    private void FunctionToRun()
    {
        AnimationClip animClip = new AnimationClip();
        animClip.frameRate = 25;   // FPS

        AnimationClipSettings animClipSett = new AnimationClipSettings();
        animClipSett.loopTime = true;

        AnimationUtility.SetAnimationClipSettings(animClip, animClipSett);

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = "";
        spriteBinding.propertyName = "m_Sprite";

        if(sprites.Count > 1)
            sprites.Add(sprites[0]);

        ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[sprites.Count];
        for (int i = 0; i < (sprites.Count); i++)
        {
            spriteKeyFrames[i] = new ObjectReferenceKeyframe();
            spriteKeyFrames[i].time = i * timeBetweenFrames;
            spriteKeyFrames[i].value = sprites[i];
        }

        AnimationUtility.SetObjectReferenceCurve(animClip, spriteBinding, spriteKeyFrames);

        if (inverted != Inversion.none)
        {
            EditorCurveBinding mirrorBinding = new EditorCurveBinding();

            mirrorBinding.type = typeof(SpriteRenderer);
            mirrorBinding.path = "";
            mirrorBinding.propertyName = "m_FlipX";

            //ObjectReferenceKeyframe[] mirrorKeyFrame = new ObjectReferenceKeyframe[1];
            //mirrorKeyFrame[0] = new ObjectReferenceKeyframe();
            //mirrorKeyFrame[0].time = 0;
            //mirrorKeyFrame[0].value = ;

            //AnimationUtility.SetObjectReferenceCurve(animClip, mirrorBinding, mirrorKeyFrame);
            var curve = new AnimationCurve();

            switch(inverted)
            {
                case Inversion.mirrored:
                    curve.AddKey(0, 1.0f);
                    break;
                case Inversion.normal:
                    curve.AddKey(0, 0.0f);
                    break;
                default:
                    Debug.LogError("Non supported inversion");
                    break;
            }
            AnimationUtility.SetEditorCurve(animClip, mirrorBinding, curve);
        }

        string fullPath = AssetDatabase.GetAssetPath(sprites[0]);
        Debug.Log(fullPath);
        int index = fullPath.LastIndexOf('/');
        Debug.Log(index);
        fullPath = fullPath.Remove(index + 1);
        Debug.Log(fullPath);
        fullPath += fileName + ".anim";
        Debug.Log(fullPath);
        AssetDatabase.CreateAsset(animClip, fullPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}

public enum Inversion
{
    none,
    mirrored,
    normal
}

