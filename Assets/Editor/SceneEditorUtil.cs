using System.Text;
using System.IO;
using UnityEditor;

namespace SceneUtil
{
    public class SceneEditorUtil : Editor
    {

        [InitializeOnLoadMethod]
        [MenuItem("Scenes/Refresh")]
        public static void Refresh()
        {
            var code = CreateSceneUtilScript();
            SaveFile(code, Path.Combine(GetPath(), "SceneUtilAutoGenerated.cs"));
            AssetDatabase.Refresh();
        }

        private static string GetPath()
        {
            var a = AssetDatabase.FindAssets($"t:Script {nameof(SceneEditorUtil)}");
            var filePath = AssetDatabase.GUIDToAssetPath(a[0]);
            var pathArray = filePath.Split('/');
            filePath = string.Empty;

            for (int i = 0; i < pathArray.Length - 1; i++)
                filePath += pathArray[i] + $"/";

            return filePath;
        }

        private static StringBuilder CreateSceneUtilScript()
        {
            var consideredScenes = EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes);
            StringBuilder sb = new();
            sb.AppendLine("// This is Auto Generated Script so any modification will overwrite\n");
            sb.AppendLine("using UnityEditor;\n");
            sb.AppendLine("public class SceneUtilAutoGenerated");
            sb.AppendLine("{");

            foreach (var scene in consideredScenes)
            {
                GenerateSceneMethod(ref sb, scene, 4);
            }

            sb.AppendLine("}");
            return sb;
        }

        private static void GenerateSceneMethod(ref StringBuilder methodSb, string scenePath, uint appendLevel)
        {

            var sceneArray = scenePath.Split('/');

            // Neg sceneName with -6 (which point to . in string index) and -1 to satisfy offset so
            // you'll get one scene name without .unity extension
            var sceneName = sceneArray[^1][..(sceneArray[^1].Length - 6)];

            AutoGenerateMethodDefinitionStructure(ref methodSb, sceneName, appendLevel);
            AutoGenerateOpeningCurlyBraces(ref methodSb, appendLevel);
            AutoIndent(ref methodSb, appendLevel + 4);
            methodSb.Append($"var scenePath = \"{scenePath}\";\n");
            AutoIndent(ref methodSb, appendLevel + 4);
            methodSb.Append($"{typeof(SceneEditorUtil).Namespace}.{nameof(SceneEditorUtil)}.OpenScene(scenePath);\n");
            AutoGenerateCloseingCurlyBraces(ref methodSb, appendLevel);

        }

        private static void AutoGenerateMethodDefinitionStructure(ref StringBuilder sb, string sceneName, uint appendLevel)
        {
            AutoIndent(ref sb, appendLevel);
            sb.Append($"[MenuItem(\"Scenes/{sceneName}\")]\n");
            AutoIndent(ref sb, appendLevel);
            sb.Append($"public static void Generated{sceneName}Method()\n");
        }

        private static void AutoIndent(ref StringBuilder sb, uint appendLevel)
        {
            for (int i = 0; i < appendLevel; i++)
                sb.Append(" ");
        }

        private static void AutoGenerateOpeningCurlyBraces(ref StringBuilder sb, uint appendLevel)
        {
            AutoIndent(ref sb, appendLevel);
            sb.Append("{\n");
        }

        private static void AutoGenerateCloseingCurlyBraces(ref StringBuilder sb, uint appendLevel)
        {
            AutoIndent(ref sb, appendLevel);
            sb.Append("}\n\n");
        }

        private static void SaveFile(StringBuilder code, string path)
        {
            File.WriteAllText(path, code.ToString());
        }

        public static void OpenScene(string scenePath)
        {
            UnityEditor.SceneManagement.EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scenePath);
        }
    }
}
